using Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
     public ApplicationDbContext() {}

     public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
     {
         
     }

     public virtual DbSet<Customer> Customers { get; set; } 
     public virtual DbSet<Product> Products { get; set; } 
     public virtual DbSet<CustomerAddress> CustomerAddress { get; set; } 
    }
}