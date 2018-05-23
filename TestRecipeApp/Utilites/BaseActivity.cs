using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using TestRecipeApp.Views.Activities;

namespace TestRecipeApp.Utilites
{
    public class BaseActivity : AppCompatActivity
    {
        private ApplicationState state;

        
           
            
        
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            state = new ApplicationState(this);
            SupportActionBar.Title = "ReciMe";
            MenuInflater.Inflate(Resource.Menu.top_menus, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Intent intent;
            switch (item.ItemId)
            {
                case Resource.Id.logoutoption:
                    state.logOut();
                    intent = new Intent(this, typeof(LoginActivity));
                    StartActivity(intent);
                    break;
                case Resource.Id.homeOption:
                    intent = new Intent(this, typeof(HomeTabbedActivity));
                    StartActivity(intent);
                    break;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}