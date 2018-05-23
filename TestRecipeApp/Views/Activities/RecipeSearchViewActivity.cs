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
using Android.Views;
using Android.Widget;
using TestRecipeApp.Adapters;
using TestRecipeApp.Presenter.SearchPresenter;
using TestRecipeApp.Utilites;

namespace TestRecipeApp.Views.Activities
{
    [Activity(Label = "RecipeSearchViewActivity")]
    public class RecipeSearchViewActivity : BaseActivity, ISearchView, IDataListener
    {
        ApplicationState state;
        private SearchView searchView;
        private CustomSearchAdapter searchAdapter;
        private ListView listView;
        private SearchPresenter presenter;

        string diet;
        string intoleranceString;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            diet = Intent.GetStringExtra("diet");
            IList<string> intolerances = Intent.GetStringArrayListExtra("intolerances");
            intoleranceString = string.Join(" ", intolerances.ToArray());
            


            SetContentView(Resource.Layout.ActivityLayoutRecipeSearchView);
            state = new ApplicationState(this);
            presenter = new SearchPresenter(this);
            listView = FindViewById<ListView>(Resource.Id.listView);
            searchView = FindViewById<SearchView>(Resource.Id.searchView);
            searchAdapter = new CustomSearchAdapter(this);
            listView.Adapter = searchAdapter;
            searchView.QueryTextChange += SearchView_QueryTextChange;
            searchView.QueryTextSubmit += SearchView_QueryTextSubmit;
            searchView.SetIconifiedByDefault(false);
            presenter.connect();
            // Create your application here
        }

        private void SearchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            Intent intent = new Intent(this, typeof(RecipeSearchResultsActivity));
            
          
            intent.PutExtra("diet", diet);
            intent.PutExtra("intolerance", intoleranceString);
            Toast.MakeText(this, e.Query, ToastLength.Short).Show();
            intent.PutExtra("query", e.Query);
            StartActivity(intent);
        }

        private void SearchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(o => presenter.UpdateRecipeSearchItems(e.NewText));
            }
            catch (Exception ex) { 
            this.Recreate();
        }
            
        }

        public void onSuccess(string data)
        {
            searchView.SetQuery(data, false);
            searchAdapter.clearList();
            searchAdapter.NotifyDataSetChanged();
        }

        public void updateSearchView(List<string> newItems)
        {
            using (var h = new Handler(Looper.MainLooper))
            {
                h.Post(() =>
                {
                    searchAdapter.setList(newItems);
                    searchAdapter.NotifyDataSetChanged();
                });
            }
        }

       
    }
}