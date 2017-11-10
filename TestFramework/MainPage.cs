using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestFramework
{
    public class MainPage : LoggedInPage
    {
        public MainPage()
        {
            Url = Pages.BaseUrl + "";
            Title = "Home Page";
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[1]/td[1]/div/label")]
        private IWebElement LoseWeightlabel { get; set; }

        [FindsBy(How = How.Id, Using = "GoalChkBox+1")]
        private IWebElement LooseWeightCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[2]/td[1]/div/label")]
        private IWebElement BeMoreActiveLabel { get; set; }

        [FindsBy(How = How.Id, Using = "GoalChkBox+2")]
        private IWebElement BeMoreActiveCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[3]/td[1]/div/label")]
        private IWebElement GetStrongerLabel { get; set; }

        [FindsBy(How = How.Id, Using = "GoalChkBox+3")]
        private IWebElement GetStrongerCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='activies']/div/table/tbody/tr[4]/td[1]/div/label")]
        private IWebElement GetFasterLabel { get; set; }

        [FindsBy(How = How.Id, Using = "GoalChkBox+4")]
        private IWebElement GetFasterCheckbox { get; set; }


        public Boolean LoseWeight
        {
            get { return (LooseWeightCheckbox.Selected); }
            set
            {
                if (LooseWeightCheckbox.Selected != value)
                {
                    LoseWeightlabel.Click();
                }
            }
        }
        public Boolean BeMoreActive
        {
            get { return (BeMoreActiveCheckbox.Selected); }
            set
            {
                if (BeMoreActiveCheckbox.Selected != value)
                {
                    BeMoreActiveLabel.Click();
                }
            }
        }

        public Boolean GetStronger
        {
            get { return (GetStrongerCheckbox.Selected); }
            set
            {
                if (GetStrongerCheckbox.Selected != value)
                {
                    GetStrongerLabel.Click();
                }
            }
        }

        public Boolean GetFaster
        {
            get { return (GetFasterCheckbox.Selected); }
            set
            {
                if (GetFasterCheckbox.Selected != value)
                {
                    GetFasterLabel.Click();
                }
            }
        }
    }
}
