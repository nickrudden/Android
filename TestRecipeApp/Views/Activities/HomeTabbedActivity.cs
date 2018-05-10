using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using RecipeClassLibrary.RecipeFunctions;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter.HomePresenter;
using TestRecipeApp.Views.Fragments;
namespace TestRecipeApp.Views.Activities
{
    [Activity(Label = "ReciMe", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class HomeTabbedActivity : AppCompatActivity, IHomeTabbed
    {
        FragmentPagerAdapter adapterPager;
        ISharedPreferences preferences;
        bool loggedIn;
        bool facebookUser;
        int uId;
        
        HomeTabbedPresenter presenter;
        List<string> checkedIds;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            checkedIds = new List<string>();
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLayoutHomeTabbed);
            presenter = new HomeTabbedPresenter(this);
            preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            loggedIn = preferences.GetBoolean("loggedIn", false);
            facebookUser = preferences.GetBoolean("facebook", false);
            uId = preferences.GetInt("uId", 999);
            Toast.MakeText(this, loggedIn.ToString(), ToastLength.Short).Show();
            Toast.MakeText(this, facebookUser.ToString(), ToastLength.Short).Show();
            Toast.MakeText(this, uId.ToString(), ToastLength.Short).Show();
            //Set view to layout containing a frame layout filling page.

            ViewPager pager = (ViewPager)FindViewById(Resource.Id.vpPager);
            adapterPager = new HomePagerAdapter(SupportFragmentManager);
            pager.Adapter = adapterPager;

            TabLayout tabLayout = (TabLayout)FindViewById(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(pager);

            if (loggedIn)
            {
                if (facebookUser)
                {
                    preferences = PreferenceManager.GetDefaultSharedPreferences(this);
                    string id = preferences.GetString("facebookId", "0");
                    ThreadPool.QueueUserWorkItem(o => presenter.setUserSavedRecipes(id));
                }
                else
                    ThreadPool.QueueUserWorkItem(o => presenter.setUserSavedRecipes(uId));
            }
                
            // Create your application here
        }

        public void checkboxClick(View view)
        {

        }

        public void setSavedRecipes(List<string> savedRecipes)
        {
            if (savedRecipes.Count > 0)
            {
                preferences.Edit().PutStringSet("savedIds", savedRecipes).Commit();
                foreach (var item in savedRecipes)
                {
                    Toast.MakeText(this, item, ToastLength.Long).Show();
                }
            }
            else
                preferences.Edit().PutStringSet("savedIds", new List<string>()).Commit();
        }
    }
}


