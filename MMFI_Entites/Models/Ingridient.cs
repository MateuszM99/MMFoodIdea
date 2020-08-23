using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Ingridient
    {
        [Key]
        public int IngridientId { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }      
        public int RecipeId { get; set; }
    }
}
