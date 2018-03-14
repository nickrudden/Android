using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using TestRecipeApp.Presenter;
using TestRecipeApp.Presenter.UserPresenter;
using TestRecipeApp.Views.Fragments;

namespace TestRecipeApp.Views.Activities
{
    [Activity(Label = "ReciMe", MainLauncher =true)]
    public class LoginActivity : Activity, ILoginView
    {

        ISharedPreferences prefs; 
        private Button btnSignUp;
        private Button btnLoginIn;
        private Button btnGuest;
        private ProgressBar progBar;
        private UserPresenter presenter;
        private TextView textSuccess;
        private TextView textError;

        //private UserPresenter presenter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActivityLayoutLogin);

                
            presenter = new UserPresenter(this);
            btnSignUp = FindViewById<Button>(Resource.Id.btnRegister);
            btnLoginIn = FindViewById<Button>(Resource.Id.btnSignIn);
            btnGuest = FindViewById<Button>(Resource.Id.btnGuest);
            progBar = FindViewById<ProgressBar>(Resource.Id.progressBar1);
           

            btnSignUp.Click += BtnSignUp_Click;
            btnLoginIn.Click += BtnLoginIn_Click;
            btnGuest.Click += BtnGuest_Click;
            // Create your application here
        }

        private void BtnGuest_Click(object sender, EventArgs e)
        {
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            prefs.Edit().PutBoolean("loggedIn", false);
            var intent = new Intent(this, typeof(HomeTabbedActivity));
            StartActivity(intent);
        }

        //LOGIN
        private void BtnLoginIn_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignIn signInDialog = new DialogSignIn();
            signInDialog.Show(transaction, "Sign in");

            signInDialog.onSignInComplete += SignInDialog_onSignInComplete;
        }

        private void SignInDialog_onSignInComplete(object sender, OnSignUpEventArgs e)
        {
            progBar.Visibility = ViewStates.Visible;
            presenter.loginUser(e.Email, e.Password);
            progBar.Visibility = ViewStates.Invisible;
        }

       

       /*          ----------------------------------------------------------------                                   */

        //REGISTER
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            DialogSignUp signUpDialog = new DialogSignUp();
            signUpDialog.Show(transaction, "Daiglog Framgent");

            //Subscribe to the  onSignUpComplete event int DialogSignUp fragment
            signUpDialog.onSignUpComplete += SignUpDialog_onSignUpComplete;
        }

        // Function to run when the event is invoked
        private void SignUpDialog_onSignUpComplete(object sender, OnSignUpEventArgs e)
        {
            progBar.Visibility = ViewStates.Visible;
            using (var h = new Handler(Looper.MainLooper))
            {
                h.Post(() => {
                    presenter.createUser(e.Email, e.Password);
                    
                }); 
            }
            

        }

         /* ILoginView functions */ 
        public void confirmCreation()
        {
            //textSuccess.Text = "Account Created, Please confirm your email address";
            RunOnUiThread(() => { progBar.Visibility = ViewStates.Invisible; });
             Toast.MakeText(this, "Account Created, Please confirm your email address", ToastLength.Long).Show();

        }

        public void creationError()
        {
            //textError.Text = "Creation Failed";
            Toast.MakeText(this, "Error creating account", ToastLength.Long).Show();
        }

        public void goToHome()
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            prefs.Edit().PutBoolean("loggedIn", true).Commit();

            var intent = new Intent(this, typeof(HomeTabbedActivity));
              // intent.PutStringArrayListExtra("phone_numbers", phoneNumbers);
               StartActivity(intent);
               
        }
        public void signInError()
        {
            Toast.MakeText(this, "Error Logging in", ToastLength.Long).Show();
        }
    }
}