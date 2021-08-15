using System;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(string userName, string passWord, string email) 
        {
            Id = Guid.NewGuid();
            UserName = userName;
            Password = passWord;
            Email = email;            
        }
    }
}
