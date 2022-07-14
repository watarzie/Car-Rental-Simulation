using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=250,ModelYear=2016,Descriptions="Temiz"},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=300,ModelYear=2018,Descriptions="Temiz"},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=200,ModelYear=2008,Descriptions="Temiz"},
                new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=400,ModelYear=2020,Descriptions="Temiz"},
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car cartoDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(cartoDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(c => c.CarId == id).ToList();
        }

        public List<CarDetailDto> GetCarsDetail()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car cartoUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            cartoUpdate.CarId = car.CarId;
            cartoUpdate.BrandId = car.BrandId;
            cartoUpdate.ColorId = car.ColorId;
            cartoUpdate.DailyPrice = car.DailyPrice;
            cartoUpdate.Descriptions = car.Descriptions;
        }
    }
}
