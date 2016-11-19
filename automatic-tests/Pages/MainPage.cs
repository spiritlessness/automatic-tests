using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class MainPage : AbstractPage
    {
        private const string BASE_URL = "http://www.kinogo.club/";

        

        [FindsBy(How = How.LinkText, Using = "Вход")]
        private IWebElement buttonEnter;

        [FindsBy(How = How.Id, Using = "login_name")]
        private IWebElement inputLogin;

        [FindsBy(How = How.Id, Using = "login_password")]
        private IWebElement inputPassword;

        [FindsBy(How = How.CssSelector, Using = "#test > form:nth-child(1) > button:nth-child(5)")]
        private IWebElement buttonSubmit;

        [FindsBy(How = How.XPath, Using = "//a[@id='logbtn']")]
        private IWebElement linkLoggedInUser;


        public MainPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }



        public void Login(string username, string password)
        {
            buttonEnter.Click();
            inputLogin.SendKeys(username);
            inputPassword.SendKeys(password);
            buttonSubmit.Click();            
            System.Threading.Thread.Sleep(1000);
        }
        public void LogOff()
        {
            IWebElement buttonExit = driver.FindElement(By.CssSelector("body > div.wrapper > div.header > div.header44 > div.user_panel > div.loginin > a.thide.lexit"));
            buttonExit.Click();
        }
        public string GetLoggedInUserName()
        {
            return linkLoggedInUser.Text;
        }
        public string GetAuthorizationError()
        {
            IWebElement textAuthorizationError = driver.FindElement(By.CssSelector(".oformlenie > h1:nth-child(1)"));
            return textAuthorizationError.Text;
        }
        public bool isEnterButtonExists()
        {
            return buttonEnter.Text.Equals("Вход");
        }
        public void GoThroughPanel(string filmType)
        {
            IWebElement linkPanel = driver.FindElement(By.LinkText(filmType));
            Console.WriteLine(linkPanel.Text);
            linkPanel.Click();
        }
    }
}
