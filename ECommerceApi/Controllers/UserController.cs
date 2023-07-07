using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataLibrary;
using DataLibrary.Contracts;
using DataLibrary.Repositories;
using DataLibrary.Entities;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserContract _userContract;

        public UserController() 
        {
            _userContract = new UserRepository();
        }

        [HttpPost, Route("Register")]

        public IActionResult Register(User user)
        {
            try
            {
                _userContract.Register(user);
                return StatusCode(200, $"{user.Name} registered!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
