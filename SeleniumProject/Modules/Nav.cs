using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumProject.Commons;
using SeleniumProject.PageModels;
using SeleniumProject.PageModels.SP_Author;
using SeleniumProject.PageModels.SP_Viewer;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Modules
{
    /*
     *  Navigation Module
     * 
     */
    public class Nav : BaseWebDriverModule
    {

        public Nav(IWebDriver d) : base(d) { }

        public void ToFolder()
        {

            NavBarPage p = new NavBarPage(driver);
            p.ClickFolderButton();
        
            FoldersPage foldersPage = new FoldersPage(driver);
            Assert.IsTrue(foldersPage.GetFoldersDisplayProperty());
        }

        public void ToHome()
        {
            NavBarPage p = new NavBarPage(driver);
            p.ClickHomeButton();
            HomePage homepage = new HomePage(driver);
            Assert.IsTrue(homepage.GetWelcomeTitleDisplayProperty());
        }

        public void ToSupportPointManager(string managementPage)
        {
            string BaseWindow = driver.CurrentWindowHandle;
            new NavBarPage(driver).ClickSPManagerButton();
            SupportPoint.SwitchToBrowser(managementPage, BaseWindow);
            SupportPoint.IsCurrentBrowser(managementPage);
        }

    }
}
