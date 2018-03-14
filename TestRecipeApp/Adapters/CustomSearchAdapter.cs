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
using TestRecipeApp.Utilites;
namespace TestRecipeApp.Adapters
{
    class CustomSearchAdapter : BaseAdapter<string>
    {

        private List<String> ingredients;
        private IDataListener<string> listener;

        public CustomSearchAdapter(IDataListener<string> listener)
        {
            this.listener = listener;
            ingredients = new List<string>();
        }
        public override string this[int position] => ingredients[position];

        public override int Count => ingredients.Count;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Android.Resource.Layout.SimpleListItem1, parent, false);
            TextView txt = (TextView)view.FindViewById(Android.Resource.Id.Text1);
            txt.Text = ingredients[position];

            view.Click += (sender, e) =>
            {
                listener.onSuccess(ingredients[position]);
            };
            return view;
        }

        public void setList(List<string> newL)
        {
            ingredients = new List<string>();
            foreach (var item in newL)
            {
                ingredients.Add(item);
            }
        }

        public void clearList()
        {
            ingredients = new List<string>();
        }
    }
}