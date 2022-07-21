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
            //GetCarsDetail();
            //ResultsTest();

         
            
            
            

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            Rental rental = new Rental()
            {
                CarId = 2,
                CustomerId = 2,
                RentDate = new DateTime(2022, 07, 28),
                ReturnDate = new DateTime(2022, 07, 29)
            };
            
            Console.WriteLine(rentalManager.Add(rental).Message);
            
            
            

        }

        private static void ResultsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.Descriptions);
            }
        }

        private static void GetCarsDetail()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarsDetail().Data)
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
