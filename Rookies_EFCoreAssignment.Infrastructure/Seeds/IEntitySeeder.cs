using Microsoft.EntityFrameworkCore;

namespace Rookies_EFCoreAssignment.Infrastructure.Data.Seeds
{
    public interface IEntitySeeder
    {
        void Seed(ModelBuilder modelBuilder);
    }
}