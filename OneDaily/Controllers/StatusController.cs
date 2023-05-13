using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneDaily.Context;
using OneDaily.Models;
using OneDaily.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneDaily.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly OneDailyContext _context;

        public StatusController(OneDailyContext context)
        {
            _context = context;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Status>>> GetStatus()
        {
            return await _context.Statuses.ToListAsync();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatusById(long id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return NotFound();
            }

            return status;
        }
    }
}
