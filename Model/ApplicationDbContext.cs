using Microsoft.EntityFrameworkCore;

namespace Flask_API_Development.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ExecutionResult> executionResults { get; set; }
        public DbSet<TestCase> testCases { get; set; }
       
      

    }
}
