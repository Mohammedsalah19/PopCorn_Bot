using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using Microsoft.Bot.Connector;

namespace PopCorn.Models
{
    public class AnalyzerHelper
    {
 
        public static async Task<string> analyze(string uri)
        {
            // http://www.omdbapi.com/?i=tt0268978&apikey=13ba01ba

              using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(uri))
                using (HttpContent content = response.Content)
                {
                    var mycontent = await content.ReadAsStringAsync();


                    var items = JsonConvert.SerializeObject(mycontent);
                    var array = JsonConvert.DeserializeObject<FilmAttributes>(mycontent);
                    if (array.imdbRating == null)
                    {
                        return ("The Film name is Wrong Pleas try again");
                    }

                    return ("Title: " + array.Title + " (" + array.Year +")" + "\n" + "Type: " + array.Genre + "\n" + "Rating: " + array.imdbRating + "\n" + "imdbVotes: " + array.imdbVotes + "\n" + "Awards: " + array.Awards).ToString();
                }
            }
        }
 
        //public static async Task<string> poster(string uri)
        //{
        //    // http://www.omdbapi.com/?i=tt0268978&apikey=13ba01ba


        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessage response = await client.GetAsync(uri))
        //        using (HttpContent content = response.Content)
        //        {
        //            var mycontent = await content.ReadAsStringAsync();


        //            var items = JsonConvert.SerializeObject(mycontent);
        //            var array = JsonConvert.DeserializeObject<FilmAttributes>(mycontent);
        //            if (array.Poster == null)
        //            {
        //                return "";
        //            }

        //            return array.Poster;

        //        }
        //    }
        //}
    }
}