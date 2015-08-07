﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SP_Automation.Commons;
using SP_Automation.Environments;
using SP_Automation.PageModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SP_Automation.Modules;

namespace SP_Automation.Tests
{
    static public class SupportPoint 
    {
        static public IWebDriver WebDriver {get; set;}

        /*
         * 
         * Modules
         */

        static public LogIn LogIn { get { return new LogIn(WebDriver); } set { LogIn = value; } }
        static public Nav Nav { get {return  new Nav(WebDriver);} set {Nav = value;} }
        static public Folder Folder { get { return new Folder(WebDriver); } set {Folder = value;} }
        static public Notification Notification { get { return new Notification(WebDriver); } set { Notification = value; } }
       
    
        /**
         * Open Support Point app: if there is existing one, it will kill it
         */
        static public void OpenSupportPoint()
        {
            
            Exit(); //just in case previous test not cleanup properly

            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true
            };

            switch (Properties.Settings.Default.Browser)
            {
                case BrowserType.IE:
                    //driver = new InternetExplorerDriver(options);
                    WebDriver = (new InternetExplorerDriver(options));
                    break;
                case BrowserType.Chrome:
                    WebDriver = (new ChromeDriver());

                    break;
                case BrowserType.NodeWebkit:
                    WebDriver = (new ChromeDriver(@"C:\Program Files (x86)\Panviva\SupportPoint Viewer\"));
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");
            }

            //Log on to site as user.
            InitialPage initialPage = new InitialPage(WebDriver);
            string BaseWindow = WebDriver.CurrentWindowHandle;
            UICommon.SwitchToNewBrowserWithTitle(WebDriver, BaseWindow, "Login");

        }

        /**
         *  Exit and Cleanup
         */
        public static void Exit()
        {
            if (WebDriver != null)
            {
                try
                {
                    LogIn.LogOutAndCloseApp();
                    WebDriver.Quit();
                }
                catch (Exception) { }
            }
            WebDriver = null;
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
                    KillProcess("nw.exe");
                    break;
                default:
                    throw new ArgumentException("Browser Type Invalid");

            }
        }

        static public bool IsSupportPointOpen()
        {
            return WebDriver != null;
        }

       
        public static void KillProcess(string processName)
        {
            foreach (var process in Process.GetProcessesByName(Path.GetFileNameWithoutExtension(processName)))
            {
                process.Kill();
            }
        }
    }
}