using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSharingAPI.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<RecipeIngredient>? RecipeIngredients { get; set;}

    }
}