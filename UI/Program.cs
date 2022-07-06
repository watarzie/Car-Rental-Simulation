using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Update(new Car
            {
                CarId=2,
                BrandId=2,
                ColorId=2,
                DailyPrice=450,
                ModelYear=2021,
                Description="Temiz ve Bakımlı"
            });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.DailyPrice);
            }
        }
    }
}
