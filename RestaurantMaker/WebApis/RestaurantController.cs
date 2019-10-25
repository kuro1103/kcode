using AutoMapper;
using RestaurantMaker.Models.Info;
using RestaurantMaker.Models.Result;
using RestaurantMaker.Service.Interface;
using RestaurantMaker.WebApis.Parameters;
using RestaurantMaker.WebApis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestaurantMaker.WebApis
{
    /// <summary>
    /// 餐廳Controller
    /// </summary>
    [RoutePrefix("api/Restaurant")]
    public class RestaurantController : ApiController
    {
        private IRestaurantService _restaurantService;

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="restaurantService"></param>
        public RestaurantController(IRestaurantService restaurantService)
        {
            this._restaurantService = restaurantService;
        }

        /// <summary>
        /// 取得餐廳清單
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [Route("GetRestaurantList")]
        [HttpGet]
        public RestaurantListViewModel GetRestaurantList([FromUri]RestaurantListParameters param)
        {
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RestaurantListParameters, RestaurantListInfoModel>();
            });
            var mapper = mapConfig.CreateMapper();
            RestaurantListInfoModel restaurantListIM = mapper.Map<RestaurantListInfoModel>(param);

            RestaurantListViewModel vm = new RestaurantListViewModel();
            var rm = _restaurantService.GetRestaurantList(restaurantListIM);
            vm.RestaurantList = rm;

            return vm;
        }
    }
}