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

namespace TestRecipeApp.Presenter.RecipeSearchPresenter
{

    class RecipeSearchPresenter
    {
        private RecipeAPI db;
        ISearchResult context;
        public RecipeSearchPresenter(ISearchResult res)
        {
            db = new RecipeAPI();
            context = res;
        }

        public void getLeftoverRecipes(IList<string> ingred)
        {
            List<LeftoverSearchModel> results = new List<LeftoverSearchModel>();
            string searchString = "";
            foreach (var item in ingred)
            {
                searchString += item + ",";
            }
            try
            {
                //return db.leftOverSearch(searchString);
                context.searchResults(db.leftOverSearch(searchString));
            }
            catch(Exception ex)
            {

            }
            
        }

        public void getRecipeResults(string text, string diet, string intolerances)
        {
            List<KeywordSearchModel> model = new List<KeywordSearchModel>();
            try
            {
                context.searchRecipeResults(db.keywordSearch(text, 0, 100, diet, intolerances));
            }
            catch(Exception ex)
            {

            }
        }


    }
}