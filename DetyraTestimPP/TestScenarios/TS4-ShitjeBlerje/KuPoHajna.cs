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

namespace DetyraTestimPP.TestScenarios.TS4_ShitjeBlerje
{
    class KuPoHajna
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.KuPoHajna);
        }

        [Test]
        public void TestBuyingProduct()
        {

            Driver.driver.FindElement(By.Id("search-keyword")).SendKeys(Config.Credentials.KuPoHajnaData.Food + "\n");
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("#search-listview > div > a.orange-button.rounded3.medium")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("#menu-list-wrapper > div > div:nth-child(2) > a:nth-child(2) > div > div.col-md-7 > p.bold")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("#frm-fooditem > div > div.row.food-item-actions > div:nth-child(3) > input")).Click();
            Thread.Sleep(3000);
            
            //  Me lejon me porosit pa i japur te dhenat e dates, kohes dhe dergeses
            Driver.driver.FindElement(By.CssSelector("#menu-right-content > div > div > div.inner.line-top.relative.delivery-option.center > a")).Click();
            Thread.Sleep(3000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.KuPoHajnaData.KeyWord));


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
