using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;


namespace SelfHeal3
{
    public class PageAwareBy : By
    {
        public string PageName { get; private set; }
        public By by { get; private set; }
        public String Key { get; set; }
        public NoSuchElementException Exception { get; set; }

        public PageAwareBy(string pageName, By by)
        {
            PageName = pageName;
            this.by = by;
            this.Key = $"{by.ToString().Trim()}";
            //this.Key = $"{pageName.ToString().Trim()}";
        }

        public static PageAwareBy By(String pageName,By by)
        {
            return new PageAwareBy(pageName, by);
        }


  
        override
        public ReadOnlyCollection<IWebElement> FindElements(ISearchContext context) 
        {
            return by.FindElements(context);
        }



        override
        public string ToString() 
        {
            return $"{by} on page {PageName}";
        }

    }
}
