using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace AnnaTest
{
    public class SimpleTest : BaseTest
    {



        private IWebElement franceButton => webDriver.FindElement(By.XPath("//a[contains(text(),'fr_team')]"));
        private IWebElement userName => webDriver.FindElement(By.Id("UserName"));
        private IWebElement passWord => webDriver.FindElement(By.Id("Password"));
        private IWebElement loginButton => webDriver.FindElement(By.XPath("//button[contains(text(),'Log in')]"));


        [Test]
        [AllureSuite("suite name")]
        public void OpenSXATest()
        {
            ClickOnElement(franceButton);
            EnterTextToElement(userName, "super");
            EnterTextToElement(passWord, "brmv3");
            ClickOnElement(loginButton);

            Assert.That(webDriver.Title, Is.EqualTo("Home Page"));


        }

    }
}
