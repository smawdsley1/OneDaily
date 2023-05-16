using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneDaily.Context;
using OneDaily.Models;

namespace OneDaily.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly OneDailyContext _context;

        public ConversationController(OneDailyContext context)
        {
            _context = context;
        }
        private long GetUserIdFromUsername(string username)
        {
            User user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user.UserId;
        }
        // api/Conversation/GetByUser/{username}
        [HttpGet("GetByUser/{username}")]
        public async Task<ActionResult<long>> GetConversationIdByUsername(string username)
        {
            long userId = GetUserIdFromUsername(username);

            var match = await _context.Matches.FirstOrDefaultAsync(m => m.User1Id == userId || m.User2Id == userId);

            if (match == null)
            {
                return NotFound("No match found for the user.");
            }

            var conversation = await _context.Conversations.FirstOrDefaultAsync(c => c.MatchId == match.MatchId);

            if (conversation == null)
            {
                return NotFound("No conversation found for the match.");
            }

            return Ok(conversation.ConversationId);
        }


        [HttpPost("{matchId}")]
        public ActionResult<Conversation> CreateConversation(long matchId)
        {
            var newConversation = new Conversation
            {
                MatchId = (int)matchId,
                StartTime = DateTime.UtcNow
            };

            _context.Conversations.Add(newConversation);
            _context.SaveChanges();

            return CreatedAtAction(nameof(CreateConversation), new { id = newConversation.MatchId }, newConversation);
        }
    }
}
