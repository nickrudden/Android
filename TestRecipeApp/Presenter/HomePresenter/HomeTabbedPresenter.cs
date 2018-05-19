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
            List<string> model = new List<string>();
            try
            {
                model = db.userSavedRecipes(userId);
                view.setSavedRecipes(model);
                Console.WriteLine("THE COUNT IS  in the prezenta" + model.Count);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred in set user saved recipes + "  + ex.Message);
                view.setSavedRecipes(new List<string>());
                
            }
        }
        public void setUserSavedRecipes(string facebookId)
        {
            List<string> model = new List<string>();
            model = db.facebookUserSavedRecipe(facebookId);
            if (model.Count > 0)
                view.setSavedRecipes(model);
            else
                view.setSavedRecipes(new List<string>());

        }
    }
}