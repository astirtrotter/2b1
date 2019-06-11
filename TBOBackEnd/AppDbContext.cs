using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TBOBackEnd.Models;

namespace TBOBackEnd
{
  public class AppDbContext : DbContext
  {
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(Startup.ConnectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<User>().Ignore(e => e.FullName);

      //modelBuilder.Entity<Blog>(entity =>
      //{
      //  entity.Property(e => e.Url).IsRequired();
      //});

      //modelBuilder.Entity<Post>(entity =>
      //{
      //  entity.HasOne(d => d.Blog)
      //      .WithMany(p => p.Post)
      //      .HasForeignKey(d => d.BlogId);
      //});
    }
  }
}
