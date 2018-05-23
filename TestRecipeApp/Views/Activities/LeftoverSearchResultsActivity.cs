using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary.Models;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter.RecipeSearchPresenter;
using TestRecipeApp.Utilites;

namespace TestRecipeApp.Views.Activities
{

    
    [Activity(ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LeftoverSearchResultsActivity : BaseActivity, ISearchResult
    {
        ApplicationState state;
        RecipeSearchPresenter presenter;
        RecyclerView resultView;
        RecyclerView.LayoutManager mLayoutManager;
        LeftoverResultsAdapter recyclerdAdapter;
        ProgressBar pb;

        public void searchRecipeResults(List<KeywordSearchModel> m)
        {
            throw new NotImplementedException();
        }

        public void searchResults(List<LeftoverSearchModel> m)
        {
            using (var handler = new Handler(Looper.MainLooper))
            {
                handler.Post(() => {
                    
                        recyclerdAdapter = new LeftoverResultsAdapter(m, this);
                        recyclerdAdapter.ItemClick += OnItemClick;
                        resultView.SetAdapter(recyclerdAdapter);
                        recyclerdAdapter.NotifyDataSetChanged();
                        pb.Visibility = ViewStates.Gone;                                     
                });
            }
                
        }
       


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            state = new Utilites.ApplicationState(this);
           
            SetContentView(Resource.Layout.ActivityLayoutLeftoverSearchResultsGrid);
            pb = FindViewById<ProgressBar>(Resource.Id.ProgressBar);
            resultView = FindViewById<RecyclerView>(Resource.Id.RecyclerResults);
            resultView.HasFixedSize = true;
          
            mLayoutManager = new GridLayoutManager(this, 2, GridLayoutManager.Vertical, false);
            resultView.SetLayoutManager(mLayoutManager);

            
            presenter = new RecipeSearchPresenter(this);

          
                IList<string> ing = Intent.GetStringArrayListExtra("Ingredients");
                ThreadPool.QueueUserWorkItem(o => presenter.getLeftoverRecipes(ing));
           
               
 
        }

        void OnItemClick(object sender, RecipeEventArgs args)
        {
            
            Intent i = new Intent(this, typeof(ViewRecipeActivity));
            i.PutExtra("Recipe", args.Id);
            i.PutExtra("PhotoUrl", args.ImageUrl);
            StartActivity(i);
             

        }

        
    }
}