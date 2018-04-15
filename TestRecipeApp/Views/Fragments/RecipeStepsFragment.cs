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
    public class RecipeStepsFragment : Android.Support.V4.App.Fragment, IRecipeView
    {
        string recipeId;
        ViewRecipePresenter presenter;
        StepsAdapter iAdapter;
        
        public static RecipeStepsFragment newInstance(string recipeId)
        {
            RecipeStepsFragment frag = new RecipeStepsFragment();
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
            iAdapter = new StepsAdapter(this.Context);

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

    public class StepsAdapter : BaseAdapter<SingleStepModel>
    {
        List<SingleStepModel> steps;
        Context context;
        TextView number;
        TextView step;
        public StepsAdapter(Context con)
        {
            context = con;
            steps = new List<SingleStepModel>();
        }
        public override SingleStepModel this[int position] => steps[position];
        public override int Count => steps.Count;
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(context).Inflate(Resource.Layout.StepsListItem, parent, false);
            }
            number = view.FindViewById<TextView>(Resource.Id.number);
            step = view.FindViewById<TextView>(Resource.Id.step);

            step.Text = steps[position].Step;
            number.Text = steps[position].Number.ToString();
            return view;
        }

        public void setList(RecipeItemModel mod)
        {
            if (mod.AnalyzedInstructions.Count > 0)
                steps = mod.AnalyzedInstructions[0].Steps;          
            this.NotifyDataSetChanged();
        }
    }
}