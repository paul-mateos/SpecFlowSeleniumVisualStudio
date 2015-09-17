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
    public class WorkflowManagementPage : BasePage
    {
        
       //Search Criteria
        By workflowName = By.XPath("//input[@name='name']");

        //Buttons


        public WorkflowManagementPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Workflow Management : SupportPoint"); }); 
        }

        public string SetWorkflowName(string WorkflowName)
        {
            string newName = UICommon.getRandomName(WorkflowName);
            UICommon.SetValue(workflowName, newName, d);
            return newName;

        }

        public void ConfirmWorkflowName(string WorkflowName)
        {
            Assert.IsTrue(UICommon.GetElementAttribute(workflowName, "value", d) == WorkflowName);
        }
    }
}
