
using Authentication.Authentication;
using Authentication.Models;
using Authentication.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Repositories
{
    public class MealRepository:IMealRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MealRepository(ApplicationDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Meal> GetMeals()
        {
            return _dbContext.Meals.Include(x => x.Category).OrderBy(x => x.Price);
        }

        public bool AddMeal(Meal m)
        {
            _dbContext.Add(m);
            return _dbContext.SaveChanges() > 0;
        }

        public IQueryable<Meal> GetMealByCategory(Guid categoryId)
        {
            return _dbContext.Meals.Where(x=>x.MealCategoryId==categoryId);
        }
    }
}
