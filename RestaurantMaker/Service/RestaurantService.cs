using AutoMapper;
using RestaurantMaker.Models.Conditions;
using RestaurantMaker.Models.Info;
using RestaurantMaker.Models.Result;
using RestaurantMaker.Repositories.Interface;
using RestaurantMaker.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantMaker.Service
{
    public class RestaurantService : IRestaurantService
    {
        private IRestaurantClient _restaurantClient;

        public RestaurantService(IRestaurantClient restaurantClient)
        {
            this._restaurantClient = restaurantClient;
        }

        public List<RestaurantListResultModel> GetRestaurantList(RestaurantListInfoModel im)
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantListInfoModel, RestaurantListCondition>();
            });
            var mapper = mapConfig.CreateMapper();
            RestaurantListCondition c = mapper.Map<RestaurantListCondition>(im);

            var rm = _restaurantClient.GetRestaurantList(c).Result;

            return rm;
        }
    }
}