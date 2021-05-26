using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Weather.Entities;

namespace Weather
{
    public class WeatherService
    {
        private HttpClient Client { get; }

        public WeatherService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://product.weather.com.cn")
            };
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0");
            Client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
        }

        public async Task<List<Alerm>> GetAlermListAsync()
        {
            string json = await Client.GetStringAsync("/alarm/grepalarm_cn.php").ConfigureAwait(false);
            int offset = json.IndexOf("[");
            json = json.Substring(offset, json.LastIndexOf("]") - offset + 1);
            var rawdata = JsonSerializer.Deserialize<List<string[]>>(json);
            List<Alerm> alerms = new List<Alerm>();

            foreach (string[] row in rawdata)
            {
                string[] f = row[1].Split('-', '.');
                Alerm a = new Alerm
                {
                    Name = row[0],
                    LocationCode = f[0],
                    AlermTime = DateTime.ParseExact(f[1], "yyyyMMddHHmmss", null),
                    AlermCode = f[2],
                    RawAlerm = row[1],
                    Position = new Position { Long = Convert.ToDecimal(row[2]), Lat = Convert.ToDecimal(row[3]) }
                };
                alerms.Add(a);

                if (!File.Exists(a.PicPath))
                {
                    if (!Directory.Exists(Path.GetDirectoryName(a.PicPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(a.PicPath));
                    }
                    var resp = await Client.GetAsync(a.PicUrl);
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        byte[] buff = await resp.Content.ReadAsByteArrayAsync();
                        await File.WriteAllBytesAsync(a.PicPath, buff);
                    }
                }
            }

            return alerms;
        }
    }
}
