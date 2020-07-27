using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace MMFI_Services
{
    public class CommentServices : ICommentServices
    {
        private readonly ApplicationDbContext _appDb;
        private readonly UserManager<AppUser> _userManager;
        public CommentServices(ApplicationDbContext appDb, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
            comment.Recipe = new Recipe();
            comment.RecipeId = 1;                                           
            await _appDb.Comments.AddAsync(comment);
            
            await _appDb.SaveChangesAsync();          
        }

        public async Task DeleteComment(Comment comment)
        {
            _appDb.Remove(comment);
            await _appDb.SaveChangesAsync();
        }

       

        public async Task CommentLiking(Comment comment,string userId)
        {
            var hasUserLiked = await _appDb.CommentLikes
                                            .Where(x => x.CommentId == comment.CommentID && x.UserId == userId).AnyAsync();
            if (hasUserLiked != true)
            {
                CommentLike cl = new CommentLike();
                cl.CommentId = comment.CommentID;
                cl.UserId = userId;
                await _appDb.CommentLikes.AddAsync(cl);
            }
            else
            {
                var cl = await _appDb.CommentLikes.FindAsync(userId, comment.CommentID);
                _appDb.Remove(cl);
            }
        }

        public Task EditComment(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
