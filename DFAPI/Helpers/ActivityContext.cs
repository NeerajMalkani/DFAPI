using DFAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DFAPI.Helpers
{
    public class ActivityContext : DbContext
    {
        public ActivityContext(DbContextOptions<ActivityContext> options)
             : base(options)
        {
        }
        public DbSet<ActivityRoles> ActivityRoles { get; set; }
    }
}
