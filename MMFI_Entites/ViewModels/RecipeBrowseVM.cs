using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.ViewModels
{
    public class RecipeBrowseVM
    {
        public string RecipeName { get; set; }

        public int Time { get; set; }

        public List<Recipe> Recipes { get; set; }

    }
}
