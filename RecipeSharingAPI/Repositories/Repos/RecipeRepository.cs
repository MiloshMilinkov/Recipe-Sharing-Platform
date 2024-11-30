using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeSharingAPI.Data;
using RecipeSharingAPI.Models;
using RecipeSharingAPI.Repositories.Interfaces;

namespace RecipeSharingAPI.Repositories.Repos
{
    public class RecipeRepository : IRecipeRepository
    {

        private readonly RecipeDbContext _context;

        public RecipeRepository(RecipeDbContext recipeDbContext){
            _context = recipeDbContext;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(){
            return await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(r => r.Ingredient)
                .ToListAsync();
        }

        public async Task<Recipe?> GetRecipeByIdAsync(int id){
            return await _context.Recipes
                .Include(r => r.RecipeIngredients)
                .ThenInclude(ri => ri.Ingredient)
                .FirstOrDefaultAsync(r => r.RecipeId == id);
        }

        public async Task AddRecipeAsync(Recipe recipe){
            if (recipe == null){
                return;
            }
            await _context.Recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();
        }

        public async Task<Recipe?> UpdateRecipeAsync(Recipe recipe){
            if (recipe == null){
                return null;
            }
            _context.Recipes.Update(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task DeleteRecipeAsync (int id){
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.RecipeId == id);
            if(recipe != null){
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
            }
        }
    }
}