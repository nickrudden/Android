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



namespace TestRecipeApp.Views.Fragments
{
    //Custom Event Argument
    public class OnSignUpEventArgs : EventArgs
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }

        public OnSignUpEventArgs(string email, string password, string passwordConfirm) : base()
        {
            Email = email;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
    }



    class DialogSignUp : DialogFragment
    {
        private EditText txtEmail;
        private EditText txtPassword;
        private EditText txtPasswordConfirm;
        private TextView txtError;
        private Button btnSignUp;

        public event EventHandler<OnSignUpEventArgs> onSignUpComplete;

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);
            Console.WriteLine("In on create dialog");
            var view = inflater.Inflate(Resource.Layout.FragmentLayoutDialogSignUp, container, false);
            
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtEmail);
            txtPassword = view.FindViewById<EditText>(Resource.Id.txtPassword);
            txtPasswordConfirm = view.FindViewById<EditText>(Resource.Id.txtPasswordConfirm);
            txtError = view.FindViewById<TextView>(Resource.Id.txtError);
            btnSignUp = view.FindViewById<Button>(Resource.Id.btnDialogEmail);

            btnSignUp.Click += BtnSignUp_Click;
            return view;
        }
        
        //Broadcast that the sign up button has been clicked on the fragment
        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            Console.WriteLine("In Btn Click");
            /*if (!String.Equals(txtPassword.Text, txtPasswordConfirm.Text))
            {
                txtError.Text = "Passwords do not match";
                return;
            }*/

            //Use invoke method to broadcast to anywhere that has subscribed to 
            
            onSignUpComplete.Invoke(this, new OnSignUpEventArgs(txtEmail.Text, txtPassword.Text, txtPasswordConfirm.Text));
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