﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SeleniumProject.Commons;
using SeleniumProject.Environments;
using SeleniumProject.PageModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SeleniumProject.Modules;
using SeleniumProject.PageModels.SP_Author;
using SeleniumProject.Utility;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Configuration;
using System.Globalization;
using System.ComponentModel;
using System.Collections.Specialized;
using SeleniumProject.PageModels.SP_Editor;
using SeleniumProject.PageModels.SP_Viewer;

namespace SeleniumProject.Tests
{
     public class SupportPoint 
    {
        static public IWebDriver WebDriver {get; set;}

        /* 
         * Modules
         */

        static public LogIn LogIn { get { return new LogIn(WebDriver); } set { LogIn = value; } }
        static public Nav Nav { get {return  new Nav(WebDriver);} set {Nav = value;} }
        static public Notification Notification { get { return new Notification(WebDriver); } set { Notification = value; } }
        static public CopyPage CopyPage { get { return new CopyPage(WebDriver); } set { CopyPage = value; } }


        //static public DELETEActions Actions { get { return new DELETEActions(WebDriver); } set { Actions = value; } }
        /*
         *  Page Models
         *  */
        //SP Viewer Pages
        static public HomePage HomePage { get { return new HomePage(WebDriver); } set { HomePage = value; } }

        //SP Author Pages
        static public SPManagerNavBarPage SPManagerNav { get { return new SPManagerNavBarPage(WebDriver); } set { SPManagerNav = value; } }
        static public SPManagerFindBarPage SPManagerFind { get { return new SPManagerFindBarPage(WebDriver); } set { SPManagerFind = value; } }
        static public DocumentManagementPage DocumentManagementPage { get { return new DocumentManagementPage(WebDriver); } set { DocumentManagementPage = value; } }
        static public DocumentSelectorPage DocumentSelectorPage { get { return new DocumentSelectorPage(WebDriver); } set { DocumentSelectorPage = value; } }
        static public FolderPage FolderPage { get { return new FolderPage(WebDriver); } set { FolderPage = value; } }
        static public ImageManagementPage ImageManagementPage { get { return new ImageManagementPage(WebDriver); } set { ImageManagementPage = value; } }
        static public WorkflowManagementPage WorkflowManagementPage { get { return new WorkflowManagementPage(WebDriver); } set { WorkflowManagementPage = value; } }
        static public RoleManagementPage RoleManagementPage { get { return new RoleManagementPage(WebDriver); } set { RoleManagementPage = value; } }
        static public UserManagementPage UserManagementPage { get { return new UserManagementPage(WebDriver); } set { UserManagementPage = value; } }
        static public DocumentManagmentNewPage DocumentManagmentNewPage { get { return new DocumentManagmentNewPage(WebDriver); } set { DocumentManagmentNewPage = value; } }
        static public SPManagerDetailsActionsPage SPManagerDetailsActionsPage { get { return new SPManagerDetailsActionsPage(WebDriver); } set { SPManagerDetailsActionsPage = value; } }
        static public SPManagerActionsPage SPManagerActionsPage { get { return new SPManagerActionsPage(WebDriver); } set { SPManagerActionsPage = value; } }
        static public PermissionsPage PermissionsPage { get { return new PermissionsPage(WebDriver); } set { PermissionsPage = value; } }
        static public RoleSelectorPage RoleSelectorPage { get { return new RoleSelectorPage(WebDriver); } set { RoleSelectorPage = value; } }
        static public UserSelectorPage UserSelectorPage { get { return new UserSelectorPage(WebDriver); } set { UserSelectorPage = value; } }
        static public SPAuthorPage SPAuthorPage { get { return new SPAuthorPage(WebDriver); } set { SPAuthorPage = value; } }
        static public AdminPage AdminPage { get { return new AdminPage(WebDriver); } set { AdminPage = value; } }
        static public DocumentPreviewPage DocumentPreviewPage { get { return new DocumentPreviewPage(WebDriver); } set { DocumentPreviewPage = value; } }
        static public ChangePasswordPage ChangePasswordPage { get { return new ChangePasswordPage(WebDriver); } set { ChangePasswordPage = value; } }

        //SP Editor Pages
        static public SPEditorPage SPEditorPage { get { return new SPEditorPage(WebDriver); } set { SPEditorPage = value; } }
        static public ImageSelectorPage ImageSelectorPage { get { return new ImageSelectorPage(WebDriver); } set { ImageSelectorPage = value; } }
        static public ImageMappingPage ImageMappingPage { get { return new ImageMappingPage(WebDriver); } set { ImageMappingPage = value; } }
        static public SavePage SavePage { get { return new SavePage(WebDriver); } set { SavePage = value; } }

        static public string environment;
        static public string protocol;
        static public BrowserType browser;
        static public int waitsec;
        
        public SupportPoint()
        {
            System.Configuration.Configuration config =
                    ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None) as Configuration;


            environment = ConfigurationManager.AppSettings.Get("Environment");
            browser = (BrowserType)Enum.Parse(typeof(BrowserType), ConfigurationManager.AppSettings.Get("Browser"));
            protocol = ConfigurationManager.AppSettings.Get("Protocol");
            waitsec = Int32.Parse(ConfigurationManager.AppSettings.Get("WaitSec"));

        }
        
