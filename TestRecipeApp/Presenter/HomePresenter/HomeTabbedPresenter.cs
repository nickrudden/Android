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
using RecipeClassLibrary.Models;
using RecipeClassLibrary.RecipeFunctions;

namespace TestRecipeApp.Presenter.HomePresenter
{
    public class HomeTabbedPresenter
    {
        IHomeTabbed view;
        DatabaseApi db;

        public HomeTabbedPresenter(IHomeTabbed i)
        {
            view = i;
            db = new DatabaseApi();
        }

        public void setUserSavedRecipes(int userId)
        {
            List<SaveRecipeModel> model = new List<SaveRecipeModel>();
            model = db.userSavedRecipes(userId);
            if (model.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (var item in model)
                {
                    ids.Add(item.RecipeId);
                }
                view.setSavedRecipes(ids);
            }
        }
        public void setUserSavedRecipes(string facebookId)
        {
            List<FacebookSaveRecipeModel> model = new List<FacebookSaveRecipeModel>();
            model = db.facebookUserSavedRecipe(facebookId);
            if (model.Count > 0)
            {
                List<string> ids = new List<string>();
                foreach (var item in model)
                {
                    ids.Add(item.RecipeId);
                }

                view.setSavedRecipes(ids);
            }
        }


    }
}