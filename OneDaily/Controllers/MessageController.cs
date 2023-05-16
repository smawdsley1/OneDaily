using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneDaily.Context;
using OneDaily.Models;

namespace OneDaily.Controllers
{


    public class ClientMessage
    {
        public long? ConversationId { get; set; }
        public long? UserId { get; set; }
        public string? Content { get; set; }
        public string? ContentType { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly OneDailyContext _context;

        public MessageController(OneDailyContext context)
        {
            _context = context;
        }
        // GET: api/Message/GetByConversationId/{conversationId}
        // gets the entire conversation
        [HttpGet("GetByConversationId/{conversationId}")]
        public async Task<ActionResult<List<ClientMessage>>> GetMessagesByConversationId(long conversationId)
        {
            var messages = _context.Messages.Where(m => m.ConversationId == conversationId).ToList();

            if (messages == null || messages.Count == 0)
            {
                return NotFound();
            }

            List<ClientMessage> clientMessages = messages.Select(message => new ClientMessage
            {
                ConversationId = message.ConversationId,
                UserId = message.UserId,
                Content = message.Content,
                ContentType = message.ContentType,
            }).ToList();

            return clientMessages;
        }



        // GET: api/Message
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetMessages()
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            return await _context.Messages.ToListAsync();
        }


        // GET: api/Message/GetByUsername
        [HttpGet("GetByUsername/{username}")]
        public ActionResult<List<ClientMessage>> GetAllMessagesByUsername(string username)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            var match = _context.Matches.FirstOrDefault(m => (m.User1Id == user.UserId || m.User2Id == user.UserId) && m.MatchStatus == "Matched");
            if (match == null)
            {
                return NotFound();
            }

            var conversation = _context.Conversations.FirstOrDefault(c => c.MatchId == match.MatchId);
            if (conversation == null)
            {
                return NotFound();
            }

            var conversationId = conversation.ConversationId;

            var messages = _context.Messages
                .Where(m => m.ConversationId == conversationId)
                .Select(message => new ClientMessage
                {
                    ConversationId = message.ConversationId,
                    UserId = message.UserId,
                    Content = message.Content,
                    ContentType = message.ContentType
                })
                .ToList();

            return messages;
        }




        // GET: api/Message/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage(long id)
        {
          if (_context.Messages == null)
          {
              return NotFound();
          }
            var message = await _context.Messages.FindAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }


        // POST: api/Message
        [HttpPost]
        public async Task<ActionResult<Message>> PostMessage([FromBody] ClientMessage clientMessage)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == clientMessage.UserId);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                // user exists, so you can safely create the message
                var message = new Message
                {
                    ConversationId = (long)clientMessage.ConversationId,
                    UserId = (long)clientMessage.UserId,
                    Content = clientMessage.Content,
                    ContentType = clientMessage.ContentType,
                };
                _context.Messages.Add(message);
                await _context.SaveChangesAsync();
            }

            return Ok();
        }


        // DELETE: api/Message/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(long id)
        {
            if (_context.Messages == null)
            {
                return NotFound();
            }
            var message = await _context.Messages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }

            _context.Messages.Remove(message);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageExists(long id)
        {
            return (_context.Messages?.Any(e => e.MessageId == id)).GetValueOrDefault();
        }
    }
}
