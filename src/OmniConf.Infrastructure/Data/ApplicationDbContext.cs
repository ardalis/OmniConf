using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using OmniConf.Infrastructure.Identity;
using OmniConf.Core.Model;

namespace OmniConf.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Conference> Conferences { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
    }
}
