using System.Collections.Generic;
using System.Linq;
using OdeToFood.Core;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }
        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = db.Restaurants.Where(r => r.Name.StartsWith(name) || string.IsNullOrEmpty(name))
                                      .OrderBy(r => r.Name)
                                      .Select(r => r)
                                      .AsEnumerable();

            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var query = db.Restaurants.Attach(updatedRestaurant);
            query.State = EntityState.Modified;

            return updatedRestaurant;
        }
    }
}
