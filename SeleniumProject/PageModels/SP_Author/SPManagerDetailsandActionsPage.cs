using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using SeleniumProject.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels
{
    public class SPManagerDetailsActionsPage : BasePage
    {
        //buttons
        By SaveBtn = By.XPath("//button[@title='Save']");
        By MoveBtn = By.XPath("//button[@title='Move']");
        By RemoveBtn = By.XPath("//button[@title='Remove']");
        By CancelBtn = By.XPath("//button[@title='Cancel']");
        By DeleteBtn = By.XPath("//button[@title='Delete']");
        By DeleteRoleBtn = By.XPath("//button[@title='Delete Role']");
        By EditBtn = By.XPath("//span[@title='Edit']");

        
        //menu options
        By DetailsandActions = By.XPath("//a/span[text()='Details & Actions']"); 
        By New = By.XPath("//a[@data-automation-id='doc-details-actions-new']");
        By Properties = By.XPath("//a[contains(text(),'Properties')]");
        By generalProperties = By.XPath("//a[@data-automation-id='doc-details-actions-general-properties']");
        By Rolemembership = By.XPath("//a[contains(text(),'Role membership')]");
        By TrainingObjectives = By.LinkText("Training objectives");
        By Readers = By.LinkText("Readers");
        By Writers = By.LinkText("Writers");
        By Notifications = By.XPath("//a[@data-automation-id='doc-details-actions-notifications']");
        By CustomProperties = By.LinkText("Custom properties");
        By Permissions = By.XPath("//a[@data-automation-id='doc-details-actions-permissions']");
        By RequiredApprovers = By.XPath("//div[@role='menu']/a[text()='Required approvers']");

        //Common fields
        By Name = By.XPath("//input[@name='name']");
        By Description = By.XPath("//input[@name='description']");

        By Namevalidation = By.XPath("//div/p[contains(text@,'Checking if the name requested is available.')]");
        public SPManagerDetailsActionsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public bool DetailsandActionsExists()
        {
            
            IReadOnlyCollection<IWebElement> elemets = d.FindElements(DetailsandActions);
            if (elemets.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void clickDetailsandActions()
        {
            UICommon.ClickLink(DetailsandActions, d);
            Thread.Sleep(1000);

        }

        public void clickEdit()
        {
                UICommon.ClickButton(EditBtn, d);
        }

        public void clickCancel()
        {
            UICommon.ClickButton(CancelBtn, d);
            UICommon.confirmToastInfoMessage("Changes cancelled", d);
        }

        public void clickDelete()
        {
            UICommon.ClickButton(DeleteBtn, d);
            Thread.Sleep(1000);
        }

        public void clickDeleteRole()
        {
            UICommon.ClickButton(DeleteRoleBtn, d);
        }

        public void clickSave()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
                wait.Until(ExpectedConditions.ElementToBeClickable(SaveBtn));
                UICommon.ClickButton(SaveBtn, d);
                UICommon.confirmToastSuccessMessage("Changes saved", d);
            }
            catch(Exception ex)
            {
                throw new Exception("Can not click the save button", ex);
            }
            
        }

        public void NoEdit()
        {
            Thread.Sleep(3000);
            IReadOnlyCollection<IWebElement> elements = UICommon.GetElements(EditBtn, d);
            Assert.IsTrue(elements.Count==0);
        }

        public void SelectFromDnAList(string detailsAction)
        {
            switch(detailsAction)
            {
                case "New":
                    UICommon.ClickLink(New, d);
                    break;
                case "Properties":
                    UICommon.ClickLink(Properties, d);
                    break;
                case "General properties":
                    UICommon.ClickLink(generalProperties, d);
                    break;
                case "Permissions":
                    UICommon.ClickLink(Permissions, d);
                    break;
                case "Required approvers":
                    UICommon.ClickLink(RequiredApprovers, d);
                    break;
                case "Role membership":
                    UICommon.ClickLink(Rolemembership, d);
                    break;
                case "Readers":
                    UICommon.ClickLink(Readers, d);
                    break;
                case "Writers":
                    UICommon.ClickLink(Writers, d);
                    break;
                default:
                    throw new Exception("Invalid list item");
                    
            }
            Thread.Sleep(1000);
        }

        public string SetDescription(string description)
        {
            UICommon.SetValue(Description, description, d);
            return description;
        }

        public string SetRandomName(string randomName)
        {
            string newName = UICommon.getRandomName(randomName);
            UICommon.SetValue(Name, newName, d);
            var wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Namevalidation));
            return newName;

        }

        public void ConfirmName(string name)
        {
            Assert.IsTrue(UICommon.GetElementAttribute(Name, "value", d) == name);
        }

        public void ConfirmDescription(string description)
        {
            Assert.IsTrue(UICommon.GetElementAttribute(Description, "value", d) == description);
        }

        public string SetName(string name)
        {

            UICommon.SetValue(Name, name, d);
            var wait = new WebDriverWait(d, TimeSpan.FromSeconds(waitsec));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Namevalidation));
            return name;

        }
    }
}
