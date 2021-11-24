using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class CurrentState
    {
        public string cityname { get; set; }

        public string city { get; set; }

        public string temp { get; set; }

        public string tempf { get; set; }

        /// <summary>
        /// 风向
        /// </summary>
        public string WD { get; set; }

        /// <summary>
        /// 风级
        /// </summary>
        public string WS { get; set; }

        /// <summary>
        /// 风速
        /// </summary>
        public string wse { get; set; }

        /// <summary>
        /// 湿度
        /// </summary>
        public string SD { get; set; }

        /// <summary>
        /// 气压
        /// </summary>
        public string qy { get; set; }

        /// <summary>
        /// 能见度
        /// </summary>
        public string njd { get; set; }

        public string time { get; set; }

        public string rain { get; set; }

        public string rain24h { get; set; }

        /// <summary>
        /// 空气质量
        /// </summary>
        public string aqi { get; set; }

        public string weather { get; set; }

        public string weathercode { get; set; }

        public string limitnumber { get; set; }

        public string date { get; set; }
    }
}
