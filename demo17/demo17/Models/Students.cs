using System.ComponentModel.DataAnnotations;

namespace demo17.Models
{
    public class Students
    {

        [Key]
        public int id { get; set; } 
        public string name { get; set; }    
        public string age { get; set; }
        public string standard{ get; set; }    

    }
}
