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

namespace TestRecipeApp.Views.Activities
{
    [Activity(Label = "ViewRecipeActivity")]
    public class ViewRecipeActivity : AppCompatActivity
    {
        ViewPager vp;
        TabLayout tabs;
        ImageView RecipeImageView;
        Button FavouriteButton;
        Button ReviewButton;
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

            vp = FindViewById<ViewPager>(Resource.Id.vpPager);
            pagerAdapter = new RecipePagerAdapter(this, SupportFragmentManager ,recipeId);
            Toast.MakeText(this, "ID is " + recipeId, ToastLength.Long).Show();
            vp.Adapter = pagerAdapter;
            tabs =  (TabLayout)(FindViewById(Resource.Id.sliding_tabs));
            tabs.SetupWithViewPager(vp);
            pb.Visibility = ViewStates.Gone;
            RecipeImageView.SetImageDrawable(ImageManager.Get(photoUrl));
            

        }





        
    }
}