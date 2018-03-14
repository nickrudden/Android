using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class ReviewModel
    {
        public string RecipeID { get; set; }
        public int UserID { get; set; }
        public string ReviewText { get; set; }
        public Nullable<int> Rating { get; set; }
        public Nullable<DateTime> ReviewDate { get; set; }
    }
}
