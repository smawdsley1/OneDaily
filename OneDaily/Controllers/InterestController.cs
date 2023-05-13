using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OneDaily.Context;
using OneDaily.Models;

namespace OneDaily.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InterestController: ControllerBase
    {
        private readonly OneDailyContext _context;

        public InterestController(OneDailyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Interest>> GetInterests()
        {
            return _context.Interests.ToList();
        }
    }
}
