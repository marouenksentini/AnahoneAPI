using AnahoneAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AnahoneAPI.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        { }
        public DbSet<SearchPersons> SearchPerson { get; set; }
        public DbSet<BloodDonor> BloodDonors { get; set; }
        public DbSet<LookingForDonor> LookingForDonors { get; set; }
        public DbSet<FindPerson> FindPersons { get; set; }
        public object BloodDonor { get; internal set; }
    }
}  

    
    

