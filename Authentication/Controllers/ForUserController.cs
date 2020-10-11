using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Authentication;
using Authentication.Models;
using Authentication.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Authorize(Roles = UserRoles.User)]
    [Route("api/[controller]")]
    [ApiController]
    public class ForUserController : ControllerBase
    {
        private readonly IMealCategoryRepository _mealCategoryRepository;
        private readonly IMealRepository _mealRepository;
        [HttpGet("categories")]
        public IQueryable<MealCategory> GetMealCategories()
        {
            return _mealCategoryRepository.GetMealCategories();
        }
        [HttpGet("meals")]
        public IQueryable<Meal> GetMeals()
        {
            return _mealRepository.GetMeals();
        }

        [HttpGet("findby/{categoryid}")]
        public IQueryable<Meal> GetMealByCategory(Guid categoryId)
        {
            return _mealRepository.GetMealByCategory(categoryId);
        }
    }
}
