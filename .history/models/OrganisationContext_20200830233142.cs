using Microsoft.EntityFrameworkCore;

namespace skills_management_api.Models
{
    public class OrganisationContext : DbContext
    {
        public OrganisationContext(DbContextOptions<OrganisationContext> options)
            : base(options)
        {
        }

        public DbSet<Organisation> OrganisationItems { get; set; }
    }
}