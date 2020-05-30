using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            var objFromDb = _db.Products.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (objFromDb != null)
            {
                if (product.ProductImage != null)
                {
                    objFromDb.ProductImage = product.ProductImage;
                }

                objFromDb.ProductISBN = product.ProductISBN;
                objFromDb.ProductListPrice = product.ProductListPrice;
                objFromDb.ProductPrice = product.ProductPrice;
                objFromDb.ProductPrice100 = product.ProductPrice100;
                objFromDb.ProductPrice50 = product.ProductPrice50;
                objFromDb.ProductDescription = product.ProductDescription;
                objFromDb.ProductAuthor = product.ProductAuthor;
                objFromDb.ProductTitle = product.ProductTitle;
                objFromDb.CategoryId = product.CategoryId;
                objFromDb.CoverTypeId = product.CoverTypeId;
            }
        }
    }
}
