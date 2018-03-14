using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestRecipeApp.Views.Fragments
{
    public class RecipeSearchFragment : Android.Support.V4.App.Fragment
    {
        TextView searchButton;

        public static RecipeSearchFragment newInstance()
        {
            RecipeSearchFragment fragment = new RecipeSearchFragment();
            Bundle args = new Bundle();
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.SupportFragmentLayoutRecipeSearchPage, container, false);
           
            return view;
        }

      
    }
}