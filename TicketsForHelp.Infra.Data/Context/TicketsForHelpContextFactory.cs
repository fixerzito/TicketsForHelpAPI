using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TicketsForHelp.Infra.Data.Context;

public class TicketsForHelpContextFactory : IDesignTimeDbContextFactory<TicketsForHelpContext>
{
    public TicketsForHelpContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.Development.json", optional: false)
            .Build();
        
        var optionsBuilder = new DbContextOptionsBuilder<TicketsForHelpContext>();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlServer"));

        return new TicketsForHelpContext(optionsBuilder.Options);
    }
}