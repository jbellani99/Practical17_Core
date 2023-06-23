using System.ComponentModel.DataAnnotations;

namespace demo17.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Username")]
        [Key]
        public string email { get; set; }

        [Required]
        [DataType(DataType.Password)]   
        public string password { get; set; }    

        

     
    }
}
