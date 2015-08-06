using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SP_Automation.PageModels;
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

        public void NavToFolder()
        {
            HomePage homepage = new HomePage(driver);
            Assert.IsTrue(homepage.GetWelcomeTitleDisplayProperty());
            homepage.ClickFolderNavButton();
            FoldersPage foldersPage = new FoldersPage(driver);
            Assert.IsTrue(foldersPage.GetFoldersDisplayProperty());
        }

      

    }
}
