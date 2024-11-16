using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipeSharingAPI.Models;

namespace RecipeSharingAPI.Data
{
    public class RecipeDbContext : DbContext
    {
        public RecipeDbContext(DbContextOptions<RecipeDbContext> options) : base(options){}

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            //Recipe
            modelBuilder.Entity<Recipe>()
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Recipe>()
                .Property(r => r.Description)
                .HasMaxLength(500);


            //RecipeIngredient
            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ck => new { ck.RecipeId, ck.IngredientId }); 

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

             //Ingridient
            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

        }
    }
}