using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Lang;
using RecipeClassLibrary.Models;
using TestRecipeApp.Utilites;

namespace TestRecipeApp.Adapters
{

    public class RecipeEventArgs : EventArgs
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public RecipeEventArgs(string id, string image) : base()
        {
            Id = id;
            ImageUrl = image;
        }
    }

    public class LeftoverResultsAdapter : RecyclerView.Adapter, IClickListener
    {
        public List<LeftoverSearchModel> recipes;
        public event EventHandler<RecipeEventArgs> ItemClick;
      
        public LeftoverResultsAdapter(List<LeftoverSearchModel> list)
       {
           this.recipes = list;
       }

        public override int ItemCount => recipes.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecipeViewHolder h = (RecipeViewHolder)holder;
            h.Photo.SetImageDrawable(ImageManager.Get(recipes[position].Image));
            h.Title.Text = recipes[position].Title;
            h.MissedIngredients.Text = recipes[position].UsedIngredientCount.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.LeftoverCardView, parent, false);
           
            var viewHolder = new RecipeViewHolder(view, this);
            return viewHolder;
        }

        
        void IClickListener.OnClick(int position)
        {
            RecipeEventArgs args = new RecipeEventArgs(recipes[position].Id, recipes[position].Image);
            if (ItemClick != null)
                ItemClick.Invoke(this, args);
        }
    }

   
}