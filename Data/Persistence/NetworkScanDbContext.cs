using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence;

public class NetworkScanDbContext(DbContextOptions<NetworkScanDbContext> options) : DbContext(options)
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<ComputerModel> Computers { get; set; }
    public DbSet<HardDiskModel> HardDisks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.HasKey(x => x.UserId);
            entity.Property(a => a.UserId).ValueGeneratedOnAdd();

            entity.HasIndex(a => a.EmployeeCode).IsUnique();
            entity.Property(a => a.EmployeeCode).IsRequired();

            entity.Property(a => a.FirstName).IsRequired();
            entity.Property(a => a.LastName).IsRequired();
            entity.Property(a => a.MembershipType).IsRequired();
            entity.Property(a => a.Job).IsRequired();

            entity.Property(a => a.PhoneNumber).IsRequired();
            entity.HasIndex(a => a.PhoneNumber).IsUnique();

            entity.Property(a => a.NationalNumber).IsRequired();
            entity.HasIndex(a => a.NationalNumber).IsUnique();

        });

        modelBuilder.Entity<ComputerModel>(entity =>
        {
            entity.HasKey(x => x.ComputerId);
            entity.Property(a => a.ComputerId).ValueGeneratedOnAdd();

            entity.HasIndex(a => a.AssetCode).IsUnique();
            entity.HasIndex(a => a.SealNumber1).IsUnique();
            entity.HasIndex(a => a.SealNumber2).IsUnique();

            entity.Property(a => a.ComputerName).IsRequired();
            entity.HasIndex(a => a.ComputerName).IsUnique();

            entity.Property(a => a.MacAddress).IsRequired();
            entity.HasIndex(a => a.MacAddress).IsUnique();

            entity.Property(a => a.Cpu).IsRequired();
            entity.Property(a => a.Ram).IsRequired();
            entity.Property(a => a.OperatingSystem).IsRequired();

            entity.HasMany(x => x.HardDisks)
                .WithOne(x => x.Computer)
                .HasForeignKey(x => x.ComputerId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<HardDiskModel>(entity =>
        {
            entity.HasKey(x => x.HardDiskId);
            entity.Property(a => a.HardDiskId).ValueGeneratedOnAdd();

            entity.Property(a => a.Name).IsRequired();
            entity.Property(a => a.Capacity).IsRequired();

            entity.Property(a => a.SerialNumber).IsRequired();
            entity.HasIndex(a => a.SerialNumber).IsUnique();
        });
    }
}
