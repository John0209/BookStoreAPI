using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreAPI.Core.Model;

namespace BookStoreAPI.Infracstructure.Helper;

public class DbContextClass : DbContext
{
    public DbContextClass()
    {

    }
    public DbContextClass(DbContextOptions<DbContextClass> options):base(options)
    {

    }
    #region DbSet
    public DbSet<Book> Books { get; set; }
    public DbSet<BookingRequest> Requests { get; set; }
    public DbSet<Category> Categorys { get; set; }
    public DbSet<ImageBook> ImageBooksBooks { get; set; }
    public DbSet<Importation> Importations { get; set; }
    public DbSet<ImportationDetail> ImportationDetails { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<InventoryDetail> InventoryDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<User> Users { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}
