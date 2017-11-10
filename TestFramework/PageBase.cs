
using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public abstract class PageBase
    {
        internal static string Title { get; set; }
        internal static string Url { get; set; }
        internal static IWebDriver WebDriver { get; set; }

        protected PageBase()
        {
            WebDriver = Browser.WebDriver;
            PageFactory.InitElements(WebDriver, this);
            Url = "";
            Title = "";
        }

        protected PageBase(string url, string title)
        {
            Url = url;
            Title = title;
        }

        internal void WaitForLoad()
        {
            var wait = Browser.Wait();

            try
            {
                wait.Until(p => p.Title == Title);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                TakeScreenshot();
                throw;
            }

        }

        public virtual bool IsAt()
        {
            return Browser.Title == Title;
        }

        public void Goto()
        {
            // Get root url from test context and append Url to it
           
            Browser.Goto(Url);
     
        }

        internal static void WaitFor(By elementDescription)

        {

            var wait = Browser.Wait();



            wait.Until(e => e.FindElement(elementDescription));

        }
        
        internal void TakeScreenshot()
        {
            string captureLocation = "c:\\temp\\testresults\\";
            string callingMethodName = new StackFrame(1, true).GetMethod().Name;
            string callingClassName = GetType().Name;
            string timeStamp = DateTime.Now.ToString("ddMMyyyyHHmmss");

            string filePath = captureLocation + callingMethodName + "ErrorCapture" + timeStamp + ".png";
            
            try

            {

                //TODO : Add more info to the filename and suitable location to save to 

                Screenshot ss = ((ITakesScreenshot)Browser.Driver).GetScreenshot();

                //ss.SaveAsFile(filePath, ImageFormat.Png);

            }

            catch (Exception e)

            {

                Console.WriteLine("TakeScreenshot encountered an error. " + e.Message);

                throw;

            }



            Console.WriteLine(callingClassName + "." + callingMethodName + " generated an error. A ScreenShot of the browser has been saved. " + filePath);

        }
    }
}
