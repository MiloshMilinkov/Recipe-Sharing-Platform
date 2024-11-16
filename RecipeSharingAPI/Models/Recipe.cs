using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSharingAPI.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; } 
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<RecipeIngredient>? RecipeIngredients { get; set;}
    }

}