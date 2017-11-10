using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestFramework;

namespace DeliveronmoreUITestsRefactor
{
    [TestClass]
    public class UserTests
    {
        private TestContext _testContextInstance;
        private string _url = "http://delivermore.azurewebsites.net/";
        private string _browser = "chrome";

        [TestInitialize]
        public void TestInitialize()
        {
            if (TestContext.Properties.Contains("environment"))
            {
                string environment = TestContext.Properties["environment"].ToString();
                _url = environment == "Test" ? "http://delivermorermtest.azurewebsites.net/" : "http://delivermorermprod.azurewebsites.net/";
            }

            if (TestContext.Properties.Contains("browser"))
            {
                _browser = TestContext.Properties["browser"].ToString();
            }

            Pages.BaseUrl = _url;
            Browser.BrowserName = _browser;
        }

        [TestMethod]
        public void Can_go_to_login_page()
        {
            Pages.LoginPage.Goto();
            Assert.IsTrue(Pages.LoginPage.IsAt());
        }

        [TestMethod]
        public void Login_Fail_With_Blank_Email()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.Login("", "invalidP@ssw0rd");
            Assert.IsTrue(Pages.LoginPage.EmailValidationErrorMessage == "'Email' has already been used.");
        }

        [TestMethod]
        public void Can_Set_Goals()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.Login("abc@abc.com", "P@ssw0rd");

            var mp = Pages.MainPage;

            mp.IsAt();

            mp.LoseWeight = true;
            mp.BeMoreActive = true;
            mp.GetStronger = false;
            mp.GetFaster = true;

            Assert.IsTrue(mp.LoseWeight);
            Assert.IsTrue(mp.BeMoreActive);
            Assert.IsFalse(mp.GetStronger);
            Assert.IsTrue(mp.GetFaster);

            // clear all checkboxes
            mp.LoseWeight = false;
            mp.BeMoreActive = false;
            mp.GetStronger = false;
            mp.GetFaster = false;
        }

        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        [TestMethod]
        public void Can_login_and_log_off()
        {
            Pages.LoginPage.Goto();
            Pages.LoginPage.IsAt();
            Pages.LoginPage.Login("abc@abc.com", "P@ssw0rd");
            Pages.MainPage.IsAt(); 
        }

        [TestCleanup]
        public void CleanUp()
        {
            Browser.Close();
        }
    }
}
