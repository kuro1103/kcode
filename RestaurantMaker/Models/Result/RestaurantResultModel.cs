using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantMaker.Models.Result
{
    /// <summary>
    /// 取得餐廳清單ResultModel
    /// </summary>
    public class RestaurantListResultModel
    {
        /// <summary>
        /// 餐廳弄
        /// </summary>
        public string RestaurantAlley { get; set; }

        /// <summary>
        /// 餐廳縣市
        /// </summary>
        public string RestaurantCity { get; set; }

        /// <summary>
        /// 餐廳鄉鎮區
        /// </summary>
        public string RestaurantCounty { get; set; }

        /// <summary>
        /// 餐廳樓層
        /// </summary>
        public string RestaurantFloor { get; set; }

        /// <summary>
        /// 餐廳ID
        /// </summary>
        public long RestaurantID { get; set; }

        /// <summary>
        /// 餐廳巷
        /// </summary>
        public string RestaurantLane { get; set; }

        /// <summary>
        /// 餐廳名稱
        /// </summary>
        public string RestaurantName { get; set; }

        /// <summary>
        /// 餐廳門牌號碼
        /// </summary>
        public string RestaurantNumber { get; set; }

        /// <summary>
        /// 餐廳電話
        /// </summary>
        public string RestaurantPhone { get; set; }

        /// <summary>
        /// 餐廳路名
        /// </summary>
        public string RestaurantRoad { get; set; }
    }
}