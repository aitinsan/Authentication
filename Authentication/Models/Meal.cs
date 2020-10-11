using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class Meal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public Guid MealCategoryId { get; set; }
        public MealCategory Category { get; set; }

    }
}
