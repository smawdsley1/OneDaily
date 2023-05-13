
using Microsoft.AspNetCore.Mvc;
using OneDaily.Context;
using OneDaily.Models;
using OneDaily.Controllers;

namespace OneDaily.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInterestController : ControllerBase
    {
        private OneDailyContext _context;

        public UserInterestController(OneDailyContext context)
        {
            _context = context;
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUserInterests(String username, [FromBody] List<long> interestIds)
        {
            long? userId = GetUserIdFromUsername(username);

            if (userId == null)
            {
                return NotFound(new { message = "user not found" });
            }

            // Remove existing user interests
            var existingInterests = _context.UserInterests
                .Where(ui => ui.UserId == userId);

            _context.UserInterests.RemoveRange(existingInterests);

            // Add new user interests
            var newUserInterests = interestIds.Select(interestId => new UserInterest
            {
                UserId = (long)userId,
                InterestId = interestId
            });

            _context.UserInterests.AddRange(newUserInterests);
            _context.SaveChanges();

            return Ok();
        }


        // add one controller action so that when you post a list of new userInterest entries it automatically deletes all existing ones
        // then posts all the new ones, essentially delete all current ones on userid, then post all the new ones

        private long GetUserIdFromUsername(String username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user.UserId;
        }

        [HttpGet("{username}")]
        public ActionResult<List<Interest>> GetUserInterests(String username)
        {
            long? userId = GetUserIdFromUsername(username);

            if (userId == null)
            {
                return NotFound(new { message = "user not found" });
            }

            var interests = _context.UserInterests
                .Where(ui => ui.UserId == userId)
                .Select(ui => ui.Interest)
                .ToList();

            return Ok(interests);
        }

        [HttpPost("{usermame}")]
        public IActionResult AddUserInterest(String username, [FromBody] List<long> interestIds)
        {
            long? userId = GetUserIdFromUsername(username);

            if (userId == null)
            {
                return NotFound(new { message = "user not found" });
            }

            var existingInterests = _context.UserInterests
                .Where(ui => ui.UserId == userId)
                .Select(ui => ui.InterestId)
                .ToList();

            var newInterests = interestIds
                .Where(id => !existingInterests.Contains(id))
                .Select(interestId => new UserInterest
                {
                    UserId = (long)userId,
                    InterestId = interestId
                });

            if (newInterests.Any())
            {
                _context.UserInterests.AddRange(newInterests);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest("No new interests to add.");
            }
        }

        [HttpDelete("{username}")]
        public IActionResult RemoveUserInterest(String username, [FromBody] List<long> interestIds)
        {
            long? userId = GetUserIdFromUsername(username);

            if (userId == null)
            {
                return NotFound(new { message = "user not found" });
            }
            var userInterestToRemove = _context.UserInterests
                .Where(ui => ui.UserId == userId && interestIds.Contains(ui.InterestId));

            _context.UserInterests.RemoveRange(userInterestToRemove);
            _context.SaveChanges();

            return Ok();
        }
    }
}
