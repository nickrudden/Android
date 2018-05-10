using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace TestRecipeApp.Utilites
{
    public class LocalDb
    {
        string path;
        private object locker;
        SQLiteConnection db;

        public LocalDb()
        {
            path = Path.Combine(
                    System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),
                    "database.recipe");
            locker = new object();

            db = new SQLiteConnection(path);

        }

        //lock (locker ){}


    }
}