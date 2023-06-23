using System.ComponentModel.DataAnnotations;

namespace demo17.Models
{
    public class Roles
    {
        [Key]
        public int id { get; set; } 
        public string role_name { get; set; }    

    }
}
