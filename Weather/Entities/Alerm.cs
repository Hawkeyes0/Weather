using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Entities
{
    public class Alerm
    {
        public string Name { get; set; }

        public string AlermType => AlermCode.Substring(0, 2);

        public string AlermLevel => AlermCode.Substring(2);

        public string LocationCode { get; set; }

        public DateTime AlermTime { get; set; }

        public string AlermCode { get; set; }

        public Position Position { get; set; }

        public string RawAlerm { get; set; }

        public string PicUrl => $"http://www.weather.com.cn/m2/i/about/alarmpic/{AlermCode}.gif";

        public string PicPath => $"Assets/{AlermCode}.gif";
    }
}
