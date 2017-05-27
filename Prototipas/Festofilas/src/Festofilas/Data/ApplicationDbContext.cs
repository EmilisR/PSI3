using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Festofilas.Data.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Festofilas.Models;

namespace Festofilas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ArticleFestival>().HasKey(x => new { x.ArticleId, x.FestivalId });

            builder.Entity<ArticleFestival>()
                .HasOne(pc => pc.Article)
                .WithMany(p => p.ArticleFestivals)
                .HasForeignKey(pc => pc.FestivalId);

            builder.Entity<ArticleFestival>()
                .HasOne(pc => pc.Festival)
                .WithMany(c => c.ArticleFestivals)
                .HasForeignKey(pc => pc.ArticleId);


            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
