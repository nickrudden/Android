using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TestRecipeApp
{
    class ImageManager
    {
        static Dictionary<string, Drawable> cache = new Dictionary<string, Drawable>();

        public static Drawable Get(string url)
        {
            if(!cache.ContainsKey(url))
            {
                var drawable = Drawable.CreateFromStream(GetImageStream(url), null);

                cache.Add(url, drawable);
            }

            return cache[url];
        }

        public static Stream GetImageStream(string url)
        {
            byte[] imageBytes = null;

            using (var wc = new WebClient())
            {
                imageBytes = wc.DownloadData(url);
            }
            return new MemoryStream(imageBytes);
        }
    }
}