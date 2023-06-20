using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Service.IService;

namespace BookStoreAPI.Controller
{
    [Route("api/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        IRoleService _role;
        RoleController(IRoleService role)
        {
            _role = role;
        }
    }
}
