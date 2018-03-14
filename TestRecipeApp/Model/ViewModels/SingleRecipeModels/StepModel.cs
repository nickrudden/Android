using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class StepModel
    {
        public string Name { get; set; }
        public List<SingleStepModel> Steps  { get; set; }
    }
}
