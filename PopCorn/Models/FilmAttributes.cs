using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopCorn.Models
{
    public class FilmAttributes
    {

        [JsonProperty(PropertyName = "Year")]

        public string Year { get; set; }

        [JsonProperty(PropertyName = "Genre")]

        public string Genre { get; set; }
        [JsonProperty(PropertyName = "Title")]

        public string Title { get; set; }

        [JsonProperty(PropertyName = "imdbVotes")]

        public string imdbVotes { get; set; }

        [JsonProperty(PropertyName = "imdbRating")]

        public string imdbRating { get; set; }

        [JsonProperty(PropertyName = "Awards")]

        public string Awards { get; set; }
        [JsonProperty(PropertyName = "Poster")]

        public string Poster { get; set; }
    }
}