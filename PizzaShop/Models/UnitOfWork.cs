using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaShop.Models.Model;
using PizzaShop.Models.Repository;
using Shop.Models.Repository;

namespace PizzaShop.Models
{
    public class UnitOfWork :IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private CartRepository orderRepository;
        private ProductRepository productRepository;
        private CommentRepository commentRepository;

        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository= new ProductRepository(context);

                }
                return productRepository;
            }
        }

        public CartRepository Orders
        {
            get
            {
                if (productRepository == null)
                {
                    orderRepository = new CartRepository(context);
                }
                return orderRepository;
            }
        }

        public CommentRepository Comments
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(context);
                }
                return commentRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}