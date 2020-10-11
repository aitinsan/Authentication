using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.Authentication;
using Authentication.DTOs;
using Authentication.Models;
using Authentication.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Authorize(Roles = UserRoles.Kassir)]
    [Route("api/[controller]")]
    [ApiController]
    public class MealCategoryController : ControllerBase
    {
        private readonly IMealCategoryRepository _mealCategoryRepository;

        public MealCategoryController(IMealCategoryRepository mealCategoryRepository)
        {
            _mealCategoryRepository = mealCategoryRepository;
        }

        [HttpGet]
        public IQueryable<MealCategory> GetMealCategories()
        {
            return _mealCategoryRepository.GetMealCategories();
        }
        [HttpPost]
        public ActionResult AddMealCategory(MealCategoryDTO mc)
        {
            MealCategory mealcat = new MealCategory()
            {
                Id = Guid.NewGuid(),
                Category = mc.Category,
            };

            if (_mealCategoryRepository.AddMealCategory(mealcat)) {
                return Ok("New Meal Category is added!");
            }
            return BadRequest("Oops, something went wrong!");
        }

    }
}
