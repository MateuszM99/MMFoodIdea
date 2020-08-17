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

        public DbSet<RecipeIngridients> RecipeIngridients  { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CommentLike> CommentLikes { get; set; }

        public DbSet<Image> Images { get; set; }



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

            builder.Entity<RecipeIngridients>()
                 .HasKey(k => new { k.RecipeId, k.IngridientId });

            builder.Entity<RecipeIngridients>()
                .HasOne<Recipe>(r => r.Recipe)
                .WithMany(i => i.RecipeIngridients)
                .HasForeignKey(r => r.RecipeId);


            builder.Entity<RecipeIngridients>()
                .HasOne<Ingridient>(i => i.Ingridient)
                .WithMany(r => r.RecipeIngridients)
                .HasForeignKey(i => i.IngridientId);

        }
    }
}
