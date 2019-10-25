using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantMaker.Models.Conditions;
using RestaurantMaker.Models.Result;
using RestaurantMaker.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantMaker.Repositories
{
    public class RestaurantClient : IRestaurantClient
    {
        public async Task<List<RestaurantListResultModel>> GetRestaurantList(RestaurantListCondition condition)
        {
            var http = new HttpClient();

            var requestUrl = $"http://localhost:378/api/v1/Restaurant/GetRestaurantList?param.restaurantName={condition.RestaurantName}";

            var response = await http.GetAsync(new Uri(requestUrl)).ConfigureAwait(false);
            var responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            var content = JObject.Parse(responseBody);

            var rm = content.SelectToken("$.RestaurantList").Value<JArray>().ToObject<RestaurantListResultModel[]>().ToList();
            return rm;
        }
    }
}