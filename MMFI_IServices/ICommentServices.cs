using MMFI_Entites.Models;
using MMFI_Entites.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
    public interface ICommentServices
    {
        bool PostComment(Comment comment);

        List<Comment> GetAllComments(int? id);

    }
}
