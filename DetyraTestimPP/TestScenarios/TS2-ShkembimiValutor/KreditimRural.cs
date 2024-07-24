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
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DetyraTestimPP.TestScenarios.TS2_ShkembimiValutor
{
    class KreditimRural
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.CurrencyCalculator);
        }

        [Test]
        public void ChecCreditCalculation()
        {
            Driver.driver.FindElement(By.CssSelector("#contentout > div > a > img")).Click();
            Thread.Sleep(3000);

            Driver.driver.FindElement(By.CssSelector("#sl1 > table > tbody > tr:nth-child(5) > td:nth-child(1) > a")).Click();
            Thread.Sleep(3000);

            Driver.driver.FindElement(By.Id("eamount")).Clear();
            Driver.driver.FindElement(By.Id("eamount")).SendKeys(Config.Credentials.CurrencyConverterData.PriceValue);

            // From 
            var state1 = Driver.driver.FindElement(By.Id("efrom"));
            //create select element object 
            var selectElement1 = new SelectElement(state1);
            //select by value
            selectElement1.SelectByValue(Config.Credentials.CurrencyConverterData.FromEuro);
            Thread.Sleep(3000);

            // To
            var state2 = Driver.driver.FindElement(By.Id("eto"));
            //create select element object 
            var selectElement2 = new SelectElement(state2);
            //select by value
            selectElement2.SelectByValue(Config.Credentials.CurrencyConverterData.ToUSD);
            Thread.Sleep(3000);

            Driver.driver.FindElement(By.CssSelector("#standard > tbody > tr:nth-child(5) > td:nth-child(2) > input[type=image]:nth-child(2)")).Click();

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.CurrencyConverterData.KeyWord));
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
