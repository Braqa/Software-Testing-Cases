using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Lirbarite per testim
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;

namespace DetyraTestimPP
{
    public static class Action
    {                  
        
        // Metoda per inicializimin e driverave te ndryshem
        public static void InitializeDriver(string driver, string url = "") //nese skemi url e lojm me base
        {
            if (driver == "Chrome")
            {
                Driver.driver = new ChromeDriver();
                Driver.driver.Manage().Window.Maximize();
            }
            else if (driver == "Firefox")
            {
                Driver.driver = new FirefoxDriver();
            }
            else if (driver == "Edge")
            {
                Driver.driver = new EdgeDriver();
            }
            else if (driver == "IE")
            {
                Driver.driver = new InternetExplorerDriver();
            }


            // nese skemi url use default
            if (string.IsNullOrEmpty(url))
            {
                url = Config.BaseUrl;
            }
            Driver.driver.Navigate().GoToUrl(url);
        }


        // Metoda per te bere screenshots gjate testimit
        public static void MakeScreenshot(string filename)
        {
            string ScreenshotDirectory = Config.ScreenshotDir;

            Screenshot browserScreenshot = ((ITakesScreenshot)Driver.driver).GetScreenshot();
            browserScreenshot.SaveAsFile(ScreenshotDirectory + @"\" + filename + ".png", ScreenshotImageFormat.Png);

        }
    }
}
