using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Reflection.Emit;
using System.Drawing;

namespace WeatherAppSelenium.Service
{

    public class WeatherScraper
    {
    
        private static IWebDriver driver;
        private static bool control;

        public static void openService()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"C:\Users\Efe\Desktop\ChromeDriver");

            driver = new ChromeDriver(service, options);
            driver.Navigate().GoToUrl("https://www.mgm.gov.tr/");
           
        }
        public static void GetWeather(string sehirAdi, DataGridView dataGridView, TextBox textBox, System.Windows.Forms.Label label, System.Windows.Forms.Label label1)
        {
            if (!control)
            {
                IWebElement closeButton = driver.FindElement(By.CssSelector("span.close"));
                closeButton.Click();
                control = true;
            }
            
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            label.Text = "";
            label1.Text = "";
            
            IWebElement sehirAramaKutusu = driver.FindElement(By.Id("txtsearch"));
            sehirAramaKutusu.Clear();
            sehirAramaKutusu.SendKeys(sehirAdi);
            Thread.Sleep(2000);

            IWebElement ilkSonuc = driver.FindElement(By.CssSelector("#scrolo ul#ulMerkezler li:first-child"));
            ilkSonuc.Click();
            Thread.Sleep(1000);

            IWebElement sicaklikElement = driver.FindElement(By.ClassName("pull-left"));
            string sicaklik = sicaklikElement.Text;

            IWebElement divTahminSol = driver.FindElement(By.ClassName("tahminSol"));
            IWebElement divTahminSol2 = driver.FindElement(By.Id("t2"));
            IWebElement divTahminSol3 = driver.FindElement(By.Id("t3"));
            IWebElement divTahminSol4 = driver.FindElement(By.Id("t4"));
            IWebElement divTahminSol5 = driver.FindElement(By.Id("t5"));

            IWebElement divIlkTarih = divTahminSol.FindElement(By.CssSelector("div.tahminTarih.ng-binding"));
            IWebElement divIkiTarih = divTahminSol2.FindElement(By.CssSelector("div.tahminTarih.ng-binding"));
            IWebElement divUcTarih = divTahminSol3.FindElement(By.CssSelector("div.tahminTarih.ng-binding"));
            IWebElement divDortTarih = divTahminSol4.FindElement(By.CssSelector("div.tahminTarih.ng-binding"));
            IWebElement divBesTarih = divTahminSol5.FindElement(By.CssSelector("div.tahminTarih.ng-binding"));

            IWebElement divHadise = divTahminSol.FindElement(By.CssSelector("div.tahminHadise.ng-binding"));
            IWebElement divHadise2= divTahminSol2.FindElement(By.CssSelector("div.tahminHadise.ng-binding"));
            IWebElement divHadise3 = divTahminSol3.FindElement(By.CssSelector("div.tahminHadise.ng-binding"));
            IWebElement divHadise4 = divTahminSol4.FindElement(By.CssSelector("div.tahminHadise.ng-binding"));
            IWebElement divHadise5 = divTahminSol5.FindElement(By.CssSelector("div.tahminHadise.ng-binding"));

            IWebElement tahminMin = divTahminSol.FindElement(By.ClassName("tahminMin"));
            IWebElement tahminMax = divTahminSol.FindElement(By.ClassName("tahminMax"));

            IWebElement tahminMin2 = divTahminSol2.FindElement(By.CssSelector("div.tahminMin"));
            IWebElement tahminMax2 = divTahminSol2.FindElement(By.CssSelector("div.tahminMax"));

            IWebElement tahminMin3 = divTahminSol3.FindElement(By.CssSelector("div.tahminMin"));
            IWebElement tahminMax3 = divTahminSol3.FindElement(By.CssSelector("div.tahminMax"));

            IWebElement tahminMin4 = divTahminSol4.FindElement(By.CssSelector("div.tahminMin"));
            IWebElement tahminMax4 = divTahminSol4.FindElement(By.CssSelector("div.tahminMax"));

            IWebElement tahminMin5 = divTahminSol5.FindElement(By.CssSelector("div.tahminMin"));
            IWebElement tahminMax5 = divTahminSol5.FindElement(By.CssSelector("div.tahminMax"));






            label.Text = sehirAdi + " İçin Önümüzdeki 5 Günlük Hava Durumu";
            label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            label1.Text = "Anlık:" + sicaklik;

            dataGridView.Columns.Add("sehir", sehirAdi);
            dataGridView.Columns.Add("ilkGun", divIlkTarih.Text);
            dataGridView.Columns.Add("ikinciGun", divIkiTarih.Text);
            dataGridView.Columns.Add("ucuncuGun",divUcTarih.Text);
            dataGridView.Columns.Add("dorduncuGun", divDortTarih.Text);
            dataGridView.Columns.Add("besinciGun", divBesTarih.Text);

            dataGridView.DefaultCellStyle.Font = new Font("Arial", 12, FontStyle.Bold);

            
            dataGridView.Rows.Add("Min Sıcaklık", tahminMin.Text, tahminMin2.Text, tahminMin3.Text, tahminMin4.Text, tahminMin5.Text);
            dataGridView.Rows.Add("Max Sıcaklık", tahminMax.Text, tahminMax2.Text, tahminMax3.Text, tahminMax4.Text, tahminMax5.Text);
            dataGridView.Rows.Add("Beklenen Hadise" , divHadise.Text, divHadise2.Text, divHadise3.Text, divHadise4.Text, divHadise5.Text);




            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.DefaultCellStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            }
           

        }

    }
}
