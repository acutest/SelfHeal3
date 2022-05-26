using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Safari;
using SelfHeal3.Locators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHeal3.Proxy
{
    public class ProxySafariDriver : IWebDriver, ITakesScreenshot, IJavaScriptExecutor, IFindsById, IFindsByClassName, IFindsByLinkText, IFindsByName, IFindsByTagName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, IHasCapabilities
    {
        private readonly SafariDriver _driver;
        private readonly ILocator _locator;


        public ProxySafariDriver(IWebDriver driver, ILocator locator)
        {
            this._driver = (SafariDriver)driver;
            this._locator = locator;

        }

        public string Url { get => ((IWebDriver)_driver).Url; set => ((IWebDriver)_driver).Url = value; }

        public string Title => ((IWebDriver)_driver).Title;

        public string PageSource => ((IWebDriver)_driver).PageSource;

        public string CurrentWindowHandle => ((IWebDriver)_driver).CurrentWindowHandle;

        public ReadOnlyCollection<string> WindowHandles => ((IWebDriver)_driver).WindowHandles;

        public ICapabilities Capabilities => ((IHasCapabilities)_driver).Capabilities;

        public void Close()
        {
            ((IWebDriver)_driver).Close();
        }

        public void Dispose()
        {
            ((IDisposable)_driver).Dispose();
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteAsyncScript(script, args);
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
        }

        public IWebElement FindElement(By by)
        {
            
            PageAwareBy pageBy = PageAwareBy.By(((IWebDriver)_driver).Title, by);
           
            bool run = true;
            do
            {
                try
                {
                    return ((ISearchContext)_driver).FindElement(pageBy.by);
                }
                catch (NoSuchElementException e)
                {
                    pageBy.Exception = e;

                    var dicList = _locator.GetLocatorList(); 
                    IList<By> list;
                    try
                    {
                        list = dicList[pageBy.Key];
                    }
                    catch (KeyNotFoundException)
                    {

                        list = new List<By>();
                    }

                   
                    foreach (By locator in list)
                    {

                        try
                        {
                            return ((ISearchContext)_driver).FindElement(locator);

                        }
                        catch (NoSuchElementException)
                        {
                            continue;
                        }

                    }

                    run = false;





                }
            } while (run);

            throw new NoSuchElementException(pageBy.Exception.Message);


        }

        public IWebElement FindElementByClassName(string className)
        {
            return ((IFindsByClassName)_driver).FindElementByClassName(className);
        }

        public IWebElement FindElementByCssSelector(string cssSelector)
        {
            return ((IFindsByCssSelector)_driver).FindElementByCssSelector(cssSelector);
        }

        public IWebElement FindElementById(string id)
        {
            return ((IFindsById)_driver).FindElementById(id);
        }

        public IWebElement FindElementByLinkText(string linkText)
        {
            return ((IFindsByLinkText)_driver).FindElementByLinkText(linkText);
        }

        public IWebElement FindElementByName(string name)
        {
            return ((IFindsByName)_driver).FindElementByName(name);
        }

        public IWebElement FindElementByPartialLinkText(string partialLinkText)
        {
            return ((IFindsByPartialLinkText)_driver).FindElementByPartialLinkText(partialLinkText);
        }

        public IWebElement FindElementByTagName(string tagName)
        {
            return ((IFindsByTagName)_driver).FindElementByTagName(tagName);
        }

        public IWebElement FindElementByXPath(string xpath)
        {
            return ((IFindsByXPath)_driver).FindElementByXPath(xpath);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return ((ISearchContext)_driver).FindElements(by);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByClassName(string className)
        {
            return ((IFindsByClassName)_driver).FindElementsByClassName(className);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByCssSelector(string cssSelector)
        {
            return ((IFindsByCssSelector)_driver).FindElementsByCssSelector(cssSelector);
        }

        public ReadOnlyCollection<IWebElement> FindElementsById(string id)
        {
            return ((IFindsById)_driver).FindElementsById(id);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByLinkText(string linkText)
        {
            return ((IFindsByLinkText)_driver).FindElementsByLinkText(linkText);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByName(string name)
        {
            return ((IFindsByName)_driver).FindElementsByName(name);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByPartialLinkText(string partialLinkText)
        {
            return ((IFindsByPartialLinkText)_driver).FindElementsByPartialLinkText(partialLinkText);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByTagName(string tagName)
        {
            return ((IFindsByTagName)_driver).FindElementsByTagName(tagName);
        }

        public ReadOnlyCollection<IWebElement> FindElementsByXPath(string xpath)
        {
            return ((IFindsByXPath)_driver).FindElementsByXPath(xpath);
        }

        public Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot();
        }

        public IOptions Manage()
        {
            return ((IWebDriver)_driver).Manage();
        }

        public INavigation Navigate()
        {
            return ((IWebDriver)_driver).Navigate();
        }

        public void Quit()
        {
            ((IWebDriver)_driver).Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return ((IWebDriver)_driver).SwitchTo();
        }
    }
}
