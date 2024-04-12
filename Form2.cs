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

namespace WeatherAppSelenium
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void derece_Click(object sender, EventArgs e)
        {

        }
        private void araBtn_Click_1(object sender, EventArgs e)
        {
            string sehirAdi = sehirlertxtBox.Text;

            WeatherScraper.GetWeather(sehirAdi, dataGridView1, sehirlertxtBox, baslikLabel, sicaklikLabel);


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void sehirlertxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)System.Windows.Forms.Keys.Enter)
            {
                araBtn.PerformClick();
                e.Handled = true;
            }
           
        }
    }
}
