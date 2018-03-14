using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TestRecipeApp.Views.Fragments;

namespace TestRecipeApp.Adapters
{
    class HomePagerAdapter: FragmentPagerAdapter
    {
        private int tabbedItems = 3;
        private string[] tabNames = { "Leftovers", "Recipe Search", "Favourites" };
        public HomePagerAdapter(Android.Support.V4.App.FragmentManager fManager) : base(fManager)
        {

        }

        public override int Count => tabbedItems;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return LeftoverSearchFragment.newInstance();
                case 1:
                    return RecipeSearchFragment.newInstance();
                case 2:
                    return RecipeSearchFragment.newInstance();
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