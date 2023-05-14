using System;
using Microsoft.AspNetCore.Mvc;
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
