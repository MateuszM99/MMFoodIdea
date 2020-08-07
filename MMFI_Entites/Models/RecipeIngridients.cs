using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.Models
{
    public class RecipeIngridients
    {
        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }
        public int IngridientId { get; set; }
        public Ingridient Ingridient { get; set; }
    }
}
