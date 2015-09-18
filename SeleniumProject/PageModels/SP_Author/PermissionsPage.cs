using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.PageModels.SP_Author
{
    public class PermissionsPage : BasePage
    {
        By removeReaderRole = By.XPath("//button[@title='Remove role(s) from readers']");
        By addReaderRole = By.XPath("//button[@title='Add role to readers']");
        //By removeReaderUser = By.XPath("//button[@title='Remove user(s) from readers']");
        //By addReaderUser = By.XPath("//button[@title='Add use to readers']");
        //By removeWriterRole = By.XPath("//button[@title='Remove role(s) from writers']");
        //By addWriterRole = By.XPath("//button[@title='Add role to writers']");
        //By removeWriterUser = By.XPath("//button[@title='Remove user(s) from writers']");
        //By addWriterUser = By.XPath("//button[@title='Add use to writers']");
        //By removeOwnerRole = By.XPath("//button[@title='Remove role(s) from owners']");
        //By addOwnerRole = By.XPath("//button[@title='Add role to owners']");
        //By removeOwnerUser = By.XPath("//button[@title='Remove user(s) from owners']");
        //By addOwnerUser = By.XPath("//button[@title='Add use to owners']");

        public PermissionsPage(IWebDriver driver)
            : base(driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.WaitTime));
            wait.Until((d) => { return d.Title.Contains("Document Management : SupportPoint"); });
        }

        public void clickPermissionBtn(string newPermission)
        {
            Debug.WriteLine("3rd" + newPermission);
            By newPermissionBtn = null;
            if (newPermission.Equals("Remove role(s) from readers"))
            {
                newPermissionBtn = removeReaderRole;
            }
            else if (newPermission.Equals("Add role to readers"))
            {
                newPermissionBtn = addReaderRole;
            }

            UICommon.ClickButton(newPermissionBtn, d);
        }

    }
}
