using System;
using OpenQA.Selenium;

namespace automatic_tests.Steps
{
    class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void LoginKinogo(string username, string password)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.Login(username, password);
        }

        public bool IsLoggedIn(string username)
        {
            Pages.MainPage loginPage = new Pages.MainPage(driver);
            return (loginPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }
    }
}
