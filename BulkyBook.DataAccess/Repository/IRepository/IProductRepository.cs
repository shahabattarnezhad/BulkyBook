﻿using System;
using System.Collections.Generic;
using System.Text;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
