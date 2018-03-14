using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
     public  class SaveRecipeModel
    {
        public string RecipeId { get; set; }
        public int UserId { get; set; }
        public DateTime DateSaved { get; set; }
    }
}
