using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_Entites.Models
{
    public class CommentLike
    {
        public bool isLike { get; set; }
        public bool isDislike { get; set; }
        public string UserId { get; set; }
        public  int CommentId { get; set; }
    }
}
