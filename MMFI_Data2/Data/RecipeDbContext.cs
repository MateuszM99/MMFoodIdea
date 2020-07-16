using Microsoft.EntityFrameworkCore;
using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Data.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
