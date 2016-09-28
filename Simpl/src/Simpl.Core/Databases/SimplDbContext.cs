using Microsoft.EntityFrameworkCore;
using OpenIddict;
using Simpl.Core.Models;

namespace Simpl.Core.Databases
{
    public class SimplDbContext : OpenIddictDbContext<User, Role, long>
    {
        public SimplDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            RegisterCustomMappings(builder);
        }

        private static void RegisterCustomMappings(ModelBuilder modelBuilder)
        {
            new IdentityModelBuilder().Build(modelBuilder);
        }
    }
}
