using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> RentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars on r.CarId equals car.CarId
                             join b in context.Brands on car.BrandId equals b.BrandId
                             join cust in context.Customers on r.CustomerId equals cust.CustomerId
                             join u in context.Users on cust.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.CarId,
                                 CarName = b.BrandName,
                                 CustomerName = $"{u.FirstName } {u.LastName}", // u.FirstName + "" + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
            }
        }
    }
}
