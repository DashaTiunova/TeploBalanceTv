using Microsoft.EntityFrameworkCore;

namespace TeploBalanceKotelCore.Data
{
    public class DataContext_TverdToplivo: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<VarTverdToplivo> VarTverdToplivos { get; set; }

        public DbSet<DataInputVariant_TverdToplivo> DataInputVariants_TverdToplivo { get; set; }

        //public DataContext(DbContextOptions<DataContext> options) 
        //    : base(options) { }


        public DataContext_TverdToplivo(DbContextOptions<DataContext_TverdToplivo> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=TeploBalanceKotelCoreBase.db");
        //}

    }
}
