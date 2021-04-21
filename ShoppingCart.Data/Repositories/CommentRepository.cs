using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CommentRepository : ICommentsRepository
    {
        ShoppingCartDbContext _context;

        public CommentRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void AddComment(Comment c)
        {
            c.Id = Guid.NewGuid();
            _context.Comments.Add(c);
            _context.SaveChanges();
        }

        public Comment GetComment(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Comment> GetComments()
        {
            return _context.Comments;
        }
    }
}
