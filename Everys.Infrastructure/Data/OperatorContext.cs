using Everys.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Everys.Infrastructure.Data
{
    public class OperatorContext : DbContext
        {
        public OperatorContext(DbContextOptions<OperatorContext> options)
            : base(options)
        {
        }

        public OperatorContext()
        {
        }

        public DbSet<Operator> Operator { get; set; }
    }
}
