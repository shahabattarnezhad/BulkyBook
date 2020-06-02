using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Company company)
        {
            //var objFromDb = _db.Companies.FirstOrDefault(c => c.Id == company.Id);
            //if (objFromDb != null)
            //{
            //    objFromDb.State = company.State;
            //    objFromDb.City = company.City;
            //    objFromDb.IsAuthorizedCompany = company.IsAuthorizedCompany;
            //    objFromDb.Name = company.Name;
            //    objFromDb.PhoneNumber = company.PhoneNumber;
            //    objFromDb.PostalCode = company.PostalCode;
            //    objFromDb.StreetAddress = company.StreetAddress;
            //}

            //Other Option for updating
            _db.Companies.Update(company);

            //_db.Update(company);
        }
    }
}
