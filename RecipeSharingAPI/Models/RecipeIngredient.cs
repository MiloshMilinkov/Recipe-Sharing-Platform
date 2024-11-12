using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSharingAPI.Models
{
    public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }

        public int IngredientId { get; set; }
        public Ingredient? Ingredient{ get; set; }

        public decimal Quantity { get; set; }
        public string? Unit { get; set; }
        public string? PreperationType { get; set; }
    }
}