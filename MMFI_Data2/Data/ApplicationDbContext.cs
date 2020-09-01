using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MMFI_Entites.Models;

namespace MMFoodIdea.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingridient> Ingridients { get; set; }    

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<RecipeLike> RecipeLikes { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            builder.Entity<Comment>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Comments)
                .HasForeignKey(d => d.UserId);
            builder.Entity<Recipe>()
                .HasOne<AppUser>(a => a.Sender)
                .WithMany(d => d.Recipes)
                .HasForeignKey(d => d.UserId);

            builder.Entity<Comment>()
                .HasOne<Recipe>(r => r.Recipe)
                .WithMany(c => c.Comments)
                .HasForeignKey(i => i.RecipeId);
                                      
            builder.Entity<CommentLike>()
                .HasKey(c => new { c.CommentId,c.UserId} );

            builder.Entity<AppUser>()
                .HasOne<Image>(x => x.ProfileImage);          
        }
    }
}
