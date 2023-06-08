using Microsoft.AspNetCore.Mvc;
using Shop.Data.interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController: Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;
        }
        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public ViewResult List(string category) {
            string _category = category;
            IEnumerable<Car> cars;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(i => i.id);

            } else
            {
                if(string.Equals("electro", category, StringComparison.OrdinalIgnoreCase)) {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили"));
                    currCategory = "Электромобили";
                } else
                {
                    cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили"));
                    currCategory = "Классические автомобили";
                }

                

                

            }

            var carObj = new CarsListViewModel
            {
                allCars = cars,
                currCategory = currCategory
            };



            ViewBag.Title = "Классические автомобили";
           
            return View(carObj);
        }
    }
}
