
using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Repositories.Interfaces
{
    public interface IMealRepository
    {
        public IQueryable<Meal> GetMeals();
        public bool AddMeal(Meal m);
        public IQueryable<Meal> GetMealByCategory(Guid categoryid);
    }
}
