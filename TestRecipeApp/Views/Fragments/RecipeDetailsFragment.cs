using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.Models;
using TestRecipeApp.Presenter.ViewRecipePresenter;

namespace TestRecipeApp.Views.Fragments
{
    public class RecipeDetailsFragment : Android.Support.V4.App.Fragment, IRecipeView
    {
        string recipeId;
        ViewRecipePresenter presenter;
       
        TextView title;
        TextView prep;
        TextView cook;
        TextView servings;

        ImageView vegetarian;
        ImageView vegan;
        ImageView gluten;
        ImageView dairy;

        public static RecipeDetailsFragment newInstance(string recipeId)
        {
            RecipeDetailsFragment frag = new RecipeDetailsFragment();
            Bundle args = new Bundle();
            args.PutString("Id", recipeId);
            frag.Arguments = args;
            return frag;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Bundle bundle = this.Arguments;
            recipeId = bundle.GetString("Id");
            presenter = new ViewRecipePresenter(this);
            
           ThreadPool.QueueUserWorkItem(o => presenter.getRecipeDetails(recipeId));
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.RecipeDetailsFragment, container, false);
            
            title = view.FindViewById<TextView>(Resource.Id.Title);
            prep = view.FindViewById<TextView>(Resource.Id.Prep);
            cook = view.FindViewById<TextView>(Resource.Id.Cook);
            servings = view.FindViewById<TextView>(Resource.Id.Servings);

            vegan = view.FindViewById<ImageView>(Resource.Id.veganCross);
            gluten = view.FindViewById<ImageView>(Resource.Id.glutenCross);
            vegetarian = view.FindViewById<ImageView>(Resource.Id.vegCross);
            dairy = view.FindViewById<ImageView>(Resource.Id.DairyCross);

            return view;
        }

        public void setRecipe(RecipeItemModel mod)
        {
            using (Handler handler = new Handler(Looper.MainLooper))
            {

                handler.Post(() => {
                    if (mod.Vegetarian) vegetarian.SetImageResource(Resource.Drawable.Tick);
                    if (mod.GlutenFree) gluten.SetImageResource(Resource.Drawable.Tick);
                    if (mod.Vegan) vegan.SetImageResource(Resource.Drawable.Tick);
                    if (mod.DairyFree) dairy.SetImageResource(Resource.Drawable.Tick);
                    title.Text = mod.Title;
                    cook.Text = mod.CookingMinutes.ToString();
                    prep.Text = mod.PreparationMinutes.ToString();
                    servings.Text = mod.Servings.ToString();
                    
                });
            }
        }
    }

   
}