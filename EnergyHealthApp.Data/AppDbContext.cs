namespace EnergyHealthApp.Data;
using Microsoft.EntityFrameworkCore;
using EnergyHealthApp.Data.Models;

public class AppDbContext : DbContext
{
    private readonly string? _dbPath;

    public DbSet<EnergyProfile> EnergyProfiles { get; set; }
    public DbSet<EnergyQuestionnaire> EnergyQuestionnaires { get; set; }
    public DbSet<User> Users { get; set; }

    public AppDbContext(string dbPath)
    {
        _dbPath = dbPath;
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured && !string.IsNullOrEmpty(_dbPath))
        {
            options.UseSqlite($"Data Source={_dbPath}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasOne(u => u.EnergyProfile)
            .WithOne(e => e.User)
            .HasForeignKey<EnergyProfile>(e => e.UserId);

        modelBuilder.Entity<User>()
            .HasOne(u => u.EnergyQuestionnaire)
            .WithOne(e => e.User)
            .HasForeignKey<EnergyQuestionnaire>(e => e.UserId);

        base.OnModelCreating(modelBuilder);
        
    }
} 
