using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class RecipeItemModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public bool Vegetarian { get; set; }
        public bool Vegan { get; set; }
        public bool GlutenFree { get; set; }
        public bool DairyFree { get; set; }
        public bool VeryHeathy { get; set; }
        public bool Sustainable { get; set; }
        public bool Ketogenic { get; set; }
        public int Servings { get; set; }
        public int PreparationMinutes { get; set; }
        public int CookingMinutes { get; set; }
        public string CreditText { get; set; }
        public string SourceName { get; set; }
        public List<SingleIngredientModel> ExtendedIngredients { get; set; }
        public List<StepModel> AnalyzedInstructions { get; set; }
    }
}
