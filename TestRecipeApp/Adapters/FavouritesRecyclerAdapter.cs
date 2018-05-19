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


    public class FavouritesRecyclerAdapter : RecyclerView.Adapter, IClickListener
    {
        public List<RecipeItemModel> recipeList;

        public event EventHandler<RecipeEventArgs> ItemClick;
        Context context;

        public FavouritesRecyclerAdapter(List<RecipeItemModel> list, Context con)
        {
            recipeList = list;
            context = con;
        }

        public override int ItemCount => recipeList.Count;

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.FavouriteCardView, null, true);
            var viewHolder = new RecipeViewHolder(view, this);
            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecipeViewHolder h = (RecipeViewHolder)holder;
            Picasso.With(context).Load(recipeList[position].Image).Into(h.Photo);
            h.Title.Text = recipeList[position].Title;
        }

        public void OnClick(int position)
        {
            RecipeEventArgs args = new RecipeEventArgs(recipeList[position].Id, recipeList[position].Image);
            if (ItemClick != null)
                ItemClick.Invoke(this, args);
        }

        public void setList(List<RecipeItemModel> newList)
        {
            this.recipeList = newList;
            this.NotifyDataSetChanged();
            
       
            
        }
    }
}