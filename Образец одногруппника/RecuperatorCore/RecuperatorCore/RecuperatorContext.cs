using Microsoft.EntityFrameworkCore;
using RecuperatorLibrary.Models;

namespace RecuperatorCore
{
    public class RecuperatorContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Variant> Variants { get; set; }
        public DbSet<VariantUser> VariantUsers { get; set; }
        public RecuperatorContext(DbContextOptions<RecuperatorContext> options) : base(options)
        {

        }
    }
}
