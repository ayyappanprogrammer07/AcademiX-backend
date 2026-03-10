using main.Dto;
using main.interfaceservice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace main.Controllers
{
    [Route("academix/login")]
    [ApiController]
    public class login : ControllerBase
    {
        public readonly loginInterface logininterface;
        public login(loginInterface _logininterface)
        {
            logininterface = _logininterface;
        }

        [HttpPost]
        public is_user_exist_op is_userExist(user_info user_info)
        {
            is_user_exist_op isuserexist= logininterface.is_userExist(user_info);
            return isuserexist;
        }
    }
}
