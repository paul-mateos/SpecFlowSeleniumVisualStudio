using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SP_Automation.PageModels;
using SP_Automation.PageModels.SP_Viewer;

namespace SP_Automation.Tests
{
    [TestClass]
    public class FolderNavTest : BaseTest
    {
        [TestMethod]
        public void navToFolder()
        {
            HomePage homepage = new HomePage(driver);
            Assert.IsTrue(homepage.GetWelcomeTitleDisplayProperty());
            homepage.ClickFolderNavButton();
            FoldersPage foldersPage = new FoldersPage(driver);
            Assert.IsTrue(foldersPage.GetFoldersDisplayProperty());
        }

        public void verifyFolderExist()
        {
            Assert.IsTrue(true);
        }
    }
}
