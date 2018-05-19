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
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.Models;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter.FavouritesPresenter;
using TestRecipeApp.Views.Activities;

namespace TestRecipeApp.Views.Fragments
{
    public class FavouriteRecipesFragment : Android.Support.V4.App.Fragment, IFavouriteView
    {
        RecyclerView recycler;
        RecyclerView.LayoutManager layoutManager;
        FavouritesRecyclerAdapter adapter;

        ProgressBar progressBar;
        FavouritesPresenter presenter;
        List<string> favouriteIds;

        ListView lv;
        public static FavouriteRecipesFragment newInstance()
        {
            FavouriteRecipesFragment frag = new FavouriteRecipesFragment();
            Bundle args = new Bundle();
           
            return frag;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            presenter = new FavouritesPresenter(this);
            ISharedPreferences pref = PreferenceManager.GetDefaultSharedPreferences(this.Context);
            ICollection<string> savedIds = pref.GetStringSet("savedIds", null);
            Console.WriteLine("collection count is " + savedIds.Count);


            favouriteIds = savedIds.Cast<string>().ToList();
             layoutManager = new GridLayoutManager(this.Context, 3, GridLayoutManager.Vertical, false);
            //layoutManager = new LinearLayoutManager(this.Context);
           
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.SupportFragmentFavouriteRecipes, container, false);


            recycler = view.FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            recycler.SetLayoutManager(layoutManager);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            ThreadPool.QueueUserWorkItem(o => presenter.updateFavourites(favouriteIds));

            return view;
        }

        public void populate(List<RecipeItemModel> list)
        {
            using (var handler = new Handler(Looper.MainLooper))
            {
                handler.Post(() => {
                   
                
                    adapter = new FavouritesRecyclerAdapter(list, this.Context);
                    adapter.ItemClick += OnItemClick;
                    recycler.SetAdapter(adapter);
                    adapter.NotifyDataSetChanged();
                    progressBar.Visibility = ViewStates.Gone;
                });
            }
        }


        void OnItemClick(object sender, RecipeEventArgs args)
        {

            Intent i = new Intent(this.Context, typeof(ViewRecipeActivity));
            i.PutExtra("Recipe", args.Id);
            i.PutExtra("PhotoUrl", args.ImageUrl);
            StartActivity(i);


        }
    }
}