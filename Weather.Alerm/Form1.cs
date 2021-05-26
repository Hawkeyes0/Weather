﻿using System;
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
                        .AddInlineImage(new Uri($"file:///{Path.GetFullPath(a.PicPath).Replace('\\','/')}"))
                        .Show();
                }
            }

            Trace.WriteLine($"Update data at {DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
            notifyIcon1.Visible = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }
    }
}