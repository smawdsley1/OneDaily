using Microsoft.AspNetCore.Mvc;
using OneDaily.Models;
using OneDaily.Context;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.EntityFrameworkCore;

namespace OneDaily.Controllers
{
    public class SignInRequest
    {
        public string username { get; set; }
        public string password { get; set; }
    }


    [ApiController]
    [Route("api/[controller]")]
    public class UserController: ControllerBase
    {    
        private readonly OneDailyContext _context;

        public UserController(OneDailyContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        // another get method to get user by username with only pertinet data, doesn't send extra stuff, don't necessarily need this
        // just thought it would also be interesting, also doesn't send sensitive data like password, login data, etc.

        [HttpGet("ByUsername/{username}")]
        public async Task<ActionResult<UpdateUser>> GetUserByUserName(string username)
        {
            User user;
            try
            {
                 user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            if (user == null)
            {
                return NotFound();
            }

            var mappedUser = MapUserToUpdateUser(user);
            return mappedUser;
        }

        private UpdateUser MapUserToUpdateUser(User user)
        {
            return new UpdateUser 
            { 
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Bio = user.Bio,
                ProfilePicture = user.ProfilePicture
            };

        }


        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {

            if (string.IsNullOrEmpty(user.Username))
            {
                return BadRequest("Username is required");
            }
            if (string.IsNullOrEmpty(user.PasswordHash))
            {
                return BadRequest("Password is required");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                return BadRequest("Email is required");
            }


            if (ModelState.IsValid)
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                Console.WriteLine("success");
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /*
         * Only updates:
         * Username
         * Email
         * Password
         */
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, UpdateUser user)
        {

            if (id != user.UserId)
            {
                return BadRequest("User id mismatch");
            }

            var existingUser = await GetUser(id);
            if (existingUser.Value == null)
            {
                return NotFound("User not found.");
            }

            var updatedUser = existingUser.Value;


            // updates all the fields that I included in the UpdateUser model
            // UpdateUser only holds the fields that I want the user to have access to 
            updatedUser.FirstName = user.FirstName ?? updatedUser.FirstName;
            updatedUser.LastName = user.LastName ?? updatedUser.LastName;
            updatedUser.Username = user.Username ?? updatedUser.Username;
            updatedUser.Email = user.Email ?? updatedUser.Email;
            updatedUser.DateOfBirth = user.DateOfBirth ?? updatedUser.DateOfBirth;
            updatedUser.Bio = user.Bio ?? updatedUser.Bio;
            updatedUser.ProfilePicture = user.ProfilePicture ?? user.ProfilePicture;
           
            if (ModelState.IsValid)
            {
                _context.Users.Attach(updatedUser).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                Console.WriteLine("success");
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost("signin")]
        public async Task<ActionResult> SignIn([FromBody] SignInRequest signInRequest)
        {
            if (string.IsNullOrEmpty(signInRequest.username) || string.IsNullOrEmpty(signInRequest.password))
            {
                return BadRequest("Username and password are required");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == signInRequest.username);

            if (user == null)
            {
                return NotFound("user not found");
            }

            if(BCrypt.Net.BCrypt.Verify(signInRequest.password, user.PasswordHash))
            {
                return Ok("User authenticated");
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }

        }

        private bool UserExists(long id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
