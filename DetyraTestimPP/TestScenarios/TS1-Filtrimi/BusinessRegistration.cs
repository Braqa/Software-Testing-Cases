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
    class BusinessRegistration
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.RealEstate);
        }

        [Test]
        public void CheckingFilterByName()
        {
            Driver.driver.FindElement(By.Id("txtEmriBiznesit")).SendKeys(Config.Credentials.BusinessRegistrationData.BussinesName);
            Driver.driver.FindElement(By.Id("Submit1")).Click();
            Thread.Sleep(5000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.BusinessRegistrationData.Confirm));
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
