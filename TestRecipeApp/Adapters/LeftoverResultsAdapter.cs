﻿using System;
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
using Square.Picasso;
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
        
        string type = "";

        public event EventHandler<RecipeEventArgs> ItemClick;
        Context context;
        public LeftoverResultsAdapter(List<LeftoverSearchModel> list, Context con)
       {
           this.recipes = list;
            context = con;
           
       }

        
        public override int ItemCount => recipes.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecipeViewHolder h = (RecipeViewHolder)holder;
            Picasso.With(context).Load(recipes[position].Image).Into(h.Photo);
            //h.Photo.SetImageDrawable(ImageManager.Get(recipes[position].Image));
            h.Title.Text = recipes[position].Title;
           
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