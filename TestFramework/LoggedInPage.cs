using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class LoggedInPage : PageBase
    {
        public LoggedInPage()
        {
            Url = Pages.BaseUrl + "";
            Title = "Home Page";
        }
    }

}