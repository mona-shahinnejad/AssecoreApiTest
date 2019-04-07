using AssecoreApiTest.Data.Entities;
using System.Data.Entity;

namespace AssecoreApiTest.Data
{
    public class AssecoreApiTestDatabaseContext : DbContext
    {
        public AssecoreApiTestDatabaseContext()
            : base("AssecoreApiTest")
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
