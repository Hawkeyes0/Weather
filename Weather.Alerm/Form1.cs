using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Weather.Alerm
{
    public partial class Form1 : Form
    {
        private WeatherService WeatherService { get; } = new WeatherService();

        private AlermConverter Converter { get; } = new AlermConverter();

        private string LocationCode { get; }

        private HashSet<string> Codes { get; } = new HashSet<string>();

        private Color[] colors = new Color[] { Color.Red, Color.Gray, Color.Blue };

        public Form1()
        {
            InitializeComponent();
            LocationCode = ConfigurationManager.AppSettings["location"];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1_Tick(null, e);
            var area = Screen.AllScreens[0].WorkingArea;
            Location = new Point { X = area.Width - Width - 4, Y = area.Height - Height - 4 };

            tState.Interval = (int)TimeSpan.FromMinutes(15).TotalMilliseconds;
            tState.Start();
            tState_Tick(null, null);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var alerms = WeatherService.GetAlermListAsync().Result;
            var rs = alerms.Where(e => e.LocationCode == LocationCode);
            flowLayoutPanel1.Controls.Clear();
            if (rs.Any())
            {
                foreach (var a in rs)
                {
                    flowLayoutPanel1.Controls.Add(new PictureBox
                    {
                        ImageLocation = Path.GetFullPath(a.PicPath),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size { Width = 63, Height = 54 }
                    });

                    if (!Codes.Add(a.RawAlerm))
                    {
                        continue;
                    }

                    new ToastContentBuilder()
                        .AddArgument("conversationId", $"{a.LocationCode}_{a.AlermTime}_{a.AlermCode}")
                        .AddText($"{a.AlermTime:yyyy-MM-dd HH:mm:ss}发布")
                        .AddText($"{a.Name}-{Converter.ToText(a.AlermType, a.AlermLevel)}")
                        .AddInlineImage(new Uri($"file:///{Path.GetFullPath(a.PicPath).Replace('\\', '/')}"))
                        .Show();
                }
            }

            _ = Codes.RemoveWhere(e => !rs.Any(a => a.RawAlerm == e));

            Trace.WriteLine($"Update data at {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            tState.Stop();
            notifyIcon1.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private async void tState_Tick(object sender, EventArgs e)
        {
            var state = await WeatherService.GetCurrentStateAsync();
            lTime.Text = $"{state.date} {state.time} 实况";
            lTemp.Text = $"{state.temp} ℃";
            lSd.Text = $"相对湿度 {state.SD}";
            lLimitNumber.Text = $"{state.limitnumber} 限行";
            lWind.Text = $"{state.WD} {state.WS}";
            lAqi.Text = $"空气质量 {state.aqi}";

            lTemp.ForeColor = TempColor(state.temp);
        }

        private Color TempColor(string str)
        {
            int temp = Convert.ToInt32(str);
            switch (temp)
            {
                case < -40:
                    return colors[2];
                case > 40:
                    return colors[0];
                case 0:
                    return colors[1];
                default:
                    break;
            }

            double p = Math.Abs(temp) / 40d;

            if (temp > 0)
            {
                return GetMidColor(colors[1], colors[0], p);
            } else
            {
                return GetMidColor(colors[1], colors[2], p);
            }
        }

        private static Color GetMidColor(Color color1, Color color2, double p)
        {
            byte r = (byte)(color1.R - (color1.R - color2.R) * p);
            byte g = (byte)(color1.G - (color1.G - color2.G) * p);
            byte b = (byte)(color1.B - (color1.B - color2.B) * p);
            return Color.FromArgb(r, g, b);
        }
    }
}
