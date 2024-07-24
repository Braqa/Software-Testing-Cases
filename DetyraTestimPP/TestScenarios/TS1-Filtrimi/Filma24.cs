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



namespace DetyraTestimPP.TestScenarios.TS1_Filtrimi
{
    class Filma24
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.Filma24);
        }

        [Test]
        public void Without_Carosel_Movies()
        {
            IWebElement filma24 = Driver.driver.FindElement(By.LinkText("Më të Shikuarit"));
            filma24.Click();
            Thread.Sleep(5000);
            Assert.IsFalse(Driver.driver.PageSource.Contains(Config.AlertMessages.Carosel));
        }

        [Test]
        public void With_Carosel_Movies()
        {
            IWebElement filma24 = Driver.driver.FindElement(By.LinkText("Të Fundit"));
            filma24.Click();
            Thread.Sleep(5000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.AlertMessages.Carosel));
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
