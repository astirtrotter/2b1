using Microsoft.EntityFrameworkCore;
using TBOBackEnd.Models;

namespace TBOBackEnd
{
  public class _AppDbContext : DbContext
  {
    public _AppDbContext(DbContextOptions<_AppDbContext> options)
            : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }
    public virtual DbSet<AdminAccountStatus> AdminAccountStatuses { get; set; }
    public virtual DbSet<AdminActivity> AdminActivities { get; set; }
    public virtual DbSet<AdminPermission> AdminPermissions { get; set; }
    public virtual DbSet<AdminRole> AdminRoles { get; set; }
    public virtual DbSet<AdminToken> AdminTokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (!optionsBuilder.IsConfigured)
      {
        optionsBuilder.UseSqlServer(Startup.ConnectionString);
      }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
