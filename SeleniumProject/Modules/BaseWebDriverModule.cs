using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_Automation.Modules
{
    public abstract class BaseWebDriverModule
    {
        protected IWebDriver driver;
       
        public virtual IWebDriver GetDriver() { return driver; }
        public virtual void SetDriver(IWebDriver d) { driver = d; }

        protected BaseWebDriverModule(IWebDriver d) { SetDriver(d); }

       
    
    }
}
