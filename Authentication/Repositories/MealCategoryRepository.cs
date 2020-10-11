
using Authentication.Authentication;
using Authentication.Models;
using Authentication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Repositories
{
    public class MealCategoryRepository:IMealCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MealCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<MealCategory> GetMealCategories()
        {
            return _dbContext.MealCategories.OrderBy(x => x.Category);
        }

        public bool AddMealCategory(MealCategory mo)
        {
            _dbContext.Add(mo);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
