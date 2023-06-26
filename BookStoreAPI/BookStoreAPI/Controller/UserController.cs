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
        [HttpPost("login")]
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
            return BadRequest("Accound or Pass Wrong!");
        }
        [HttpGet("getUser")]
        public async Task<IActionResult> GetUser()
        {
            var respone = await _user.GetAllUser();
            if (respone != null)
            {
                var user = _mapper.Map<IEnumerable<UserDTO>>(respone);
                return Ok(user);
            }
            return BadRequest("null");
        }
        [HttpGet("getUserById")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var respone = await _user.GetUserById(userId);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest(userId + " don't exists");
        }
        [HttpGet("getUserByName")]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            var respone = await _user.GetUserByName(userName);
            if (respone != null)
            {
                return Ok(respone);
            }
            return BadRequest(userName+" don't exists");
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
        [HttpPut("updateUser")]
        public async Task<IActionResult> UpdateUser(UserDTO userDTO)
        {
            if (userDTO != null)
            {
                var user = _mapper.Map<User>(userDTO);
                var result = await _user.UpdateUser(user);
                if (result) return Ok("Update User Success");
            }
            return BadRequest("Update User Fail");
        }
        [HttpDelete("deleteUser")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
                var result = await _user.DeleteUser(userId);
                if (result) return Ok("Delete User Success");
                return BadRequest("Delete User Fail");
        }
        [HttpDelete("restoreUser")]
        public async Task<IActionResult> RestoreUser(string userId)
        {
            var result = await _user.RestoreUser(userId);
            if (result) return Ok("Restore User Success");
            return BadRequest("Restore User Fail");
        }
    }
}
