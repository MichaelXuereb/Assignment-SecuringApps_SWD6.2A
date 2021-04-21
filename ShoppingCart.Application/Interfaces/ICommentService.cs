using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ICommentService
    {
        CommentViewModel GetComment(Guid id);
        IQueryable<CommentViewModel> GetComments(Guid id);
        void AddComment(CommentViewModel model);
    }
}
