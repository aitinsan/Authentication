using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.DTOs
{
    public class MealDTO
    {
        public string Name { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Price { get; set; }
        public Guid MealCategoryId { get; set; }
    }
}
