using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Java.Lang;
using static Android.Support.V7.Widget.SearchView;
using static Android.Widget.TextView;

namespace TestRecipeApp.Utilites
{
    public class MySearchView : Android.Support.V7.Widget.SearchView
    {

        IOnQueryTextListener listener;

        SearchAutoComplete text;

        public MySearchView(Context context) : base(context) { }
        public MySearchView(Context context, IAttributeSet attrs) : base(context, attrs) { }
        public MySearchView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr) { }


        public override void SetOnQueryTextListener(IOnQueryTextListener listener)
        {
            

            base.SetOnQueryTextListener(listener);
            this.listener = listener;
            text = (SearchAutoComplete)FindViewById(Resource.Id.search_src_text);

            text.EditorAction += (sender, args) =>
            {
                if (listener != null)
                {
                    
                    listener.OnQueryTextSubmit(this.Query.ToString());
                }
               
            };
           



        }


    }

}