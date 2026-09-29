using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence;

public class NetworkScanDbContext(DbContextOptions<NetworkScanDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel>(entity => {
            entity.HasKey(x => x.UserId);
            entity.Property(a => a.UserId).ValueGeneratedOnAdd();

            entity.HasIndex(a => a.EmployeeCode).IsUnique();
            entity.Property(a => a.EmployeeCode).IsRequired();

            entity.Property(a => a.FirstName).IsRequired();
            entity.Property(a => a.LastName).IsRequired();
        });
    }
}
