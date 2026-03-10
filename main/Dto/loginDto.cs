namespace main.Dto
{
    public class user_info
    {
        public string name { get; set; }
        public string usertype { get; set; }
        public string password { get; set; }


    }

    public class is_user_exist_op
    {
        public bool is_user_exist { get; set; }
        public string msg { get; set; }
    }
    
}
