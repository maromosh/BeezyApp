using BeezyApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BeezyApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string UserName { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public string UserPassword { get; set; } = null!;

        public string UserPhone { get; set; } = null!;

        public string UserCity { get; set; } = null!;

        public string UserAddress { get; set; } = null!;

        public bool IsManeger { get; set; }

        public User() { }
       
    }
}
