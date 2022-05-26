using OpenQA.Selenium;
using SelfHeal3.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHeal3Test
{
    class LocatorImplementation : ILocator
    {
        public Dictionary<string, IList<By>> GetLocatorList()
        {
            return new Dictionary<string, IList<By>>()
            {
                { "Default".ToString().Trim(), new List<By>() { By.XPath("//a[@href='/FixCoPortal']") } }
            };
        }
    }
}
