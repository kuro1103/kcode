using RestaurantMaker.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantMaker.WebApis.ViewModels
{
    /// <summary>
    /// 餐廳ViewModel
    /// </summary>
    public class RestaurantListViewModel
    {
        public List<RestaurantListResultModel> RestaurantList { get; set; }
    }
}