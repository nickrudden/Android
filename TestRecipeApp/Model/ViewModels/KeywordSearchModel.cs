using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipeClassLibrary.Models
{
    public class KeywordSearchModel
    {
        [JsonProperty("id")]
        public string RecipeId { get; set; }
        public string Title { get; set; }
        public int ReadyInMinutes { get; set; }
        public string Image { get; set; }
        public List<string> ImageUrls { get; set; }
    }

    public class KeywordSearchOverView
    {
        [JsonProperty("results")]
        public List<KeywordSearchModel> Recipes { get; set; }
        [JsonProperty("baseUri")]
        public string BaseUri { get; set; }
        

    }
}
