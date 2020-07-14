using Microsoft.EntityFrameworkCore;
using MMFI_Entites;
using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Data.Data
{
    public class IngridientsDbContext : DbContext
    {
        public IngridientsDbContext(DbContextOptions<IngridientsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ingridient> Ingridients { get; set; } 
    
    }
}