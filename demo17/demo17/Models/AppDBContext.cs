using Microsoft.EntityFrameworkCore;



namespace demo17.Models
{
    public class AppDBContext:DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options ):base (options) { 
        
            
        }

        public DbSet<Students> Student { get; set; }    
        public DbSet<User> Users { get; set; }
        public DbSet<Roles> Role { get; set; }
        public DbSet<LoginModel> Loginmodel { get; set; }

    }
}
