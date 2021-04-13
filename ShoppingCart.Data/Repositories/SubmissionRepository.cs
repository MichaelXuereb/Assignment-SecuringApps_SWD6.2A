using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class SubmissionRepository : ISubmissionsRepository
    {
        ShoppingCartDbContext _context;
        public SubmissionRepository(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public void AddSubmission(Submission sb)
        {
            sb.Id = Guid.NewGuid();
            _context.Submissions.Add(sb);
            _context.SaveChanges();
        }

        public Submission GetSubmission(Guid id)
        {
            return _context.Submissions.SingleOrDefault(x => x.Id == id);
        }
    }
}
