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

        private string GetImageCode()
        {
            if (!int.TryParse(AlermCode, out int number))
            {
                return "0000";
            }

            if (number < 5000 || (9300 < number && number < 9400))
            {
                return AlermCode;
            }

            return "0000";
        }

        public string PicUrl => $"https://i.i8tq.com/alarm_icon/{AlermCode}.png";

        public string PicPath => $"Assets/{AlermCode}.png";
    }
}
