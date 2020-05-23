﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            var objFromDb = _db.Categories.FirstOrDefault(o => o.CategoryId == category.CategoryId);
            if (objFromDb != null)
            {
                objFromDb.CategoryName = category.CategoryName;
                _db.SaveChanges();
            }
        }
    }
}