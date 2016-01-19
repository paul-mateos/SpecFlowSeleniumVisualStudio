using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Editor
{
    public class ImageSelectorPage : BasePage
    {
        By Title = By.XPath("//div[@id='ImageSelectorPopupContainer']//div[(@class='editor-modal-title' and text() = 'Image Selector')]");
       
        By FindList = By.Id("searchTypeImage");
       
        By SearchText = By.Id("searchItemImageEditor");
        By SearchBtn = By.XPath("//div[@id='ImageSelectorPopupContainer']//table//span[@title='Search']");
        By InsertButton = By.Id("btnSave_ImageSelection");
        By imgGridList = By.Id("ImageFolderContainer");

        By nextPageButton = By.XPath("//a[@title='Go to the next page']");
       

        public ImageSelectorPage(IWebDriver driver)
            : base(driver)
        {
           
        }

        public void ConfirmImageSelector()
        {
            WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.ElementExists(Title));
            Thread.Sleep(3000); // This needs to be removed once UI is fixed with loading method
        }


        public void SelectFindBy(string findBy)
        {
            UICommon.SelectListValue(FindList, findBy, d);       
        }

        public void SetSearchText(string searchText)
        {
            UICommon.SetValue(SearchText, searchText, d);
        }

        public void ClickSearchButton()
        {
            UICommon.ClickButton(SearchBtn,d);
        }

        public void ClickInsertButton()
        {
            UICommon.ClickButton(InsertButton, d);
        }
        

        public void ConfirmFoundImage(string FindBy, string SearchText)
        {
            Thread.Sleep(5000);
            //IWebElement nextPage;
            bool continueLoop = true;
            while (continueLoop)
            {
                WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
                IWebElement imageGrid = wait.Until(ExpectedConditions.ElementIsVisible(imgGridList));
                IReadOnlyCollection<IWebElement> images = imageGrid.FindElements(By.XPath("./div[@class='imageWrapper']"));
                if (images.Count == 0)
                {
                    throw new Exception("No Records Found");
                }
                switch (FindBy)
                {
                    case "Name":
                        if (SearchImageList(SearchText, images, FindBy) == true)
                        {
                            continueLoop = false;
                        }
                        break;
                    case "ID":
                        if (SearchImageList(SearchText, images, FindBy) == true)
                        {
                            continueLoop = false;
                        }
                        break;
                    case "Custom property":
                        if (SearchImageList(SearchText, images, FindBy) == true)
                        {
                            continueLoop = false;
                        }
                        break;
                    default:
                        throw new Exception("Invalid FindBy");
                }

                if (UICommon.GetElementAttribute(nextPageButton, "class", d) == "k-link k-pager-nav")
                {
                    UICommon.GetElement(nextPageButton, d).Click();
                }
            }
        }

        private bool SearchImageList(string SearchText, IReadOnlyCollection<IWebElement> images, string FindBy)
        {
            IWebElement image;
            for (int i = 0; i < images.Count; i++)
            {
                Thread.Sleep(2000);

                if (images.ElementAt(i).GetAttribute("class") != "imageWrapper k-state-selected")
                {
                    images.ElementAt(i).Click();
                }

                switch (FindBy)
                {
                    case "Name":
                        image = images.ElementAt(i);
                        image.FindElement(By.XPath("//div/img[@title='" + SearchText + "']"));
                        return true;
                        
                    case "ID":
                        image = images.ElementAt(i);
                        image.FindElement(By.XPath("//div/img[contains(@src,'" + SearchText + "')]"));
                        return true;

                    case "Custom property":
                        //IWebElement CustomPropertyString = UICommon.GetElement(CPString, d);
                        //if (SearchText == CustomPropertyString.GetAttribute("value"))
                        //{
                        //    return true;
                        //}
                        break;
                    default:
                        throw new Exception("Invalid findBy");

                }
            }
            return false;
        }

    }
    
}

