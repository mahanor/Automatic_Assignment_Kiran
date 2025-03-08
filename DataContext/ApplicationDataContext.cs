using AutomaticInfotch_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace AutomaticInfotch_Assignment.DataContext
{
    public class ApplicationDataContext : DbContext
    {
        public ApplicationDataContext(DbContextOptions <ApplicationDataContext> options):base(options) 
        {

        }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

    }
}
