using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OneDaily.Context;
using OneDaily.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OneDaily.Controllers
{
    // this is a model to display potential match options
    public class PotentialMatch
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public int SharedInterests { get; set; }
    }

    public class MatchRequest
    {
        public string User1Username { get; set; }
        public string User2Username { get; set; }
    }



    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        private readonly OneDailyContext _context;

        public MatchController(OneDailyContext context)
        {
            _context = context;
        }

        private bool MatchExists(long id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }

        private long GetUserIdFromUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user.UserId;
        }

        // gets a list of "PotentialMatch" objects based on number of shared interests and returns it 
        [HttpGet("sharedinterests")]
        public async Task<IActionResult> GetMatchBySharedInterests([FromQuery] string username)
        {
            long userId = GetUserIdFromUsername(username);

            var userInterests = await _context.UserInterests.Where(ui => ui.UserId == userId).Select(ui => ui.InterestId).ToListAsync();

            if (!userInterests.Any())
            {
                return NotFound("No interests found for the user.");
            }

            var potentialMatches = await _context.UserInterests
                .Where(ui => ui.UserId != userId && userInterests.Contains(ui.InterestId))
                .GroupBy(ui => new { ui.UserId, ui.User.Username })
                .Select(g => new PotentialMatch { UserId = g.Key.UserId, Username = g.Key.Username, SharedInterests = g.Count() })
                .OrderByDescending(m => m.SharedInterests)
                .ThenBy(m => m.Username)
                .ToListAsync();

            if (!potentialMatches.Any())
            {
                return NotFound("No potential matches found.");
            }

            return Ok(potentialMatches);
        }

        //IMPLEMENT LATER, THIS WILL ADD PENDING MATCH FUNCTIONALITY
        // api/Match/PendingMatches/{username}
        [HttpGet("PendingMatches/{username}")]
        public async Task<ActionResult<IEnumerable<Match>>> PendingMatches(string username)
        {
            long userId = GetUserIdFromUsername(username);

            var pendingMatches = await _context.Matches
                .Where(m => (m.User1Id == userId || m.User2Id == userId) && m.MatchStatus == "Pending")
                .ToListAsync();

            if (!pendingMatches.Any())
            {
                return NotFound("No pending matches found.");
            }

            List<Match> uniqueMatches = new List<Match>();
            HashSet<long> matchIds = new HashSet<long>();

            foreach (var match in pendingMatches)
            {
                if (!matchIds.Contains(match.MatchId))
                {
                    uniqueMatches.Add(match);
                    matchIds.Add(match.MatchId);
                }
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string json = JsonSerializer.Serialize(uniqueMatches, options);

            return Content(json, "application/json");
        }



        // api/Match
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }


        // api/Match
        // post with both usernames and updates the status of the matches
        [HttpPost]
        public async Task<ActionResult<Match>> PostMatch(MatchRequest matchRequest)
        {
            User? user1 = await _context.Users.FirstOrDefaultAsync(u => u.Username == matchRequest.User1Username);
            User? user2 = await _context.Users.FirstOrDefaultAsync(u => u.Username == matchRequest.User2Username);


            if (user1 == null || user2 == null)
            {
                return NotFound("User 1 or User 2 was not found and returned null");
            }

            long user1Id = user1.UserId;
            long user2Id = user2.UserId;

            var match = new Match
            {
                User1Id = user1Id,
                User2Id = user2Id,
                User1Status = 1,
                User2Status = 3,
                MatchStatus = "Pending"
            };

            _context.Matches.Add(match);
            _context.SaveChanges();
            return Ok(match);

        }

        /*
                // api/Match
                // FOR A POST, 
                [HttpPost]
                public async Task<ActionResult<Match>> PostMatch(Match match)
                {
                    var matchesToDelete = _context.Matches.Where(m => m.User1Id == match.User1Id || m.User2Id == match.User1Id).ToList();


                    match.MatchStatus = "Pending";
                    _context.Matches.Add(match);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction(nameof(GetMatches), new { id = match.MatchId }, match);
                }
        */
        // api/Match/DeclineMatch/{matchId}
        [HttpDelete("DeclineMatch/{matchId}")]
        public async Task<IActionResult> DeclineMatch(long matchId)
        {
            var toDelete = await _context.Matches.FindAsync(matchId);
            if (toDelete == null)
            {
                return NotFound("match could not be found");
            }
            _context.Matches.Remove(toDelete);
            await _context.SaveChangesAsync();
            return Ok("match declined and deleted");
        }

        // api/Match/AcceptMatch/{matchId}/{username}
        [HttpPut("AcceptMatch/{matchId}/{username}")]
        public async Task<IActionResult> AcceptMatch(long matchId, string username)
        {
            long userId = GetUserIdFromUsername(username);

            var match = await _context.Matches.FindAsync(matchId);
            if (match == null)
            {
                return NotFound("match not found");
            }

            // note that since user1 is the one to send the request only user2 need put a request to accept
            if (match.User2Id == userId) 
            {
                match.User2Status = 1; 
                match.MatchStatus = "Matched";

                // need all possible coorelations so that both matches a user started or is a part of is deleted
                var otherMatches = _context.Matches.Where(m =>
                    (m.User1Id == match.User1Id || m.User2Id == match.User1Id || m.User1Id == match.User2Id || m.User2Id == match.User2Id) &&
                    m.MatchStatus == "Pending" &&
                    m.MatchId != matchId).ToList();

                _context.Matches.RemoveRange(otherMatches);
            }
            else
            {
                return BadRequest("user not found in the match");
            }

            _context.Entry(match).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchExists(matchId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            Console.WriteLine("Successful upload to db");
            return NoContent();
        }

    }

}

