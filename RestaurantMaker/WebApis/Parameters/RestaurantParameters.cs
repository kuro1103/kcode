using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantMaker.WebApis.Parameters
{
    /// <summary>
    /// 取得餐廳清單Parameters
    /// </summary>
    public class RestaurantListParameters
    {
        /// <summary>
        /// 餐廳名稱
        /// </summary>
        public string RestaurantName { get; set; }
    }
}