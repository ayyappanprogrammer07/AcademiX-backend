using main.Dto;
using main.interfacerepo;
using main.interfaceservice;

namespace main.Services
{
    public class loginservice : loginInterface
    {
        private readonly loginrepoInterface _loginrepoInterface;

        public loginservice(loginrepoInterface loginrepoInterface) 
        { 
            _loginrepoInterface = loginrepoInterface;
        }

        public is_user_exist_op is_userExist(user_info user_info)
        {
            is_user_exist_op result = _loginrepoInterface.is_userExist(user_info);
            return result;
        }

    }
}
