using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace SelfHeal3.Locators
{
    public interface ILocator
    {
        public Dictionary<string, IList<By>> GetLocatorList();
    }
}