using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data.Persistence;

public class NetworkScanDbContextFactory
    : IDesignTimeDbContextFactory<NetworkScanDbContext>
{
    public NetworkScanDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(
                Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "../Server"))
            .AddJsonFile(
                "appsettings.json",
                optional: false)
            .Build();

        var connectionString =
            configuration.GetConnectionString("DefaultConnection");

        var options =
            new DbContextOptionsBuilder<NetworkScanDbContext>()
                .UseSqlServer(connectionString)
                .Options;

        return new NetworkScanDbContext(options);
    }
}