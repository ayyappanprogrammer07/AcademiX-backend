using main.Controllers;
using main.Dto;
using main.interfacerepo;
using main.interfaceservice;
using System.Data;
using Microsoft.Data.SqlClient;

namespace main.repoS
{
    public class loginRepos : loginrepoInterface
    {
        string connectionString = "";

        //This Repo responsible for check whether the user exist or not
        public loginRepos(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public is_user_exist_op is_userExist(user_info user_info)
        {
            is_user_exist_op result = new is_user_exist_op();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("login.isUserExist", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", user_info.name);
                        cmd.Parameters.AddWithValue("@usertype",user_info.usertype);
                        cmd.Parameters.AddWithValue("@password",user_info.password);
                        SqlParameter resultparameter = new SqlParameter("@result", SqlDbType.Int);
                        resultparameter.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(resultparameter);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        if(Convert.ToInt32(resultparameter.Value)==1)
                        {
                            result.is_user_exist = true;
                            result.msg = "User Found";
                        }
                        else
                        {
                            result.is_user_exist = false;
                            result.msg = "User can't found";
                        }
                        
                    }
                }
                return result;

            }
            catch 
            {

                return result;
            }
        }
    }
}
