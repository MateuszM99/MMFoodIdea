using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task PostComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.RecipeId = 1;
          
            await _recipeDb.Comments.AddAsync(comment);
            
            await _recipeDb.SaveChangesAsync();          
        }
    }
}
