using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
// Lirbarite per testim
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;


namespace DetyraTestimPP.TestScenarios.TS3_UploadDownload
{
    class Filma25
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.Filma24);
        }

        [Test]
        public void MovieFileUnavailableDownload()
        {
            IWebElement filma24 = Driver.driver.FindElement(By.ClassName("sbtn"));
            filma24.Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Name("search")).SendKeys(Config.Credentials.Filma24Data.FilmName + "\n");
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.ClassName("xtt")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("body > div.watch-movie > div.download-links > ul > a:nth-child(1) > li")).Click();
            Thread.Sleep(3000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.AlertMessages.CompareLink));


        }

        [TearDown]
        public void AfterEachTest()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Action.MakeScreenshot(TestContext.CurrentContext.Test.Name);
            }
            Driver.driver.Quit();
        }
    }
}
