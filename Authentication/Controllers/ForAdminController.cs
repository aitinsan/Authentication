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
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ForAdminController : ControllerBase
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMealCategoryRepository _mealCategoryRepository;
        [HttpPost("addmealcategory")]
        public ActionResult AddMealCategory(MealCategoryDTO mc)
        {
            MealCategory mealcat = new MealCategory()
            {
                Id = Guid.NewGuid(),
                Category = mc.Category,
            };

            if (_mealCategoryRepository.AddMealCategory(mealcat))
            {
                return Ok("New Meal Category is added!");
            }
            return BadRequest("Oops, something went wrong!");
        }
        [HttpPost("addmeal")]
        public ActionResult AddMeal(MealDTO md)
        {
            Meal m = new Meal()
            {
                Id = Guid.NewGuid(),
                Name = md.Name,
                Amount = md.Amount,
                Price = md.Price,
                MealCategoryId = md.MealCategoryId,
            };

            if (_mealRepository.AddMeal(m))
            {
                return Ok("A new meal was added successfully!");
            }
            return BadRequest("Oops, something went wrong with adding new meal!");
        }

    }
    
}
