using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.PageModels.SP_Author
{
    public class SPManagerFolderPage : BasePage
    {
        
        By FolderTree = By.Id(" docexplorertree");
        By Folder = By.XPath("./ul/li");
        By NavFolder = By.XPath("//div[@id=' docexplorertree']/ul/li[1]/div/span[1]");
                   

                   

        public SPManagerFolderPage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement GetFolderTree()
        {
            IWebElement elem = UICommon.GetElement(FolderTree, d);
            return elem;
        }

        public void ClickOnFolder(string[] Folders)
        {
           
            //count the number of indexes
            int folderTreeDepth = Folders.Count();
            //get folder tree element
            IWebElement folderTree = this.GetFolderTree();

            for(int i = 0; i< folderTreeDepth; i++)
            {
                //get the name of the current folder
                string FolderName = Folders[i];
                //get the number of available parent folders in docexplorertree
               
                IReadOnlyCollection<IWebElement> folders = folderTree.FindElements(Folder);

                //check each parent folder in tree
                foreach(IWebElement folder in folders)
                {
                   
                    if(folder.FindElement(By.CssSelector("div span span")).Text == FolderName)
                    {
                        //Expand the folder
                        if(folder.GetAttribute("aria-expanded") != "true")
                        {
                            Actions action = new Actions(d);
                            action.DoubleClick(folder).Build().Perform();
                            folderTree = folder;
                        }
                        else
                        {
                            folder.FindElement(By.CssSelector("div span span")).Click();    
                            folderTree = folder;
                        }
                        
                        break;
                    }
                }

            }

        }



        public void clickFolder()
        {
            Console.WriteLine(NavFolder);
           IWebElement elem = UICommon.GetElement(NavFolder, d);
           
            String cssvalue = elem.GetAttribute("class");
            if (cssvalue.Equals("k-icon k-plus"))
            {
                //UICommon.DoubleClickButton(HomeFolder, d);
            }
            else
            {
                //UICommon.ClickButton(HomeFolder, d);
        }
        }



           

            
        }


   

    }
