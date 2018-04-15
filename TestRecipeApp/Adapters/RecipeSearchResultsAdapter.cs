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
using Android.Support.V7.Widget;
using TestRecipeApp.Utilites;
using RecipeClassLibrary.Models;
using Square.Picasso;

namespace TestRecipeApp.Adapters
{

    
    public class RecipeSearchEventArgs : EventArgs
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string ReadyInMinutes { get; set; }

        public RecipeSearchEventArgs(string id, string image, string ready) : base()
        {
            Id = id;
            ImageUrl = image;
            ReadyInMinutes = ready;
        }
    }

    public class RecipeSearchResultsAdapter : RecyclerView.Adapter, IClickListener
    {
        public List<KeywordSearchModel> recipeList;

        public event EventHandler<RecipeSearchEventArgs> ItemClick;
        Context context;

        public RecipeSearchResultsAdapter(List<KeywordSearchModel> list, Context con)
        {
            recipeList = list;
            context = con;
        }

        public override int ItemCount => recipeList.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.LeftoverCardView, parent, false);
            var viewHolder = new RecipeViewHolder(view, this);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecipeViewHolder h = (RecipeViewHolder)holder;
            Picasso.With(context).Load(recipeList[position].ImageUrls[0]).Into(h.Photo);
            h.Title.Text = recipeList[position].Title;
        }

        public void OnClick(int position)
        {
            RecipeSearchEventArgs args = new RecipeSearchEventArgs(recipeList[position].RecipeId, recipeList[position].ImageUrls[0], recipeList[position].ReadyInMinutes.ToString());
            if (ItemClick != null)
                ItemClick.Invoke(this, args);
        }
    }
}