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
using Java.Lang;
using RecipeClassLibrary;
using RecipeClassLibrary.Models;
using TestRecipeApp.Presenter.ViewRecipePresenter;

namespace TestRecipeApp.Views.Fragments
{
    public class RecipeIngredientsFragment : Android.Support.V4.App.Fragment, IRecipeView
    {

        string recipeId;
        ViewRecipePresenter presenter;
        IngredientsAdapter iAdapter;
        public static RecipeIngredientsFragment newInstance(string recipeId)

        {
            RecipeIngredientsFragment frag = new RecipeIngredientsFragment();
            
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
            iAdapter = new IngredientsAdapter(this.Context);
            ThreadPool.QueueUserWorkItem(o => presenter.getRecipeDetails(recipeId));
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.RecipeIngredientsFragment, container, false);
            ListView list = view.FindViewById<ListView>(Resource.Id.ingredientsListView);         
            list.Adapter = iAdapter;                            
            return view;
        }


        public void setRecipe(RecipeItemModel mod)
        {
            using (Handler handler = new Handler(Looper.MainLooper))
            {
                handler.Post(() => {
                    iAdapter.setList(mod);
                });
            }
        }

    }

    public class IngredientsAdapter : BaseAdapter<SingleIngredientModel>
    {
        List<SingleIngredientModel> ingredients;
        Context context;

        TextView ingredient;
        TextView amount;
        TextView scale;
        public IngredientsAdapter(Context con)
        {
            ingredients = new List<SingleIngredientModel>();
            context = con;

        }

        public override SingleIngredientModel this[int position] => ingredients[position];

        public override int Count => ingredients.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.IngredientsListItem, parent, false);
            }
            ingredient = (TextView)view.FindViewById(Resource.Id.ingredient);
            amount = (TextView)view.FindViewById(Resource.Id.amount);
            scale = (TextView)view.FindViewById(Resource.Id.scale);

            ingredient.Text = ingredients[position].Name;
            amount.Text = ingredients[position].Amount;
            scale.Text = ingredients[position].Unit;

            return view;

        }

        public void setList(RecipeItemModel mod)
        {
            ingredients = mod.ExtendedIngredients;
            this.NotifyDataSetChanged();
        }

      
    }
}