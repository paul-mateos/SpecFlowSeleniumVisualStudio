using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SP_Automation.Environments;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_Automation.Tests
{
    [TestClass]
    public abstract class BaseTest
    {
        protected IWebDriver driver;   //changed this to static so that it can be shared
        protected TestEnvironment environment;
        
        
        public virtual IWebDriver getDriver()
        {
            return driver;
        }

        public virtual void setDriver(IWebDriver d)
        {
            driver = d;
        }

        public virtual BaseTest setPrevTest(BaseTest t)
        {
            setDriver(t.getDriver());
            return this;
        }

        [TestInitialize]
        public virtual void Initialize()
        {
            TestCleanUp(); //just in case previous test not cleanup properly
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                    //driver = new InternetExplorerDriver(options);
                    setDriver(new InternetExplorerDriver(options));
                    break;
                case BrowserType.Chrome:
                    setDriver(new ChromeDriver());

                    break;
                case BrowserType.NodeWebkit:
                    setDriver(new ChromeDriver(@"C:\Program Files (x86)\Panviva\SupportPoint Viewer\"));
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }
      
        }

        [TestCleanup]
        public virtual void TestCleanUp()
        {
            if (getDriver() != null) getDriver().Quit();

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                   
                    KillProcess("iexplorer.exe");
                    KillProcess("IEDriverServer.exe");
                    break;
                case BrowserType.Chrome:                 
                    KillProcess("chrome.exe");
                    break;
                case BrowserType.NodeWebkit:
                    KillProcess("Viewer.exe");
                    KillProcess("chromedriver.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
    }
}
