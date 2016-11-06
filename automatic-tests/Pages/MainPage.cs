using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class MainPage
    {
        private const string BASE_URL = "http://www.kinogo.club/";

        [FindsBy(How = How.CssSelector, Using = "body > div.wrapper > div.header > div.header44 > div.user_panel > div.loginin > a:nth-child(2)")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Id, Using = "login_name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.CssSelector, Using = "#test > form:nth-child(1) > button:nth-child(5)")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//a[@id='logbtn']")]
        private IWebElement linkLoggedInUser;
        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }



        public void Login(string username, string password)
        {
            buttonEnter.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(1));
        }

        public string GetLoggedInUserName()
        {
            
            return linkLoggedInUser.Text;
        }
    }
}
