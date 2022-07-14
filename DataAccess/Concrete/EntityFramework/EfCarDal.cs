using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarsDetail()
        {
            using (RecapProjectContext context=new RecapProjectContext())
            {
                var result = from c in context.Cars
                             join d in context.Colors
                             on c.ColorId equals d.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
   
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 CarName = b.BrandName,
                                 ColorName = d.ColorName

                             };
                return result.ToList();
                           
                           
                           
                           

                           
            }
        }
    }
}
