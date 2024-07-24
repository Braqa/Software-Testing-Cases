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
    class MerrJep
    {
        [SetUp]
        public void SetupBeforeEachTest()
        {
            Action.InitializeDriver("Chrome", Config.MerrJep);
        }

        [Test]
        public void AllowsImageToUploadOnVideoField()
        {
            IWebElement merrJep = Driver.driver.FindElement(By.LinkText("+ Postoni shpallje FALAS!"));
            merrJep.Click();
            Thread.Sleep(5000);
            Driver.driver.FindElement(By.Id("uploadId_video")).SendKeys(Config.Credentials.MerrJepData.VideoFile);
            Thread.Sleep(3000);
            Assert.IsTrue(Driver.driver.PageSource.Contains(Config.AlertMessages.DeleteKeyWord));
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
