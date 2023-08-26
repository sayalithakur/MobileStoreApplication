using Microsoft.EntityFrameworkCore;
using MobilePhoneStore.Models;

namespace MobilePhoneStore.DBContext
{
    public class MobileStoreDBContext :DbContext
    {
        public MobileStoreDBContext(DbContextOptions<MobileStoreDBContext> Options  ):base(Options) 
        {

        }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<MobilePhone> MobilePhone { get; set; }

    }
}
