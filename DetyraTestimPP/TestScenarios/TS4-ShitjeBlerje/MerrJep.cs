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
    class MerrJep
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.MerrJep);
        }

        [Test]
        public void DoesntAllowToDeleteUnfinishedCredit()
        {
            IWebElement merrJep = Driver.driver.FindElement(By.LinkText("Llogaria ime"));
            merrJep.Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.LinkText("Kyçuni me anë të Google")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Id("identifierId")).SendKeys(Config.Credentials.MerrJepData.Email);
            Driver.driver.FindElement(By.ClassName("VfPpkd-RLmnJb")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Name("password")).SendKeys(Config.Credentials.MerrJepData.Password);
            Driver.driver.FindElement(By.ClassName("VfPpkd-RLmnJb")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("body > header > div > div > div > div.span9 > a")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Id("Sum")).SendKeys(Config.Credentials.MerrJepData.Money);
            Driver.driver.FindElement(By.Id("submit-create-invoice-form")).Click();
            Thread.Sleep(3000);
            Driver.driver.Navigate().Back();
            Thread.Sleep(3000);
            Driver.driver.Navigate().Refresh();
            Thread.Sleep(3000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.MerrJepData.Money));


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
