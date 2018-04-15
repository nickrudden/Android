using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Lang;
using RecipeClassLibrary.Models;
using TestRecipeApp.Views.Fragments;

namespace TestRecipeApp.Adapters
{
    public class RecipePagerAdapter : FragmentPagerAdapter
    {
        private int tabbedItems = 3;
        private string[] tabNames = { "Details", "Ingredients", "Steps" };
        
        Context theContext;
        string id;

        public RecipePagerAdapter(Context con, Android.Support.V4.App.FragmentManager fManager, string recipeId) : base(fManager)
        {
            
            id = recipeId;
            theContext = con;
            
        }

        public override int Count => tabbedItems;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:              
                    return RecipeDetailsFragment.newInstance(id);
                case 1:
                    return RecipeIngredientsFragment.newInstance(id);
                case 2:                   
                    return RecipeStepsFragment.newInstance(id);
                default:
                    return null;
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            ICharSequence title = new Java.Lang.String(tabNames[position]);
            return title;
        }

    }
}