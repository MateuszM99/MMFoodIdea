using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MMFI_IServices
{
    public interface ICommentServices
    {
        Task PostComment(Comment comment);
        Task DeleteComment(Comment comment);
        Task EditComment(Comment comment);
        Task CommentLiking(Comment comment, string userId);
        List<Comment> GetAllComments(int? id);
    }
}
