﻿using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Weather.Entities;

namespace Weather
{
    public partial class WeatherService
    {
        private HttpClient Client { get; }

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public WeatherService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://product.weather.com.cn")
            };
            Client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0");
            Client.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            Client.DefaultRequestHeaders.Referrer = new Uri("http://product.weather.com.cn");
        }

        public async Task<List<Alerm>> GetAlermListAsync()
        {
            string json;
            try
            {
                json = await Client.GetStringAsync("/alarm/grepalarm_cn.php").ConfigureAwait(false);
            }
            catch
            {
                return [];
            }

            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }
            int offset = json.IndexOf('[');
            if (offset == -1) { return null; }

            json = json[offset..(json.LastIndexOf(']') + 1)];
            logger.Debug($"alerm json: {json}");

            MatchCollection matches = GetAlermRegex().Matches(json);

            var rawdata = new List<string[]>();
            foreach(Match m in matches)
            {
                rawdata.Add(m.Value.Replace("\"","")[1..^1].Split(","));
            }

            List<Alerm> alerms = [];

            try
            {
                foreach (string[] row in rawdata)
                {
                    string[] f = row[1].Split('-', '.');
                    Alerm a = new()
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
            }
            catch (Exception ex)
            {
                logger.Error(ex, "error when parse alerms");
            }

            return alerms;
        }

        public async Task<CurrentState> GetCurrentStateAsync(string locationCode)
        {
            string str;
            try
            {
                str = await Client.GetStringAsync($"http://d1.weather.com.cn/sk_2d/{locationCode}.html").ConfigureAwait(false);
            }
            catch
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(str))
            {
                return null;
            }

            int offset = str.IndexOf('{');
            if (offset == -1) { return null; }

            str = str[offset..];
            CurrentState current = JsonConvert.DeserializeObject<CurrentState>(str);
            return current;
        }

		[GeneratedRegex(@"\["".*?""(,"".*?"")+\]")]
		private static partial Regex GetAlermRegex();
	}
}
