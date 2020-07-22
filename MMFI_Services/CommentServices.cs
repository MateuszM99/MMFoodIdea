using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMFI_Services
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _appDb;
        public CommentServices(ApplicationDbContext appDb)
        {
            _appDb = appDb;
        }

        public List<Comment> GetAllComments(int? id)
        {
            if (id == null)
            return null;
            
            return _appDb.Comments.Where(c => c.RecipeId == id).ToList();       
        }

        public async Task PostComment(Comment comment)
        {
            comment.Date = DateTime.Now;
            comment.RecipeId = 1;
          
           // await _appDb.Comments.AddAsync(comment);
            
            await _appDb.SaveChangesAsync();          
        }

        public async Task DeleteComment(Comment comment)
        {
            _appDb.Remove(comment);
            await _appDb.SaveChangesAsync();
        }

        public async Task EditComment(Comment comment)
        {
           
        }
    }
}
