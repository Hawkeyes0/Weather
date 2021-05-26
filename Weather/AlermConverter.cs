using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class AlermConverter
    {
        public string ToText(string alermType, string alermLevel)
        {
            return $"{TypeToText(alermType)}{LevelToText(alermLevel)}";
        }

        private static string LevelToText(string alermLevel)
        {
            return alermLevel switch
            {
                "01" => "蓝色预警",
                "02" => "黄色预警",
                "03" => "橙色预警",
                "04" => "红色预警",
                "05" => "白色预警",
                _ => string.Empty
            };
        }

        private static string TypeToText(string alermType)
        {
            return alermType switch
            {
                "01" => "台风预警",
                "02" => "暴雨预警",
                "03" => "暴雪预警",
                "04" => "寒潮预警",
                "05" => "大风预警",
                "06" => "沙尘暴预警",
                "07" => "高温预警",
                "08" => "干旱预警",
                "09" => "雷电预警",
                "10" => "冰雹预警",
                "11" => "霜冻预警",
                "12" => "大雾预警",
                "13" => "霾预警",
                "14" => "道路结冰预警",
                "51" => "海上大雾预警",
                "52" => "雷暴大风预警",
                "53" => "持续低温预警",
                "54" => "浓浮尘预警",
                "55" => "龙卷风预警",
                "56" => "低温冻害预警",
                "57" => "海上大风预警",
                "58" => "低温雨雪冰冻预警",
                "59" => "强对流预警",
                "60" => "臭氧预警",
                "61" => "大雪预警",
                "62" => "强降雨预警",
                "63" => "强降温预警",
                "64" => "雪灾预警",
                "65" => "森林（草原）火险预警",
                "66" => "雷暴预警",
                "67" => "严寒预警",
                "68" => "沙尘预警",
                "69" => "海上雷雨大风预警",
                "70" => "海上雷电预警",
                "71" => "海上台风预警",
                "72" => "低温预警",
                "91" => "寒冷预警",
                "92" => "灰霾预警",
                "93" => "雷雨大风预警",
                "94" => "森林火险预警",
                "95" => "降温预警",
                "96" => "道路冰雪预警",
                "97" => "干热风预警",
                "98" => "空气重污染预警",
                "99" => "冰冻预警",
                _ => alermType
            };
        }
    }
}
