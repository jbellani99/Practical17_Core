using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo17.Models
{
    public class User
    {
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Key]
        public string email { get; set; }

        public string address { get; set; }

        [MinLength(10)]
        [MaxLength(10)]
        public int mobileNumber { get; set; }
        public string password { get; set; }

        public int roleId { get; set; }
        [ForeignKey("roleId")]
        public Roles roles { get; set; }    



    }
}
