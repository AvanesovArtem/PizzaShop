using System;
using System.Collections.Generic;
using PizzaShop.Models.Model;
using Shop.Models.Repository;

namespace PizzaShop.Models.Repository
{
    public class CommentRepository:IRepository<Comment>
    {
        private ApplicationDbContext context;
        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetFirst8()
        {
            return context.Comments;
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Comment item)
        {
            context.Comments.Add(item);

        }

        public void Update(Comment id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}