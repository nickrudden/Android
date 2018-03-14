using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using TestRecipeApp.Adapters;
using TestRecipeApp.Views.Fragments;
namespace TestRecipeApp.Views.Activities
{
    [Activity(Label = "ReciMe")]
    public class HomeTabbedActivity : AppCompatActivity
    {
        FragmentPagerAdapter adapterPager;

        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLayoutHomeTabbed);
            //Set view to layout containing a frame layout filling page.

            ViewPager pager = (ViewPager)FindViewById(Resource.Id.vpPager);
            adapterPager = new HomePagerAdapter(SupportFragmentManager);
            pager.Adapter = adapterPager;

            TabLayout tabLayout = (TabLayout)FindViewById(Resource.Id.sliding_tabs);
            tabLayout.SetupWithViewPager(pager);
            // Create your application here
        }


        

    }
}


