using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace MMFI_Entites.ViewModels
{
    public class RecipesMainVM
    {
        public List<Recipe> Recipes { get; set; }

        public Category Category { get; set; }

        public Category selectedCategory { get; set; }

        public int? selectedTime { get; set; }

        public int? selectedRating { get; set; }
    }
}
