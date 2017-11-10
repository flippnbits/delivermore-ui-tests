using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class NewPage : PageBase
    {
        public NewPage()
        {
            Url = Pages.BaseUrl + "sub/page/address";
            Title = "New Page Title";
        }
    }

}
