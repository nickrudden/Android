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
using TestRecipeApp.Adapters;
using TestRecipeApp.Utilites;

namespace TestRecipeApp
{
    public class RecipeViewHolder :  RecyclerView.ViewHolder
    {
        public ImageView Photo { get; set; }
        public TextView Id { get; set; }
        public TextView Title { get; set; }
        public TextView MissedIngredients { get; set; }
        

        public RecipeViewHolder(View itemView, IClickListener listener) : base(itemView)
        {
            this.Photo = itemView.FindViewById<ImageView>(Resource.Id.photoImageView);
            this.Title = itemView.FindViewById<TextView>(Resource.Id.recipeNameTextView);
            
            //Set item click on viewholder and called listerners click method
            itemView.Click += (sender, e) => listener.OnClick(base.LayoutPosition);
         
        }
      
    }
}