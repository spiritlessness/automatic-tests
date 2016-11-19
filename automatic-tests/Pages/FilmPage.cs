using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class FilmPage : AbstractPage
    {
        private const string BASE_URL = "http://kinogo.club/1078-krestnyy-otec-1972.html";
        private const string FILM_NAME = "Крестный отец";
        
        [FindsBy(How = How.Id, Using = "fav-id-1078")]
        private IWebElement buttonAddFavourite;

        [FindsBy(How = How.ClassName, Using = "r5-unit")]
        private IWebElement buttonRate5;

        [FindsBy(How = How.ClassName, Using = "fbutton5")]
        private IWebElement buttonAddComment;

        [FindsBy(How = How.Id, Using = "comments")]
        private IWebElement inputComment;

        [FindsBy(How = How.CssSelector, Using = "#addcform > div > button")]
        private IWebElement buttonAdd;

       
        [FindsBy(How = How.XPath, Using = "//*[@id='dle-content']/div[1]/div[1]/div/span[2]/a")]
        private IWebElement imgAddFavouriteWithoutAuthorization;

        public FilmPage(IWebDriver driver)
            : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public void AddFavouriteClick()
        {
            System.Threading.Thread.Sleep(2000);
            buttonAddFavourite.Click();
        }
        public void AddFavouriteWithoutAuthorizationClick()
        {
            imgAddFavouriteWithoutAuthorization.Click();
        }
        public int isFavourite()
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement imgAddFavourite = driver.FindElement(By.XPath("//*[@id='fav-id-1078']/img"));
            return imgAddFavourite.GetAttribute("title").CompareTo("Удалить из закладок"); ;
        }
        public void Rate()
        {
            buttonRate5.Click();
        }
        public bool isRated()
        {
            System.Threading.Thread.Sleep(1500);
            IWebElement imgCurrentRating= driver.FindElement(By.ClassName("current-rating"));
            return imgCurrentRating.Displayed;
        }
        public void AddCommentButtonClick()
        {
            buttonAddComment.Click();
            System.Threading.Thread.Sleep(1500);
        }
        public bool isCommentError()
        {
           IWebElement errorMessage = driver.FindElement(By.XPath("//*[@id='addcform']/div/b"));
           return errorMessage.Text.Equals("Гости");
        }
        public void WriteComment(string text)
        {
            inputComment.SendKeys(text);
        }
        public void ButtonAddClick()
        {
            buttonAdd.Click();
            System.Threading.Thread.Sleep(1500);
        }
        public bool isCommentAdded()
        {
            IWebElement dd = driver.FindElement(By.ClassName("ui-dialog-title"));
            return dd.Text.Equals("Добавление комментария");
        }
    }
}
