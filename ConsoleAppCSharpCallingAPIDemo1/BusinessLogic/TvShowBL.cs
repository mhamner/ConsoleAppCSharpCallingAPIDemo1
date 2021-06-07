using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using ConsoleAppCSharpCallingAPIDemo1.Models;


namespace ConsoleAppCSharpCallingAPIDemo1.BusinessLogic
{
    public class TvShowBL
    {
        public async Task<List<TvShowModel>> LoadTvShowInfo(string tvShowName)
        {
            string url = $"http://api.tvmaze.com/search/shows?q={tvShowName}";
            using(HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if(response.IsSuccessStatusCode)
                {
                    var settings = new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore
                    };
                    var jsonString = response.Content.ReadAsStringAsync().Result;
                    List<TvShowModel> tvShowInfo = JsonConvert.DeserializeObject<List<TvShowModel>>(jsonString, settings);

                    //List<TvShowModel> tvShowInfo = await response.Content.ReadAsAsync<List<TvShowModel>>();
                    return tvShowInfo;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                } 
            }
        }
    }
}
