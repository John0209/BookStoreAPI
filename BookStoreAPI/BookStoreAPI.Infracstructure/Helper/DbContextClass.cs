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
    public DbSet<Admin> Admins { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(en =>
        {
            en.ToTable("Admin");
            en.HasKey(u => u.Id);
        });
    }
}
