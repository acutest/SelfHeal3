# SelfHeal
---
SelfHeal is an implemenation of Selenium WebDriver (3.141.0). Allowing projects to make use of multiple locators when using findElement method. 
The aim of the project is to allow users who have problems with broken locators to have an altarnative instead of failing the test.    


## Documenation

### 1. Implement ILocator interface

```cs
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace SelfHeal.LocatorImplementation
{
    public class LocatorImplementation : ILocator
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
```

Replace the "Default" string with page object reference.  
Example:  
From- "Default".ToString().Trim()   
To-  WebAppTestTargetNavigationBar.FixCoPortalNavigationButton.ToString().Trim()    


### 2. In Hooks file create an instance of ProxyChromeDriver using param WebDriver object and instance of ILocator object.
```cs
ChromeOptions option = new ChromeOptions();
option.AddArgument("no-sandbox");

IWebDriver delegatee = new ChromeDriver(option);

ILocator localImpl = new LocatorImplementation();

IWebDriver driver = new ProxyChromeDriver(delegatee, localImpl);

driver.Navigate().GoToUrl("https://www.google.com");
```





