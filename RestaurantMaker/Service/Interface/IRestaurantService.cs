using RestaurantMaker.Models.Info;
using RestaurantMaker.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMaker.Service.Interface
{
    public interface IRestaurantService
    {
        List<RestaurantListResultModel> GetRestaurantList(RestaurantListInfoModel im);
    }
}