using MMFI_Entites.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MMFI_IServices
{
    public interface IIdeaServices
    {

        List<Ingridient> AddIngridient(List<Ingridient> ingridients);
        List<Ingridient> RemoveIngridient(List<Ingridient> ingridients);
        Ingridient SearchIngridient(string n);
        Ingridient SearchIngridient(int id);
        List<Recipe> FindRecipes(List<Ingridient> ingridients, int time);




    }
}
