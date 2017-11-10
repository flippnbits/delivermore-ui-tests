using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestFramework
{
    public static class Browser
    {
        private static IWebDriver _webDriver;
        private static string _browserName = "";
        private static DesiredCapabilities capability;

   
        private static void createWebDriver (string browserName)
        {
            capability = new DesiredCapabilities();
            capability.SetCapability("browserName", browserName);
            if (browserName.ToLower() == "chrome")
            {
                _webDriver = new ChromeDriver(@"C:\WebDriver\Chrome");
            }
            else
            {
                _webDriver = new InternetExplorerDriver();
            }
        }

        public static void Close()
        {
            _webDriver.Close();
        }

        public static ISearchContext Driver
        {
            get { return _webDriver; }
        }

        public static IWebDriver WebDriver
        {
            get { return _webDriver; }
        }

        public static string BrowserName
        {
            get { return _browserName; }
            set
            {
                _browserName = value;
                createWebDriver(_browserName);
            }
        }

        internal static void MaximizeWindow()
        {
            WebDriver.Manage().Window.Maximize();
        }


        public static string Title
        {
            get { return _webDriver.Title; }
        }


        public static void Goto(string url)
        {
            _webDriver.Url = url;
        }

        internal static WebDriverWait Wait()
        {
            return new WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }
    }
}
