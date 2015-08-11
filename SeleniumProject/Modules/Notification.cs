using OpenQA.Selenium;
using SP_Automation.PageModels;
using SP_Automation.PageModels.SP_Viewer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{
    public class Notification  : BaseWebDriverModule
    {
        public Notification(IWebDriver d) : base(d) { }

        public void ClickNotificationCenter()
        {
            NavBarPage pag = new NavBarPage(driver);
            pag.ClickNotification();
        }

    }
}
