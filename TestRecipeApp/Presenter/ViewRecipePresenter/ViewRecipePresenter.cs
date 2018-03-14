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

namespace TestRecipeApp.Presenter.ViewRecipePresenter
{
    public class ViewRecipePresenter
    {
        private RecipeAPI api;
        IRecipeView view;
        public ViewRecipePresenter(IRecipeView rv)
        {
            view = rv;
            api = new RecipeAPI();
        }

        public void getRecipeDetails(string id)
        {
            RecipeItemModel model = api.getRecipeByID(id);
            view.setRecipe(model);
        }
    }
}