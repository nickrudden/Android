using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary;
using RecipeClassLibrary.Models;

namespace TestRecipeApp.Presenter.SearchPresenter
{
    public class SearchPresenter
    {
        ISearchView view;
        RecipeAPI db;

        public SearchPresenter(ISearchView view)
        {
            this.view = view;
          
            db = new RecipeAPI();
        }
        
        public void UpdateLeftoverSearchViewItems(string text)
        {
            List<string> results = new List<string>();
            List<DropDownIngredient> ingredients = db.getDropdownIngredients(text);
            foreach (var item in ingredients)
            {
                results.Add(item.Name);
            }         
            view.updateSearchView(results);
        }

        public void UpdateRecipeSearchItems(string keywords)
        {
            List<string> results = new List<string>();
            List<DropdownRecipe> model = db.getDropdownRecipes(keywords);
            foreach (var item in model)
            {
                results.Add(item.Title);
            }

            view.updateSearchView(results);
        }

        public void connect()
        {
            db.leftOverSearch("Hello");
        }


        
    }
}