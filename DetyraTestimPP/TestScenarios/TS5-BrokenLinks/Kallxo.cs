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
using OpenQA.Selenium.Support.UI;

namespace DetyraTestimPP.TestScenarios.TS5_BrokenLinks
{
    class Kallxo
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.Kallxo);
        }

        [Test]
        public void CheckIfLinkBroken()
        {
            Driver.driver.FindElement(By.LinkText("Drejtësia në Kosovë")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("#main > div > div > div:nth-child(2) > div > div > div > div:nth-child(3) > div > a")).Click();
            Thread.Sleep(3000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.KallxoData.CompareValue));
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
