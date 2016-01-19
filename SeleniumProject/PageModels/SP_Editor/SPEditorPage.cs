using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Editor
{
   public class SPEditorPage : BasePage
    {
        //Search Criteria
        By imageMapButton = By.CssSelector("span[id='btn_toolbar_imagemap']");
        By moreMenu = By.Id("EditorMoreMenu");
        By saveButton = By.XPath("//div/span[@title='Save (Ctrl+S)']");

        //more menu
        By Close = By.LinkText("Close");

        public void clickSave()
        {
            UICommon.ClickButton(saveButton, d);
        }
        

        public SPEditorPage(IWebDriver driver)
            : base(driver)
        {

        }

        public void ClickImageMapButton()
        {
            UICommon.ClickButton(imageMapButton, d);
        }

        public void ClickMoreMenu()
        {
            UICommon.ClickButton(moreMenu, d);
        }
        
        public bool ConfirmEditDocumentTitle(string docName)
        {
            IWebElement elem = d.FindElement(By.XPath("//div[(@class='document-content-title' and contains(@title,'" + docName+"'))]"));
            Thread.Sleep(1000);//Need to remove this once there is a page flag created
            return true;
        }
        
        public void SelectFromMoreMenuList(string actions)
        {
            switch (actions)
            {
                case "Close":
                    UICommon.ClickLink(Close, d);
                    break;
                default:
                    break;
            }
            Thread.Sleep(1000);
        }

    }
}
