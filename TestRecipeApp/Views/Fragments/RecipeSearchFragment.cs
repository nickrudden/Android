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
using TestRecipeApp.Utilites;
using TestRecipeApp.Views.Activities;

namespace TestRecipeApp.Views.Fragments
{
    public class RecipeSearchFragment : Android.Support.V4.App.Fragment
    {
        TextView searchButton;
        CheckBox checkDairy;
        CheckBox checkEgg;
        CheckBox checkGluten;
        CheckBox checkPeanut;
        CheckBox checkSesame;
        CheckBox checkShellfish;
        CheckBox checkSoy;
        CheckBox checkSulfite;
        CheckBox checkTree;
        CheckBox checkWheat;

        RadioButton pesc;
        RadioButton lacto;
        RadioButton ovo;
        RadioButton vegan;
        RadioButton veg;

        string diet;
        List<string> checkedIds;
        
        
        public static RecipeSearchFragment newInstance()
        {
            RecipeSearchFragment fragment = new RecipeSearchFragment();
            Bundle args = new Bundle();
            return fragment;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            checkedIds = new List<string>();
            
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.SupportFragmentLayoutRecipeSearchPage, container, false);
          
            
            searchButton = view.FindViewById<TextView>(Resource.Id.searchButton);
            searchButton.Click += SearchButton_Click;

            pesc = view.FindViewById<RadioButton>(Resource.Id.radio_pescetarian);
            lacto = view.FindViewById<RadioButton>(Resource.Id.radio_lacto_vegetarian);
            ovo = view.FindViewById<RadioButton>(Resource.Id.radio_ovo_vegetarian);
            vegan = view.FindViewById<RadioButton>(Resource.Id.radio_vegan);
            veg = view.FindViewById<RadioButton>(Resource.Id.radio__vegetarian);

            pesc.Click += radioClick;
            lacto.Click += radioClick;
            ovo.Click += radioClick;
            vegan.Click += radioClick;
            veg.Click += radioClick;

            checkDairy = view.FindViewById<CheckBox>(Resource.Id.checkDairy);
            checkEgg = view.FindViewById<CheckBox>(Resource.Id.checkEgg);
            checkGluten = view.FindViewById<CheckBox>(Resource.Id.checkGluten);
            checkPeanut = view.FindViewById<CheckBox>(Resource.Id.checkPeanut);
            checkSesame = view.FindViewById<CheckBox>(Resource.Id.checkSesame);
            checkShellfish = view.FindViewById<CheckBox>(Resource.Id.checkShellfish);
            checkSoy = view.FindViewById<CheckBox>(Resource.Id.checkSoy);
            checkSulfite = view.FindViewById<CheckBox>(Resource.Id.checkSulfite);
            checkTree = view.FindViewById<CheckBox>(Resource.Id.checkTree);
            checkWheat = view.FindViewById<CheckBox>(Resource.Id.checkWheat);

            checkDairy.Click += (o, e) => {
                if (checkDairy.Checked)
                    checkedIds.Add("Dairy");
                else
                    checkedIds.Remove("Dairy");
              
            };

            checkEgg.Click += (o, e) => {
                if (checkEgg.Checked)
                    checkedIds.Add("Egg");
                else
                    checkedIds.Remove("Egg");

            };

            checkGluten.Click += (o, e) => {
                if (checkGluten.Checked)
                    checkedIds.Add("Gluten");
                else
                    checkedIds.Remove("Gluten");

            };

            checkPeanut.Click += (o, e) => {
                if (checkPeanut.Checked)
                    checkedIds.Add("Peanut");
                else
                    checkedIds.Remove("Peanut");

            };

            checkSesame.Click += (o, e) => {
                if (checkSesame.Checked)
                    checkedIds.Add("Sesame");
                else
                    checkedIds.Remove("Sesame");

            };

            checkShellfish.Click += (o, e) => {
                if (checkShellfish.Checked)
                    checkedIds.Add("Shellfish");
                else
                    checkedIds.Remove("Shellfish");

            };

            checkSoy.Click += (o, e) => {
                if (checkSoy.Checked)
                    checkedIds.Add("Soy");
                else
                    checkedIds.Remove("Soy");

            };

            checkSulfite.Click += (o, e) => {
                if (checkSulfite.Checked)
                    checkedIds.Add("Sulfite");
                else
                    checkedIds.Remove("Sulphite");

            };

            checkTree.Click += (o, e) => {
                if (checkTree.Checked)
                    checkedIds.Add("tree nut");
                else
                    checkedIds.Remove("tree nut");

            };

            checkWheat.Click += (o, e) => {
                if (checkWheat.Checked)
                    checkedIds.Add("wheat");
                else
                    checkedIds.Remove("wheat");

            };
            return view;
        }


        
        private void radioClick(object sender, EventArgs args)
        {
            RadioButton selected = (RadioButton)sender;
            diet = selected.Text;
            Toast.MakeText(this.Context, diet, ToastLength.Short).Show();

        }
        private void SearchButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this.Context, typeof(RecipeSearchViewActivity));
            intent.PutStringArrayListExtra("intolerances", checkedIds);
            intent.PutExtra("diet", diet);
            StartActivity(intent);
        }
    }
}