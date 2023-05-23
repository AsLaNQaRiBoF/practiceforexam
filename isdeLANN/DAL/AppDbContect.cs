using isdeLANN.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace isdeLANN.DAL
{
    public class AppDbContect:IdentityDbContext<ApplicationUser>
    {
        public AppDbContect(DbContextOptions<AppDbContect> options):base(options)
        {     
        }
       public DbSet<CustomServices> customServices { get; set; }
    }
}
