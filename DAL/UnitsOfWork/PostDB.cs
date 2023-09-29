using BOL;
using DAL.UnitsOfWork.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitsOfWork
{
    public class PostDB : IPostDB
    {
        LLDBContext _context;
        public PostDB(LLDBContext context)
        {
            _context = context;
        }

        public Task<bool> Approve(Post stry)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Post story)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int SSid)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetById(int SSid)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetByUserId(string Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Post> GetStoriesByStatus(bool IsApproved)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Post story)
        {
            throw new NotImplementedException();
        }
    }
}
