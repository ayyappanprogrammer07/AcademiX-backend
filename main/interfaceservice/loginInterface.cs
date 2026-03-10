using main.Dto;
using Microsoft.AspNetCore.Mvc;

namespace main.interfaceservice
{
    public interface loginInterface
    {
        public is_user_exist_op is_userExist(user_info user_info);

    }
}
