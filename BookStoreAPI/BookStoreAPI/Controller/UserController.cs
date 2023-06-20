using AutoMapper;
using BookStoreAPI.Core.DTO;
using BookStoreAPI.Core.Interface;
using BookStoreAPI.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;

namespace BookStoreAPI.Controller
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _user;
        IMapper _mapper;
        public UserController(IUserService user,IMapper mapper) 
        {
            _user = user;
            _mapper = mapper;
        }    
        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if(login != null)
            {
                var respone= await _user.CheckLogin(login);
                if(respone != null)
                {
                    return Ok(respone);
                }
            }
            return BadRequest();
        }
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser()
        {
            var respone = await _user.GetAllUser();
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest();
        }
        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var respone = await _user.GetUserById(userId);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest();
        }
        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            if(userDTO != null)
            {
                var user= _mapper.Map<User>(userDTO);
                var result= await _user.CreateUser(user);
                if(result) return Ok("Create User Success");
            }
            return BadRequest("Create User Fail");
        }
    }
}
