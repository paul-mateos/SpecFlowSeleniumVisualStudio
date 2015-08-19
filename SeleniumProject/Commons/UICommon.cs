using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.Commons
{
    public class UICommon
    {
        public static int waitsec = Properties.Settings.Default.WaitTime;

        public static IWebElement GetElement(By searchType, IWebDriver d)
        {

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(searchType));
            elementHighlight(elem, d);
            return elem;

        }

        public static void ClickButton(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Click();
        }

        public static void DoubleClickButton(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            Actions action = new Actions(d);
            action.DoubleClick(elem);
            action.Perform();
        }

        /*annette added
                public bool Exist(By element)
        { 
           try 
            { 
               return ( new WebDriverWait(d, TimeSpan.FromSeconds(1)).Until(ExpectedConditions.ElementIsVisible(element)) != null );
             } catch (NoSuchElementException) { }

            return false;
        } */

        public static void SetValue(By searchType, string value, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Clear();
            elem.SendKeys(value);

        }

        public static void ClickMultipleSelection(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Click();
        }

        public static void SelectListValue(By searchType, string value, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            SelectElement selector = new SelectElement(elem);
            selector.SelectByText(value);
            
        }

        public static void elementHighlight(IWebElement element, IWebDriver d)
        {
           if (element.TagName != "a")
            {
                var jsDriver = (IJavaScriptExecutor)d;
                string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"" });";
                jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
            }
        }

        internal static void ClickLink(By by, IWebDriver d)
        {
            IWebElement elem = GetElement(by, d);
            elem.Click();
        }


        public static IWebDriver SwitchToNewBrowserWithTitle(IWebDriver d, string title)
        {
            //wait for another window to open
            for (int i = 1; i < 30; i++)
            {
                if (d.WindowHandles.Count == 1)
                {
                    Thread.Sleep(1000); 
                }
                else { break; }
            }

            for (int i = 1; i < 3; i++)
            {
                foreach (string handle in d.WindowHandles)
                {
                    if (d.SwitchTo().Window(handle).Title.Contains(title))
                    {
                        return d;
                    }
                    else
                    {
                        Thread.Sleep(2000);
                    }
                }
     
            }throw new Exception("Error switching to new browser");
        }

        public static IWebElement GetSearchResultTable(string tableName, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement webElementBody = wait.Until(ExpectedConditions.ElementIsVisible(By.Id(tableName)));
            return webElementBody;
        }
    }
}
