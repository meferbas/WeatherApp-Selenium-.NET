using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeatherAppSelenium.Service;
using System.Reflection.Emit;

namespace WeatherAppSelenium
{
    public partial class WeatherApp : Form
    {
        public WeatherApp()
        {
            InitializeComponent();
        }

        private void WeatherApp_Load(object sender, EventArgs e)
        {
            

        }

        private void girisBtn_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value += 20;

            Timer timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();
            yukleniyorLabel.Text = "uygulama başlatılıyor, lütfen bekleyiniz..";
            
        }

        private int progressBarValue = 20;
        private bool control = false;
        private void Timer_Tick(object sender, EventArgs e)
        {
            
            progressBarValue += 10; // Her saniye %10 artır
            progressBar1.Value = Math.Min(progressBarValue, 100); // En fazla %100'e kadar

            if (!control)
            {
                WeatherScraper.openService();
                control = true;
            }

            if (progressBar1.Value >= 100)
            {
                ((Timer)sender).Stop(); // Timer'ı durdur
                OpenSecondForm(); // İkinci formu aç
            }
            
        }
        private void OpenSecondForm()
        {
            // İkinci formu aç
            panel1.Controls.Clear();
            Form2 giris = new Form2();
            giris.TopLevel = false;
            giris.FormBorderStyle = FormBorderStyle.None;
            giris.Dock = DockStyle.Fill;
            panel1.Controls.Add(giris);
            giris.Show();
        }
      
        
    }
}
