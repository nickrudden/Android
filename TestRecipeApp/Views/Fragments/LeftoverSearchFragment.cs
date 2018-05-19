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
using RecipeClassLibrary.Models;
using TestRecipeApp.Utilites;
using TestRecipeApp.Views.Activities;

namespace TestRecipeApp.Views.Fragments
{
    public class LeftoverSearchFragment : Android.Support.V4.App.Fragment
    {
        TextView searchClick;
        ApplicationState appState;
        public static LeftoverSearchFragment newInstance()
        {
            LeftoverSearchFragment fragment = new LeftoverSearchFragment();
            Bundle args = new Bundle();
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            appState = new ApplicationState(this.Context);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.SupportFragmentLayoutLeftoverSearchPage, container, false);
            searchClick = view.FindViewById<TextView>(Resource.Id.SearchLeftoversButton);
            searchClick.Click += SearchClick_Click;
            Toast.MakeText(this.Context, "fb + " + appState.isFacebookLoggedIn().ToString(), ToastLength.Long).Show
              ();
            Toast.MakeText(this.Context, "Uid " + appState.UserId.ToString(), ToastLength.Long).Show
                ();
            Toast.MakeText(this.Context, appState.Guest.ToString(), ToastLength.Long).Show
                ();

            return view;
            
        }

        private void SearchClick_Click(object sender, EventArgs e)
        {
           
            var intent = new Intent(this.Context, typeof(LeftoverSearchViewActivity));
            // intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
            StartActivity(intent);
        }
    }
}