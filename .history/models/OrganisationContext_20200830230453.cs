using Microsoft.EntityFrameworkCore;

namespace Organisation.Models
{
    public class OrganisationContext : DbContext
    {
        public OrganisationContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
    }
}