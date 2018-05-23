using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook.Login;

namespace TestRecipeApp.Utilites
{
    
    public class ApplicationState
    {
        Context context;
        ISharedPreferences prefs;
        States logState;
        Type logType;
        public ApplicationState(Context con)
        {
            context = con;
            prefs = PreferenceManager.GetDefaultSharedPreferences(context);

            string id = prefs.GetString("facebookId", "0");
            int uId = prefs.GetInt("uId", 0);
            bool guest = prefs.GetBoolean("guest", true);
            if (id != null && id != "0")
            {
                logState = States.LOGGEDIN;
                logType = Type.FACEBOOK;
            }
            else if (uId != 0)
            {
                logState = States.LOGGEDIN;
                logType = Type.USER;
            }
            else if (guest)
            {
                logState = States.LOGGEDOUT;
                logType = Type.GUEST;
            }
            


        }

        public bool isLoggedIn()
        {
           

            int uId = prefs.GetInt("uId", 0);

            if (isFacebookLoggedIn() || uId != 0)
                return true;
            else return false;
        }

        public bool isFacebookLoggedIn()
        {
            string id = prefs.GetString("facebookId", "0");
            if (id != null && id != "0")
                return true;
            else
                return false;
        }

        private string facebookId;
        public string FacebookId {
            get {
                string id = prefs.GetString("facebookId", "0");
                return id;
            }
            set { facebookId = value;
                prefs.Edit().PutString("facebookId", facebookId).Commit();
                
            }
        }

        private int userId;
        public int UserId
        {
            get {
                int id = prefs.GetInt("uId", 0);
                return id;
            }

            set
            {
                int val = value;
                prefs.Edit().PutInt("uId", val).Commit();
            }
        }

        private bool guest;
        public bool Guest{

            get
            {
                bool guest = prefs.GetBoolean("guest", false);
                return guest;
            }
            set
            {
                bool guest = value;
                prefs.Edit().PutBoolean("guest", guest).Commit(); ;
            }

        }

        public void logOut()
        {
            prefs.Edit().PutString("facebookId", "0").Commit();
            prefs.Edit().PutInt("uId", 0).Commit();
            prefs.Edit().PutBoolean("guest", false).Commit();
            LoginManager.Instance.LogOut();
        }

      

        enum States{
            LOGGEDIN,
            LOGGEDOUT,

        }

        enum Type
        {
            FACEBOOK,
            USER,
            GUEST
        }
        
    }
}