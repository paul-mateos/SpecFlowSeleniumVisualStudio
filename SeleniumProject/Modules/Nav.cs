using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SP_Automation.PageModels;
using SP_Automation.PageModels.SP_Author;
using SP_Automation.PageModels.SP_Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
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

        public void ToSupportPointManager()
        {
            //todo
            new NavBarPage(driver).ClickSPManagerButton();
            //new DocumentManagementPage(driver);
            //new SPManagerNavBarPage(driver);
        }

    }
}
