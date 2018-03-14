using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class SingleIngredientModel
    {
        public string IngredientID { get; set; }
        public string Aisle { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
        public string Unit { get; set; }
    }
}
