﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RecipeClassLibrary;
using RecipeClassLibrary.Models;

namespace TestRecipeApp.Presenter.FavouritesPresenter
{
    public interface IFavouriteView
    {
        void populate(List<RecipeItemModel> list);
        void favouriteLoadingError(string message);
    }
    class FavouritesPresenter
    {
        RecipeAPI api;
        IFavouriteView view;
        public FavouritesPresenter(IFavouriteView view)
        {
            this.view = view;
            api = new RecipeAPI();
        }

        public void updateFavourites(List<string> ids)
        {
            List<RecipeItemModel> model = new List<RecipeItemModel>();


            try
            {
                model = api.getListOfRecipes(ids);
                if (model != null)
                    view.populate(model);
                else
                    view.favouriteLoadingError("There was an error loading your favourite recipes");
            }
            catch (Exception)
            {

            }
        }

    }
}