using Shop.Data.Models;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            
            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any()) {
                content.AddRange(
                    new Car { name = "Tesla", shortDesc = "", longDesc = "", img = "/img/tesla.jpg", price = 45000, isFavourite = true, available = true, Category = Categories["Электромобили"] },
                    new Car { name = "Audi", shortDesc = "", longDesc = "", img = "/img/audi.jpg", price = 50000, isFavourite = true, available = true, Category = Categories["Классические автомобили"] }
                );   
            }
            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories {
            get
            {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category { categoryName = "Электромобили", desc = "Современный вид транспорта"},
                        new Category {categoryName = "Классические автомобили", desc="Машины с ДВС"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list) category.Add(el.categoryName, el);

                }
                return category;

            }
        }
    }
}
