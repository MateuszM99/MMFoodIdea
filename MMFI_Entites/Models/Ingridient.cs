using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MMFI_Entites.Models
{
    public class Ingridient
    {
        [Key]
        public int IngridientId { get; set; }

        public string IngridientName { get; set; }


    }
}
