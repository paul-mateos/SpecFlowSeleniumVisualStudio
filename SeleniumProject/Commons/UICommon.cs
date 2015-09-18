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

namespace SeleniumProject.Commons
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

        public static IReadOnlyCollection<IWebElement> GetElements(By searchType, IWebDriver d)
        {
            return d.FindElements(searchType);
        }

        public static void ClickButton(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            Actions action = new Actions(d);
            action.MoveToElement(elem).Click().Build().Perform();
            Thread.Sleep(1000);
            
        }

        public static void DoubleClickButton(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            Actions action = new Actions(d);
            action.DoubleClick(elem);
            action.Perform();
        }

        public static void SetValue(By searchType, string value, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Clear();
            elem.SendKeys(value);
            Thread.Sleep(1000);

        }

        public static void ClickMultipleSelection(By searchType, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Click();
        }

        public static void SelectListValue(By searchType, string value, IWebDriver d)
        {
            IWebElement elem = GetElement(searchType, d);
            elem.Click();
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
            Thread.Sleep(1000);
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

        public static IWebElement GetSearchResultTable(By searchTableBy, IWebDriver d)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement webElementBody = wait.Until(ExpectedConditions.ElementIsVisible(searchTableBy));
            return webElementBody;
        }

        public static string GetElementAttribute(By searchType, string attribute, IWebDriver d)
        {

            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            IWebElement elem = wait.Until(ExpectedConditions.ElementIsVisible(searchType));
            elementHighlight(elem, d);
            return elem.GetAttribute(attribute);

        }

        public static IWebElement GetFolderTree(By searchBy, IWebDriver d)
        {
            IWebElement elem = UICommon.GetElement(searchBy, d);
            return elem;
        }

        public static void ClickOnFolder(string Page, string[] Folders, By FolderTree,IWebDriver d)
        {
            //get folder tree element
            IWebElement folderTree;     
            folderTree = GetFolderTree(FolderTree, d);        
            //count the number of indexes
            int folderTreeDepth = Folders.Count();

            for (int i = 0; i < folderTreeDepth; i++)
            {
                //get the name of the current folder
                bool folderFound = false;
                string FolderName = Folders[i];
                //get the number of available parent folders in docexplorertree

                IReadOnlyCollection<IWebElement> folders = folderTree.FindElements(By.XPath("./ul/li"));

                //check each parent folder in tree. Go to exception if non are found         
                foreach (IWebElement folder in folders)
                {
                    IWebElement folderText = folder.FindElement(By.CssSelector("div span span"));
                    if (folderText.Text == FolderName)
                    {
                        //Expand the folder
                        if (folder.GetAttribute("aria-expanded") != "true")
                        {
                            Actions action = new Actions(d);
                            action.DoubleClick(folderText).Build().Perform();
                            folderTree = folder;
                            folderFound = true;
                            break;
                        }
                        else
                        {
                            Actions action = new Actions(d);
                            action.MoveToElement(folderText).Click().Build().Perform();
                            folderTree = folder;
                            folderFound = true;
                            break;
                        }
                    }
                } 
                if (folderFound == false)
                {
                    throw new Exception("Folder could not be found");
                }
            }
        }

        public static bool FindGridRecord(string Record, By Grid, IWebDriver d)
        {
            //get folder tree element
            IWebElement grid;
            grid = GetFolderTree(Grid, d);
               
                //get the number of available parent folders in docexplorertree

                IReadOnlyCollection<IWebElement> records = grid.FindElements(By.XPath("./ul/li"));

                //check each parent folder in tree. Go to exception if non are found         
                foreach (IWebElement record in records)
                {
                    if (record.Text.Contains(Record))
                    {
                        return true;
                     }
                }
                return false;
  
        }

        public static string getRandomName(string name)
        {
            string currentTime = DateTime.Now.ToString("hmmss");
            return name + currentTime;
        }

    }
}
