using System;
using System.Collections.Generic;
using BetUp.DbModels;
using Microsoft.EntityFrameworkCore;

namespace BetUp.DbContexts;

public partial class BetUpContext : DbContext
{
    public BetUpContext()
    {
    }

    public BetUpContext(DbContextOptions<BetUpContext> options)
        : base(options)
    {
        //Database.EnsureDeleted();
    }

    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Match> Matches { get; set; }
    public virtual DbSet<BKTeam> BKTeams { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<BK> BKs { get; set; }
    public virtual DbSet<BKMatch> BKMatches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
}
