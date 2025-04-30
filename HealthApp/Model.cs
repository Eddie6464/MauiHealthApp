using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace HealthApp;

public class AppDbContext: DbContext{
    private readonly string _dbPath;
    public DbSet<DBLightUpGameScore> DBLightUpGameScores { get; set; }
    public DbSet<DBMentalHealthGameScore> DBMentalHealthGameScores {get; set;}
    public DbSet<DBPlan> DBPlans {get; set;}
    public DbSet<DBQuestionaire> DBQuestionaires {get; set;}
    public DbSet<DBUser> DBUsers {get; set;}

    // Constructor with Dependency Injection
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Constructor for manual instantiation
    public AppDbContext(string dbPath)
    {
        _dbPath = dbPath;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DBUser>()
            .HasMany(u => u.DBLightUpGameScores)  
            .WithOne(e => e.DBUser)           
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<DBUser>()
            .HasMany(u => u.DBMentalHealthGameScores)  
            .WithOne(e => e.DBUser)           
            .HasForeignKey(e => e.UserId); 

        modelBuilder.Entity<DBUser>()
            .HasMany(u => u.DBPlans)  
            .WithOne(e => e.DBUser)           
            .HasForeignKey(e => e.UserId);

        modelBuilder.Entity<DBUser>()
            .HasMany(u => u.DBQuestionaires)  
            .WithOne(e => e.DBUser)           
            .HasForeignKey(e => e.UserId);

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={_dbPath}");
}