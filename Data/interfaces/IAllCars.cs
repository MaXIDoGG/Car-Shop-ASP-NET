using Shop.Data.Models;

namespace Shop.Data.interfaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Car> getFavCars {  get; }
        Car getObjectCar(int carId);
    }
}
