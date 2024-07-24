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

namespace DetyraTestimPP.TestScenarios.TS2_ShkembimiValutor
{
    class UnitConverters
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.UnitConverter);
        }

        [Test]
        public void CheckConvertedValues()
        {
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.CssSelector("#homelist > tbody > tr > td:nth-child(2) > ul > li:nth-child(1) > a")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.Id("ucfrom")).SendKeys(Config.Credentials.UnitConverterData.MeasureValue);
            Driver.driver.FindElement(By.ClassName("ucdcsubmit")).Click();
            Thread.Sleep(3000);
            Driver.driver.FindElement(By.XPath("//*[@id=\"undctable\"]/table/tbody/tr[3]/td[2]/input[4]")).Click();
            Driver.driver.FindElement(By.Id("ucfrom")).SendKeys(Config.Credentials.UnitConverterData.RevMeasure);
            Thread.Sleep(2000);
            Driver.driver.FindElement(By.ClassName("ucdcsubmit")).Click();
            Thread.Sleep(3000);

            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.Credentials.UnitConverterData.ConfirmPage));
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
