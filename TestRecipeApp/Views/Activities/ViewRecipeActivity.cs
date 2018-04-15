using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.Models;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter.RecipeSearchPresenter;
using TestRecipeApp.Presenter.ViewRecipePresenter;
using static Android.Widget.ImageView;

namespace TestRecipeApp.Views.Activities
{
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ViewRecipeActivity : AppCompatActivity
    {
        ViewPager vp;
        TabLayout tabs;
        ImageView RecipeImageView;
        ImageView FavouriteButton;
        ImageView ReviewButton;
        ProgressBar pb;
        string photoUrl;
        
        
        RecipePagerAdapter pagerAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string recipeId = Intent.GetStringExtra("Recipe");
            photoUrl = Intent.GetStringExtra("PhotoUrl");
            if (String.IsNullOrEmpty(recipeId))
                Finish();


            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLayoutViewRecipe);

            pb = FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            RecipeImageView = FindViewById<ImageView>(Resource.Id.RecipeImage);
            RecipeImageView.SetScaleType(ScaleType.FitXy);
            vp = FindViewById<ViewPager>(Resource.Id.vpPager);
            pagerAdapter = new RecipePagerAdapter(this, SupportFragmentManager, recipeId);
            Toast.MakeText(this, "ID is " + recipeId, ToastLength.Long).Show();
            vp.Adapter = pagerAdapter;
            tabs = (TabLayout)(FindViewById(Resource.Id.sliding_tabs));
            tabs.SetupWithViewPager(vp);
           
            RecipeImageView.SetImageDrawable(ImageManager.Get(photoUrl));
            pb.Visibility = ViewStates.Gone;

            FavouriteButton = FindViewById<ImageView>(Resource.Id.Favourite);
            FavouriteButton.Click += FavouriteButton_Click;

        }

        private void FavouriteButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Hello...", ToastLength.Short).Show();
            FavouriteButton.SetImageResource(Resource.Drawable.GoldHeartIcon);
        }
    }
}
