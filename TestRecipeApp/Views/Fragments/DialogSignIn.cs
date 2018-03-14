using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace TestRecipeApp.Views.Fragments
{
    public class DialogSignIn : DialogFragment
    {

        private EditText txtEmail;
        private EditText txtPassword;
       
        private TextView txtError;
        private Button btnSignIn;

        public event EventHandler<OnSignUpEventArgs> onSignInComplete;
        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            Console.WriteLine("In on create dialog");
            var view = inflater.Inflate(Resource.Layout.FragmentLayoutDialogSignIn, container, false);


            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
           
            txtError = view.FindViewById<TextView>(Resource.Id.txtError);
            btnSignIn = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            btnSignIn.Click += BtnSignIn_Click;
            return view;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In Btn Click");
            /*if (!String.Equals(txtPassword.Text, txtPasswordConfirm.Text))
            {
                txtError.Text = "Passwords do not match";
                return;
            }*/

            //Use invoke method to broadcast to anywhere that has subscribed to 

            onSignInComplete.Invoke(this, new OnSignUpEventArgs(txtEmail.Text, txtPassword.Text, ""));
            this.Dismiss();


        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); //Gets rid of title bar
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.DialogAnimation;
        }
       

       
    }
}