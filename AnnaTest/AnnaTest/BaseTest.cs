using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using NUnit.Framework.Interfaces;
using Allure.Commons;
using NUnit.Allure.Core;

namespace AnnaTest
{
    [AllureNUnit]
    public class BaseTest
    {

        protected IWebDriver webDriver;

        [SetUp]
        public void SetUp()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            webDriver = new ChromeDriver();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("http://10.7.28.18:86");
        }

        [TearDown]
        public void CloseBrowser()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)webDriver).GetScreenshot();
                var filename = TestContext.CurrentContext.Test.MethodName + "_screenshot_" + DateTime.Now.Ticks + ".png";
                var path = "D:\\" + filename;
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                TestContext.AddTestAttachment(path);
                AllureLifecycle.Instance.AddAttachment(filename, "image/png", path);

            }
            webDriver.Close();
            webDriver.Quit();
        }

        protected void ClickOnElement(IWebElement webElement)
        {
            if (webElement.Displayed)
            {
                webElement.Click();
            }
            else
            {
                return;
            }
        }

        protected void EnterTextToElement(IWebElement webElement, string textToElement)
        {
            webElement.Click();
            webElement.Clear();
            webElement.SendKeys(textToElement);
        }

    }
}
