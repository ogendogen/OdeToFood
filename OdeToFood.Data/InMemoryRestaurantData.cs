using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian},
                new Restaurant() { Id = 2, Name = "Mr. Hamburger", Location = "Strzemki", Cuisine = CuisineType.None},
                new Restaurant() { Id = 3, Name = "Papa Diego", Location = "Katowice", Cuisine = CuisineType.Mexican}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name).Select(r => r);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return GetAll();
            }

            return restaurants.OrderBy(r => r.Name)
                .Where(r => r.Name.StartsWith(name))
                .Select(r => r);
        }
    }
}
