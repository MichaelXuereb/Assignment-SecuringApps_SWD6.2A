using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class CommentsService : ICommentService
    {
        private IMapper _autoMapper;
        private ICommentsRepository _comrepo;
        public CommentsService(ICommentsRepository comrepo, IMapper autoMapper)
        {
            _comrepo = comrepo;
            _autoMapper = autoMapper;
        }

        public void AddComment(CommentViewModel model)
        {
            var comment = _autoMapper.Map<Comment>(model);
            comment.SubmissionFK = comment.Submission.Id;
            comment.Submission = null;
            _comrepo.AddComment(comment);
        }

        public CommentViewModel GetComment(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<CommentViewModel> GetComments(Guid id)
        {
            return _comrepo.GetComments().Where(e => e.Submission.Id == id).ProjectTo<CommentViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
