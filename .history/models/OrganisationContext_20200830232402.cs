using Microsoft.EntityFrameworkCore;

namespace skillsManagementApi.Models
{
    public class OrganisationContext : DbContext
    {
        public OrganisationContext(DbContextOptions<OrganisationContext> options)
            : base(options)
        {
        }

        public DbSet<OrganisationItem> OrganisationItems { get; set; }
    }
}