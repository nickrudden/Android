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
using Java.Lang;

namespace TestRecipeApp.Adapters
{
    public class GridAdapter : BaseAdapter
    {
        private Context context;
        List<string> items;

        public GridAdapter(Context context) 
        {
            items = new List<string>();
            this.context = context;
        }
        public override int Count => items.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return items[position];
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.GridAdapterGridItem, parent, false);
            TextView tv = view.FindViewById<TextView>(Resource.Id.textViewItem);

            tv.Text = items[position];
            return view;
        }

        public void setList(List<string> newItems)
        {
            items.Clear();
            foreach (var item in newItems)
            {
                items.Add(item);
            }
        }
    }
}