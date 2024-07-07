using System;
using System.Collections.Generic;
using BetUp.Controllers;
using BetUp.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BetUp.DbContexts;

public partial class BetUpContext : DbContext
{
    public BetUpContext()
    {
    }

    public BetUpContext(DbContextOptions<BetUpContext> options): base(options){}

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Match> Matches { get; set; }
    public virtual DbSet<BKTeam> BKTeams { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<BK> BKs { get; set; }
    public virtual DbSet<BKMatch> BKMatches { get; set; }
    public virtual DbSet<MatchMapping> MatchMapping { get; set; }
    public virtual DbSet<TeamMapping> TeamMapping { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeamMapping>()
            .HasIndex(m => new { m.BKTeamId, m.TeamId })
            .IsUnique();
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }
}
