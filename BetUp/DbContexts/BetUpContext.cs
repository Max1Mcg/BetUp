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
    }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //=> optionsBuilder.UseNpgsql("Server=localhost;Database=BetUp;Port=5432;User Id=postgres;Password=max985irjkf2001");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Role_pkey");

            entity.ToTable("Role");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
