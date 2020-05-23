using System;
using System.Collections.Generic;
using System.Text;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
