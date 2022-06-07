using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Meetup.Shared.Core.Contracts.Database;

public interface IDatabaseMigrationService<in TContext>
 where TContext : DbContext
{
    Task Migrate(
        string[] args,
        IDesignTimeDbContextFactory<TContext> factory,
        CancellationToken cancellationToken = default);
}
