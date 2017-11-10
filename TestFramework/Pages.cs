using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFramework
{

    public static class Pages
    {
        private static LoggedInPage _loggedInPage = null;
        private static LoginPage _loginPage = null;
        private static MainPage _mainPage = null;

        public static string BaseUrl { get; set; }

       public static LoginPage LoginPage
        {
            get
            {
                if (_loginPage == null) { _loginPage = new LoginPage(); }
                return _loginPage;
            }
        }

        public static MainPage MainPage
        {
            get
            {
                if (_mainPage == null) { _mainPage = new MainPage(); }
                return _mainPage;
            }
        }

        public static LoggedInPage LoggedInPage
        {
            get
            {
                if (_loggedInPage == null) { _loggedInPage = new LoggedInPage(); }
                return _loggedInPage;
            }
        }
    }

}
