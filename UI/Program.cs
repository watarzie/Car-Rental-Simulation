using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandTest();
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsDetail())
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " " + car.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);

            }
        }
    }
}
