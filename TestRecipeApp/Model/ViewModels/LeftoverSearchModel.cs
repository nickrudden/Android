using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class LeftoverSearchModel
    {
        public string RecipeID { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public int UsedIngredientCount { get; set; }
        public int missedIngredientsCount { get; set; }
        public int likes { get; set; }
        
    }
}
