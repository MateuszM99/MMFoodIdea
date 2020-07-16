using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMFI_Services
{
    public class CommentServices : ICommentServices
    {
        private readonly RecipeDbContext _recipeDb;
        public CommentServices(RecipeDbContext recipeDb)
        {
            _recipeDb = recipeDb;
        }

        public List<Comment> GetAllComments(int? id)
        {
            if (id == null)
            return null;
            
            return _recipeDb.Comments.Where(c => c.RecipeId == id).ToList();       
        }

        public bool PostComment(Comment comment)
        {
            _recipeDb.Comments.Add(comment);
            
          return  _recipeDb.SaveChanges() > 0;          
        }
    }
}
