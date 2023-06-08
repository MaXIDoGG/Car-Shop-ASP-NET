using Shop.Data.interfaces;
using Shop.Data.Models;

namespace Shop.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _CategoryCars = new MockCategory();
        public IEnumerable<Car> Cars {
            get
            {
                return new List<Car>()
                {
                    new Car { name = "Tesla", shortDesc = "", longDesc = "", img = "/img/tesla.jpg", price = 45000, isFavourite = true, available = true, Category = _CategoryCars.AllCategories.First()},
                    new Car { name = "Audi", shortDesc = "", longDesc = "", img = "/img/audi.jpg", price = 50000, isFavourite = true, available = true, Category = _CategoryCars.AllCategories.Last()},

                };
            }
        }
        public IEnumerable<Car>? getFavCars { get; set; }

        public Car getObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
