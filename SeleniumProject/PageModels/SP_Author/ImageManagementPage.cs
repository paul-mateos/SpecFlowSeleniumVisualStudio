using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SP_Automation.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SP_Automation.PageModels;
using SP_Automation.Tests;

namespace SP_Automation.PageModels.SP_Author
{
    public class ImageManagementPage : BasePage
    {
        public static int waitsec = Properties.Settings.Default.WaitTime;

       //Search Criteria
        By imageSearchBy = By.Id("imgSearchType");
        By imgSearchQuery = By.Id("imgSearchQuery");
        By submitSearchButton = By.XPath("//button[@type='submit']");
        By resetSearchButton = By.XPath("//button[@type='reset']");
        By imgGridList = By.ClassName("img-grid-list");
        By imgName = By.Id("imgName");
        By imgId = By.Id("imgId");
        By CPString = By.Name("175452");  //Need to have this changed by dev
        // moveButton = By.XPath("//*[@id='imgMenu']/ul[2]/li[1]/button");
        By moveButton = By.XPath("//button[@type='button' and contains(text(), 'Move') and not(contains(@ng-disabled, 'areButtonsDisabled'))]");
        By RemoveButton = By.XPath("//button[@type='button' and contains(text(), 'Remove') and not(contains(@ng-disabled, 'areButtonsDisabled'))]");
        //Image Folder Popup
        By imageFolderPopup = By.XPath("//*[@id='kWindow0']/div/div[1]/img-tree-drct/div");

        public ImageManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Image Management : SupportPoint"); }); 
        }

        public void SelectFindBy(string findBy)
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec)); 
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[@aria-owns='imgSearchType_listbox']"))).Click();
            Thread.Sleep(2000);
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul[@id='imgSearchType_listbox']/li[text()='"+findBy+"']"))).Click();
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(imgSearchQuery, searchText, d);
        }

        public void ClickSubmitSearchButton()
        {
            UICommon.ClickButton(submitSearchButton, d);
        }

        public void ConfirmFoundImage(string FindBy, string SearchText)
        {
            Thread.Sleep(5000);
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
             IWebElement imageGrid = wait.Until(ExpectedConditions.ElementIsVisible(imgGridList));
             IReadOnlyCollection<IWebElement> images = imageGrid.FindElements(By.XPath("./li"));
             if (images.Count == 0)
             {
                 throw new Exception("No Records Found");
             }
             switch (FindBy)
             {
                 case "Name":
                     Assert.IsTrue(SearchImageList(SearchText, images, FindBy));
                         break;
                 case "ID":
                      Assert.IsTrue(SearchImageList(SearchText, images, FindBy));
                         break;
                 case "Custom property":
                         Assert.IsTrue(SearchImageList(SearchText, images, FindBy));
                         break;
                 default:
                     throw new Exception("Invalid FindBy");
             }


        }

        private bool SearchImageList(string SearchText, IReadOnlyCollection<IWebElement> images, string FindBy)
        {

            IWebElement nextPage;

            do
            {
                for (int i = 0; i < images.Count; i++)
                {
                    Thread.Sleep(2000);
                
                    //if (SupportPoint.SPManagerDetailsActionsPage.DetailsandActionsExists() == false)
                    if (images.ElementAt(i).GetAttribute("class") != "img-grid-item ng-scope img-grid-item-selected")
                    {
                        images.ElementAt(i).Click();
                    }
               
                    switch (FindBy)
                    {
                        case "Name":
                        IWebElement ImageName = UICommon.GetElement(imgName, d);
                        if (SearchText == ImageName.GetAttribute("value"))
                            {
                                return true;
                            }
                            break;
                        case "ID":
                            IWebElement ImageID = UICommon.GetElement(imgId, d);
                            if (SearchText == ImageID.GetAttribute("value"))
                            {
                                return true;
                            }
                            break;
                        case "Custom property":
                            IWebElement CustomPropertyString = UICommon.GetElement(CPString, d);
                            if (SearchText == CustomPropertyString.GetAttribute("value"))
                            {
                                return true;
                            }
                            break;
                        default:
                            throw new Exception("Invalid findBy");
                        
                    }
                }   
                 nextPage = d.FindElement(By.XPath("//a(@title='Go to the next page']"));
                if (nextPage.GetAttribute("class") == "k-link k-pager-nav")
                {
                    nextPage.Click();
                }
            } 
            while (nextPage.GetAttribute("class") == "k-link k-pager-nav"); 
            throw new Exception("Find By search query was not found");
        }

        public void ClickMoveButton()
        {
            UICommon.ClickButton(moveButton, d);
        }

        public void ClickRemoveButton()
        {
            UICommon.ClickButton(RemoveButton, d);
        }

        public void ConfirmRemovalMessage()
        {
            IWebElement elem = d.FindElement(By.XPath("//div[(@id='kWindow0')]/div[contains(text(),'Remove the selected image?')]"));
            elem.FindElement(By.XPath("//button[@title='OK']")).Click();
        }
    }
}
