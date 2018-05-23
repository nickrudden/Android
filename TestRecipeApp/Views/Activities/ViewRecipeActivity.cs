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
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.Models;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter;
using TestRecipeApp.Presenter.RecipeInteractionPresenter;
using TestRecipeApp.Presenter.RecipeSearchPresenter;
using TestRecipeApp.Presenter.ViewRecipePresenter;
using TestRecipeApp.Utilites;
using TestRecipeApp.Views.Fragments;
using static Android.Widget.ImageView;

namespace TestRecipeApp.Views.Activities
{
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class ViewRecipeActivity : BaseActivity , IViewRecipeEvents
    {
        ApplicationState state;
        ViewPager vp;
        TabLayout tabs;
        ImageView RecipeImageView;
        ImageView FavouriteButton;
        ImageView ReviewButton;
        ProgressBar pb;

        bool facebook;
        string photoUrl;
        string currentRecipe;
        bool loggedIn;
        RecipeInteractionPresenter presenter;
        RecipePagerAdapter pagerAdapter;
        ISharedPreferences prefs;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            string recipeId = Intent.GetStringExtra("Recipe");
            photoUrl = Intent.GetStringExtra("PhotoUrl");
            if (String.IsNullOrEmpty(recipeId))
                Finish();
            
            prefs  = PreferenceManager.GetDefaultSharedPreferences(this);
            state = new ApplicationState(this);
            currentRecipe = recipeId;
            base.OnCreate(savedInstanceState);
            
            SetContentView(Resource.Layout.ActivityLayoutViewRecipe);

            presenter = new RecipeInteractionPresenter(this);
            pb = FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            RecipeImageView = FindViewById<ImageView>(Resource.Id.RecipeImage);
            RecipeImageView.SetScaleType(ScaleType.FitXy);
            vp = FindViewById<ViewPager>(Resource.Id.vpPager);
            pagerAdapter = new RecipePagerAdapter(this, SupportFragmentManager, recipeId);
            
            vp.Adapter = pagerAdapter;
            tabs = (TabLayout)(FindViewById(Resource.Id.sliding_tabs));
            tabs.SetupWithViewPager(vp);
           
            RecipeImageView.SetImageDrawable(ImageManager.Get(photoUrl));
            pb.Visibility = ViewStates.Gone;

           
            FavouriteButton = FindViewById<ImageView>(Resource.Id.Favourite);
            FavouriteButton.Click += FavouriteButton_Click;
            setSavedReviewButtonState();

            ReviewButton = FindViewById<ImageView>(Resource.Id.Review);
            ReviewButton.Click += ReviewButton_Click;

        }

        private void ReviewButton_Click(object sender, EventArgs e)
        {
            
            
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogReview review = new DialogReview();
            review.Show(transaction, "Review");
        }

        private void FavouriteButton_Click(object sender, EventArgs e)
        {
            Toast.MakeText(this, state.FacebookId, ToastLength.Long).Show();
            
            if (!state.isLoggedIn())
            {
                Toast.MakeText(this, "Log in to save your favourite recipes", ToastLength.Long).Show();
                return;
            }

            facebook = prefs.GetBoolean("facebook", false);
            if (state.isFacebookLoggedIn())
            {
               Toast.MakeText(this, "Adding to the threadpool", ToastLength.Long).Show();
                string fbId = state.FacebookId;
                ThreadPool.QueueUserWorkItem(o => presenter.saveRecipeClick(this, currentRecipe, fbId));
            }
            else
            {
                int uId = prefs.GetInt("uId", 0);
                ThreadPool.QueueUserWorkItem(o => presenter.saveRecipeClick(this, currentRecipe, uId));
            }
        }

        public void recipeSaveSuccess(bool success)
        {
            throw new NotImplementedException();
        }

        public void confirmReview()
        {
            throw new NotImplementedException();
        }

        public void setSavedReviewButtonState()
        {
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(this);
            ICollection<string> savedIds = pref.GetStringSet("savedIds", null);
            List<string> trimmedIds = new List<string>();
            foreach (var item in savedIds)
            {
                string newItem = item.Trim();
                trimmedIds.Add(newItem);
            }
            if (trimmedIds.Contains(currentRecipe))
            {
                Toast.MakeText(this, "RECIPE IS IN FAVOURITES", ToastLength.Long).Show();
                FavouriteButton.SetBackgroundResource(Resource.Drawable.ButtonReviewStateSelected);
            }

        }

       
    }
}
