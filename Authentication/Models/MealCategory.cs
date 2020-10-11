using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Authentication.Models
{
    public class MealCategory
    {
     public Guid Id { get; set; } //unique ID
     public string Category { get; set; } 
     public ICollection<Meal> Meals { get; set; }
    }
}
