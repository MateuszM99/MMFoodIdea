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

        [Required(ErrorMessage = "Name of ingridient is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity of ingridient is required")]
        public string Quantity { get; set; }      
        public int RecipeId { get; set; }
    }
}
