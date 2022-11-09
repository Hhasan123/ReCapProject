using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public List<RentalDto> GetRentalDto()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from rental in context.Rentals
                             join customer in context.Customers
                             on rental.CustomerId equals customer.Id
                             join user in context.Users
                             on customer.UserId equals user.Id
                             join car in context.Cars
                             on rental.CarId equals car.Id
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join model in context.Models
                             on car.ModelId equals model.ModelId
                             select new RentalDto
                             {
                                 RentId = rental.Id,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 BrandName = brand.BrandName,
                                 ModelName = model.ModelName,
                                 RentDate = rental.RentDate,
                                 ReturnDate = rental.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
