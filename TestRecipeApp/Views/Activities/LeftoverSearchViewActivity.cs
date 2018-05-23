using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.View;
using TestRecipeApp.Presenter.SearchPresenter;
using TestRecipeApp.Adapters;
using System.Threading;
using Android.Views.InputMethods;
using Android.Util;
using TestRecipeApp.Utilites;
using Android.Support.V7.Widget;

namespace TestRecipeApp.Views.Activities
{
    [Activity( ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LeftoverSearchViewActivity : BaseActivity, ISearchView, IDataListener
    {

        ApplicationState state;
        SearchPresenter presenter;
        List<string> selectedIngredients;
        private MySearchView searchView;
        CustomSearchAdapter adapter;
        GridView gridView;
        GridAdapter gridAdapter;
        private ListView listView;
          
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            state = new ApplicationState(this);
            SetContentView(Resource.Layout.ActivityLayoutLeftoversSearchView);
            // Create your application here
            presenter = new SearchPresenter(this);
            selectedIngredients = new List<string>();
            
            gridView = FindViewById<GridView>(Resource.Id.GridViewChosen);
            gridAdapter = new GridAdapter(this);
            gridView.Adapter = gridAdapter;
            
            gridView.ItemLongClick += GridView_ItemLongClick;

            listView = FindViewById<ListView>(Resource.Id.listView);
            searchView = FindViewById<MySearchView>(Resource.Id.searchView);
         
            adapter = new CustomSearchAdapter(this);         
            listView.Adapter = adapter;

            

            
            searchView.QueryTextChange += SearchView_QueryTextChange;
            searchView.QueryTextSubmit += SearchView_QueryTextSubmit;
           
            searchView.SetIconifiedByDefault(false);
            makeInitialConnection();

           
         
        }

        private void GridView_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            try
            {
                selectedIngredients.RemoveAt(e.Position);
                gridAdapter.setList(selectedIngredients);
                gridAdapter.NotifyDataSetChanged();
            }
            catch(Exception)
            {
                return;
            }

        }

        

        private void makeInitialConnection()
        {
            ThreadPool.QueueUserWorkItem(o => presenter.connect());
        }

        private void SearchView_QueryTextSubmit(object sender, Android.Support.V7.Widget.SearchView.QueryTextSubmitEventArgs e)
        {
            
            //Toast.MakeText(this, "helllooo", ToastLength.Long).Show();
            var intent = new Intent(this, typeof(LeftoverSearchResultsActivity));
            intent.PutStringArrayListExtra("Ingredients", selectedIngredients);
            StartActivity(intent);

           
        }

        //user inputs something
        private void SearchView_QueryTextChange(object sender, Android.Support.V7.Widget.SearchView.QueryTextChangeEventArgs e)
        {
            try
            {
                ThreadPool.QueueUserWorkItem(o => presenter.UpdateLeftoverSearchViewItems(e.NewText));
            }
            catch (Exception ex)
            {
                this.Recreate();
            }//e.Handled = true;
        }


        //Called from presenter to update the search lisr
        public void updateSearchView(List<string> newItems)
        {
            // use the Mainlooper to update the Main thread when API call is completed
            using (var h = new Handler(Looper.MainLooper))
            { 
                h.Post(() => {
                    adapter.setList(newItems);
                    adapter.NotifyDataSetChanged();
                    });               
            }
        }

        //List item clicked
        public void onSuccess(string data)
        {
            selectedIngredients.Add(data);
            
            adapter.clearList();
            searchView.SetQuery("", false);
            adapter.NotifyDataSetChanged();
       
            gridAdapter.setList(selectedIngredients);
            gridAdapter.NotifyDataSetChanged();
        }

        public void onFailure()
        {
            throw new NotImplementedException();
        }

       


    }

    

   
    /// <summary>
    /// //////////
    /// </summary>




}