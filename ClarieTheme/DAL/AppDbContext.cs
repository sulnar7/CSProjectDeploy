using ClarieTheme.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClarieTheme.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogTag> BlogTags { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductVendor> ProductVendor { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<ContactForm> ContactForms { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
