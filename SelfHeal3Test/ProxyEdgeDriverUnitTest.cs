using Microsoft.Edge.SeleniumTools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SelfHeal3.Locators;
using SelfHeal3.Proxy;
using System;
using System.Reflection;

namespace SelfHeal3Test
{
    [TestClass]
    public class ProxyEdgeDriverUnitTest
    {



        [TestMethod]
        public void Test_Contructor()
        {
            EdgeOptions option = new EdgeOptions();
            option.UseChromium = true;
            option.AcceptInsecureCertificates = true;
            option.UnhandledPromptBehavior = UnhandledPromptBehavior.Accept;
            option.AddArgument("no-sandbox");

            var driverPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"/Driver/";


#pragma warning disable CS0618 // Type or member is obsolete
            IWebDriver delegatee = new EdgeDriver(driverPath,option);
#pragma warning restore CS0618 // Type or member is obsolete

            ILocator localImpl = new LocatorImplementation();

            IWebDriver driver = new ProxyEdgeDriver(delegatee, localImpl);

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
