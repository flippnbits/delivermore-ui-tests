using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class LoginPage : PageBase
    {
        public LoginPage() 
        {
            Url = Pages.BaseUrl + "Account/Login";
            Title = "Log in";
        }

        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Username { get; set; }

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn-default")]
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "validation-summary-errors")]
        public IWebElement LoginErrorMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//*/form/div[1]/div/span/span")]
        private IWebElement EmailValidationErrorLabel { get; set; }

        [FindsBy(How = How.XPath, Using = "//*/form/div[2]/div/span/span")]
        private IWebElement PasswordValidationErrorLabel { get; set; }

        public string EmailValidationErrorMessage
        {
            get
            {
                return EmailValidationErrorLabel.Text;
            }
        }

        public string PasswordValidationErrorMessage
        {
            get
            {
                return PasswordValidationErrorLabel.Text;
            }
        }

        public void Login(string userName, string password)
        {
            WaitForLoad();

            Username.Clear();
            Username.SendKeys(userName);

            Password.Clear();
            Password.SendKeys(password);

            LoginButton.Click();

        }

    }

}
