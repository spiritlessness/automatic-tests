using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    public class SearchPage : AbstractPage
    {
        private const string BASE_URL = "http://kinogo.club/index.php?do=search";


        [FindsBy(How = How.Id, Using = "searchinput")]
        private IWebElement inputSearch;

        [FindsBy(How = How.Id, Using = "dosearch")]
        private IWebElement buttonStartSearch;

        IWebElement linkFilm;

        public SearchPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);          
        }

        public void Search(string text)
        {
            inputSearch.SendKeys(text);
            buttonStartSearch.Click();
        }

        public string GetFindFilm(string film_name)
        {
            linkFilm = driver.FindElement(By.LinkText(film_name));
            Console.WriteLine(linkFilm.Text);
            return linkFilm.Text;
        }
    }
}
