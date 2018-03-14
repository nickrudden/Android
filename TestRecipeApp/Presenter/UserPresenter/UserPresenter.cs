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

using System.Net.Http;
using RecipeClassLibrary;
using RecipeClassLibrary.RecipeFunctions;

namespace TestRecipeApp.Presenter.UserPresenter
{
    class UserPresenter 
    {
        ILoginView loginView;
        DatabaseApi db;
        public UserPresenter(ILoginView view)
        {
            this.loginView = view;
            db = new DatabaseApi();
        }

        public void createUser(string email, string password)
        {
         
            Android.Util.Log.Error("myError", "In create user");
            bool success = db.createUser(email, password);
            Console.WriteLine("Success");
            Console.WriteLine("Success: " + success);


            if (success)
                loginView.confirmCreation();
            else
                loginView.creationError();
        }

        public void loginUser(string email, string password)
        {
            bool success = db.login(email, password);

            if (success)
                loginView.goToHome();
            else
                loginView.signInError();

        }
    }
}