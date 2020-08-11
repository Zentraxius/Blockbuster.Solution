using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Blockbuster.Models;

namespace Blockbuster.Models
{
  public class RecipeBoxContext : IdentityDbContext<ApplicationUser>
  {
    // public virtural DbSet<Tag> Tags { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Video> Videos { get; set; }
    public BlockbusterContext(DbContextOptions options) : base(options) { }
  }
}