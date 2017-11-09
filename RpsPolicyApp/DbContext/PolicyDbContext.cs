using Microsoft.EntityFrameworkCore;
using RpsPolicyApp.Models;

namespace RpsPolicyApp.DbContext
{
  public class PolicyDbContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public PolicyDbContext(DbContextOptions<PolicyDbContext> options)
      : base(options)
    { }

    public DbSet<Policy> Policies { get; set; }
  }
}
