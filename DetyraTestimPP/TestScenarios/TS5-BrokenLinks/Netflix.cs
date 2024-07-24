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
    class Netflix
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.Netflix);
        }

        [Test]
        public void RedirectNetflixToYoutubeOffPage()
        {
            IWebElement netflix = Driver.driver.FindElement(By.LinkText("Sign In"));
            netflix.Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Id("id_userLoginId")).SendKeys(Config.Credentials.NetflixData.Username);
            Driver.driver.FindElement(By.Id("id_password")).SendKeys(Config.Credentials.NetflixData.Password);
            Driver.driver.FindElement(By.CssSelector("#appMountPoint > div > div.login-body > div > div > div.hybrid-login-form-main > form > button")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.ClassName("profile-icon")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.LinkText("Watch Again")).Click(); 
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"appMountPoint\"]/div/div/div[1]/div[1]/div[3]/div[1]/a[3]")).Click(); 
            Thread.Sleep(3000);

            Assert.IsFalse(Driver.driver.PageSource.Contains(Config.AlertMessages.NotAvailable));

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
