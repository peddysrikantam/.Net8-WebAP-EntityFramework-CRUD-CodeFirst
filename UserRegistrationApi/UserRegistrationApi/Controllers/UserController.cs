using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistrationApi.Data;
using UserRegistrationApi.Model;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;
        public UserController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var allUsers = _dbContext.Users.ToList();
            return Ok(allUsers);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            var userDetails = _dbContext.Users.Find(id);
            if (userDetails != null)
            {
                return Ok(userDetails);

            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public IActionResult AddUser(User userDetails)
        {
            User userObj = new User()
            {
                Email = userDetails.Email,
                Name = userDetails.Name,
                Phone = userDetails.Phone,
                Password = userDetails.Password,
                UserId = userDetails.UserId
            };

            _dbContext.Users.Add(userObj);
            _dbContext.SaveChanges();
            return Ok(userObj);
        }


        [HttpPut]
        public IActionResult UpdateUser(int id, User userDetails)
        {
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                user.Email = userDetails.Email;
                user.Password = userDetails.Password;
                user.Phone = userDetails.Phone;
                user.Name = userDetails.Name;
                user.UserId = userDetails.UserId;
            }

            _dbContext.SaveChanges();
            return Ok(user);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteUser(int id)
        {
            var userDetails = _dbContext.Users.Find(id);
            if (userDetails != null)
            {
                _dbContext.Users.Remove(userDetails);
                _dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
