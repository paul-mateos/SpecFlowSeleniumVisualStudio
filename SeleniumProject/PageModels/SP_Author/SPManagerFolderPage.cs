using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class FolderPage : BasePage
    {

        By DocumentFolderTree = By.Id(" docexplorertree");
        By DocumentSelectorFolderTree = By.XPath("//div[@id='kWindow0']//div[@id=' docexplorertree']");
        By ImageFolderTree = By.XPath("//img-tree-drct/div");
        By ImageSelectorFolderTree = By.XPath("//*[@id='kWindow0']/div/div[1]/img-tree-drct/div");
        By ViewerFolderTree = By.Id("folders");
        By Folder = By.XPath("./ul/li");
                          

        public FolderPage(IWebDriver driver)
            : base(driver)
        {

        }

        public void ClickOnFolder(string Page, string[] Folders)
        {
            switch(Page)
            {
                case "Document":
                     UICommon.ClickOnFolder(Page, Folders, DocumentFolderTree, d);
                     break;
                case "Document Selector":
                     UICommon.ClickOnFolder(Page, Folders, DocumentSelectorFolderTree, d);
                     break;
                case "Image":
                     UICommon.ClickOnFolder(Page, Folders, ImageFolderTree, d);
                     break;
                case "Image Selector":
                     UICommon.ClickOnFolder(Page, Folders, ImageSelectorFolderTree, d);
                     break;
                case "Viewer":
                    UICommon.ClickOnViewerFolder(Page, Folders, ViewerFolderTree, d);
                    break;
                default:
                throw new Exception("Invalid page");
            }
            Thread.Sleep(3000); //this needs to be removed if other waits work

        }



       



           

            
        }


   

    }
