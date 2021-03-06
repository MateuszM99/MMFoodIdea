﻿using MMFI_Data.Data;
using MMFI_Entites.Models;
using MMFI_IServices;
using MMFoodIdea.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MMFI_Services

{

   public class IdeaServices : IIdeaServices
   {
       private readonly IngridientsDbContext _ingridientsDb;
       private readonly ApplicationDbContext _appDb;

       public IdeaServices(IngridientsDbContext ingridientsDb, ApplicationDbContext appDb)
       {
           _ingridientsDb = ingridientsDb;
           _appDb = appDb;
       }
       public List<Ingridient> AddIngridient(List<Ingridient> ingridients)
       {
           throw new NotImplementedException();
       }

      public List<Recipe> FindRecipes(List<Ingridient> ingridients, int time)
      {

            // List<Recipe> recipes = _appDb.Recipes.Where(r => r.RecipeTime <= time &&  IsViable(ingridients,r.Ingridients)).ToList();

            //  return recipes;
            return null;
       }

       public List<Ingridient> RemoveIngridient(List<Ingridient> ingridients)
       {
           throw new NotImplementedException();
       }

       public List<Ingridient> SearchIngridient(string n)
       {
          List<Ingridient> ingridients = 
               _ingridientsDb.Ingridients.Where(i => i.Name.Contains(n)).ToList();

          return ingridients;
       }

       public Ingridient SearchIngridient(int id)
       {
           Ingridient ingridient =
                _ingridientsDb.Ingridients.FirstOrDefault(i => i.IngridientId == id);

           return ingridient;
       }


       private bool IsViable(List<Ingridient> ingridients, List<Ingridient> recipeIngridients)
       {
           // If there is more ingridients in recipe than one has the recipe is unavailable
           if (recipeIngridients.Count() > ingridients.Count())
               return false;

           // If there is some ingridient that is in recipeIngridients and is not in ingridients the recipe is unavailable
           foreach (Ingridient i in recipeIngridients) 
           {
               if (!ingridients.Contains(i))
                   return false;
           }

           return true;
       }

   }
}


