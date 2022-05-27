using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using SelfHeal3.Locators;
using SelfHeal3.Proxy;
using System;

namespace SelfHeal3Test
{
    [TestClass]
    public class ProxyFirefoxDriverUnitTest
    {



        [TestMethod]
        public void Test_Contructor()
        {
            //FireFoxOptions option = new FireFoxOptions();
            //option.AddArgument("no-sandbox");

            IWebDriver delegatee = new FirefoxDriver();

            ILocator localImpl = new LocatorImplementation();

            IWebDriver driver = new ProxyFirefoxDriver(delegatee, localImpl);

            driver.Navigate().GoToUrl("https://www.google.com");

            try
            {
                driver.FindElement(By.XPath("//*[text()='I agree']")).Click();
            }
            catch (Exception)
            {

              
            }

            try
            {
                IWebElement el = driver.FindElement(By.XPath("//input[@title='Search']"));
                el.SendKeys("hello world");
                el.SendKeys((Keys.Return));
                driver.Quit();
            }
            catch (Exception e)
            {
                driver.Quit();
                Assert.Fail(e.Message);
            }
          


        }
    }
}
