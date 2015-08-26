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
        
        By DocumentFolderTree = By.Id(" docexplorertree");
        By ImagePopupFolderTree = By.XPath("//*[@id='kWindow0']/div/div[1]/img-tree-drct/div");
        By ImageFolderTree = By.XPath("//img-tree-drct/div");
        By Folder = By.XPath("./ul/li");
        //By NavFolder = By.XPath("//div[@id=' docexplorertree']/ul/li[1]/div/span[1]");
                   

                   

        public SPManagerFolderPage(IWebDriver driver)
            : base(driver)
        {

        }

        public IWebElement GetFolderTree(By searchBy)
        {
            IWebElement elem = UICommon.GetElement(searchBy, d);
            return elem;
        }

        public void ClickOnFolder(string Page, string[] Folders)
        {
            //get folder tree element
            IWebElement folderTree;
            switch(Page)
            {
                case "Document":
                     folderTree = this.GetFolderTree(DocumentFolderTree);
                     break;
                case "Image":
                     folderTree = this.GetFolderTree(ImageFolderTree);
                     break;
                case "Image Popup":
                     folderTree = this.GetFolderTree(ImagePopupFolderTree);
                     break;
                default:
                throw new Exception("Invalid page");
            }
            
            
            //count the number of indexes
            int folderTreeDepth = Folders.Count();
            

            for(int i = 0; i< folderTreeDepth; i++)
            {
                //get the name of the current folder
                string FolderName = Folders[i];
                //get the number of available parent folders in docexplorertree
               
                IReadOnlyCollection<IWebElement> folders = folderTree.FindElements(Folder);

                //check each parent folder in tree
                foreach(IWebElement folder in folders)
                {
                    IWebElement folderText = folder.FindElement(By.CssSelector("div span span"));
                    if (folderText.Text == FolderName)
                    {
                        //Expand the folder
                        if(folder.GetAttribute("aria-expanded") != "true")
                        {
                            Actions action = new Actions(d);
                            action.DoubleClick(folderText).Build().Perform();
                            folderTree = folder;
                        }
                        else
                        {
                            Actions action = new Actions(d);
                            action.MoveToElement(folderText).Click().Build().Perform();
                            folderTree = folder;
                        }
                        
                        break;
                    }
                }

            }

        }



        public void clickFolder()
        {
           /* Console.WriteLine(NavFolder);
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
            * */
        }



           

            
        }


   

    }
