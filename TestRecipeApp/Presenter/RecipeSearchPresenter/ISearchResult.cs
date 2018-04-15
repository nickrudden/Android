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
using RecipeClassLibrary.Models;

namespace TestRecipeApp.Presenter.RecipeSearchPresenter
{
    interface ISearchResult
    {
         void searchResults(List<LeftoverSearchModel> m);
        void searchRecipeResults(List<KeywordSearchModel> m);



    }
}