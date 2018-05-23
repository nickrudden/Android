using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.RecipeFunctions;

namespace TestRecipeApp.Presenter.RecipeInteractionPresenter
{
    class RecipeInteractionPresenter
    {
        IViewRecipeEvents context;
        DatabaseApi db;

        public RecipeInteractionPresenter(IViewRecipeEvents i)
        {
            context = i;
            db = new DatabaseApi();
        }

        public void saveRecipeClick(Context con, string recipeId, int userId) {

            bool saved = false;
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(con);
            ICollection<string> savedIds = pref.GetStringSet("savedIds", null);
            if (savedIds != null)
            {
                foreach (var item in savedIds)
                {
                    if (item == recipeId)
                        saved = true;

                }
            }

            if (!saved)
            {
               
                
                db.saveUserRecipe(recipeId, userId);
                context.recipeSaveSuccess(true);
            }
            else
            {
                // REMOVE RECIPE
                context.recipeSaveSuccess(false);
            }
        }

        public void saveRecipeClick(Context con, string recipeId, string facebookId)
        {

            bool saved = false;
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(con);
            ICollection<string> savedIds = pref.GetStringSet("savedIds", null);
            foreach (var item in savedIds)
            {
                if (item == recipeId)
                    saved = true;

            }

            if (!saved)
            {
               
                db.saveFacebookRecipe(recipeId, facebookId);
            }
            else
            {
                // REMOVE RECIPE
                context.recipeSaveSuccess(false);
            }
        }
    }
}