        /*
         * Open Support Point app: if there is existing one, it will kill it
         */
        static public void OpenSupportPoint()
        {
            
            ExitSuportPoint(); //just in case previous test not cleanup properly

            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            DesiredCapabilities capability;
            switch (browser)//Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                    WebDriver = (new InternetExplorerDriver(options));
                    WebDriver.Navigate().GoToUrl(protocol + environment);
                    break;
                case BrowserType.Chrome:
                    WebDriver = (new ChromeDriver(@"\\pvfs01\Fileserver\data\TestAutomationFiles\Drivers\"));
                    WebDriver.Navigate().GoToUrl(protocol + environment);
                    break;
                case BrowserType.NodeWebkit:
                    string FileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Panviva\\SupportPoint\\Viewer\\configSPViewer.json";
                    //SPConfigFileCreator.UpdateSPConfigFile(Properties.Settings.Default.Environment, FileLocation);
                    SPConfigFileCreator.UpdateSPConfigFile(environment, FileLocation);
                    WebDriver = (new ChromeDriver(@"C:\Program Files (x86)\Panviva\SupportPoint Viewer\"));
                    break;
                case BrowserType.GridChrome:
                    capability = DesiredCapabilities.Chrome();
                    //WebDriver = new RemoteWebDriver(new Uri("http://10.5.250.44:4444/wd/hub"), capability);
                    WebDriver = new RemoteWebDriver(new Uri("http://pvjenkins01:4444/wd/hub"), capability); 
                    WebDriver.Navigate().GoToUrl(protocol + environment);
                    break;
                case BrowserType.GridIE:
                    capability = DesiredCapabilities.InternetExplorer();
                    //WebDriver = new RemoteWebDriver(new Uri("http://10.5.250.44:4444/wd/hub"), capability);
                    WebDriver = new RemoteWebDriver(new Uri("http://pvjenkins01:4444/wd/hub"), capability);
                    WebDriver.Navigate().GoToUrl(protocol + environment);
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            
            //Log on to site as user.
            InitialPage initialPage = new InitialPage(WebDriver);
            //string BaseWindow = WebDriver.CurrentWindowHandle;
            if (browser.ToString() == "NodeWebkit")
            {
                UICommon.SwitchToNewBrowserWithTitle(WebDriver, "Login");
            }

        }

        /**
         *  Exit and Cleanup
         */
        public static void ExitSuportPoint()
        {
            if (WebDriver != null)
            {
                try
                {
                    //string BaseWindow = WebDriver.CurrentWindowHandle;
                    //LogIn.CloseSPManager();
                    UICommon.SwitchToNewBrowserWithURL(WebDriver, "/Viewer/");
                    LogIn.LogOutAndCloseApp();
                    WebDriver.Quit();
                }
                catch (Exception) { }
            }
            WebDriver = null;
            switch (browser)//Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:

                    KillProcess("iexplorer.exe");
                    KillProcess("IEDriverServer.exe");
                    break;
                case BrowserType.Chrome:
                    KillProcess("chrome.exe");
                    KillProcess("chromedriver.exe");
                    break;
                case BrowserType.NodeWebkit:
                    KillProcess("Viewer.exe");
                    KillProcess("chromedriver.exe");
                    KillProcess("nw.exe");
                    break;
                case BrowserType.GridChrome:
                    KillProcess("chromedriver.exe");
                    break;
                case BrowserType.GridIE:
                    KillProcess("iexplorer.exe");
                    KillProcess("IEDriverServer.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        static public bool IsSupportPointOpen()
        {
            return WebDriver != null;
        }

        static public void SwitchToPage(string PageTitle)
        { 
            UICommon.SwitchToNewPageWithTitle(WebDriver,PageTitle);
        }

        static public void SwitchToBrowser(string PageTitle)
        {
            UICommon.SwitchToNewBrowserWithTitle(WebDriver, PageTitle);
        }

        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
            {
                try
                {
                    process.Kill();
                }
                catch
                { }

            }
        }

        public static void IsCurrentBrowser(string BrowserTitle)
        {
           if (!WebDriver.Url.Contains("/Viewer/"))
                {
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(waitsec));
                wait.Until((d) => { return WebDriver.FindElement(By.XPath("//body[@aria-busy='false']")); });
                //wait.Until((d) => { return WebDriver.FindElement(By.XPath("//html[@openrequests='0']")); });
            }
            string browserTitle = WebDriver.Title.ToString();
            StringAssert.Contains(browserTitle, BrowserTitle, "Current Browser is not: " + BrowserTitle + ". It is: " + browserTitle);
        }

        //public static string GetCurrentBrowserHandle()
        //{

        //    WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(waitsec));
        //    wait.Until((d) => { return WebDriver.FindElement(By.XPath("//body[@aria-busy='false']")); });
        //    return WebDriver.CurrentWindowHandle;
        //}

        public static void waitForPageLoading()
        {
            Thread.Sleep(500);
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(waitsec));
            wait.Until((d) => { return WebDriver.FindElement(By.XPath("//body[@aria-busy='false']")); });
            //wait.Until((d) => { return WebDriver.FindElement(By.XPath("//html[@openrequests='0']")); });
            Thread.Sleep(500);

        }

        public static void waitForAjaxLoading()
        {
            try
            {
                Thread.Sleep(500);
                WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(5));
                wait.Until((d) => { return WebDriver.FindElement(By.XPath("//div[@id='AjaxLoading' and @style='display: none;']")); });
                Thread.Sleep(500);
            }
            catch { }

        }

        


    }
}
