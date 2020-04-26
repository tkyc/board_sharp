using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BoardSharpAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public User() { }

        public User(string email, string username, string password)
        {
            Email = email;
            Username = username;
            Password = password;
        }
    }
}
