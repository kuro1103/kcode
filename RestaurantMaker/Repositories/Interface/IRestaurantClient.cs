using RestaurantMaker.Models.Conditions;
using RestaurantMaker.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace RestaurantMaker.Repositories.Interface
{
    public interface IRestaurantClient
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        Task<List<RestaurantListResultModel>> GetRestaurantList(RestaurantListCondition condition);
    }
}