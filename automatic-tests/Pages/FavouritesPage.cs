using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
namespace automatic_tests.Pages
{
    class FavouritesPage : AbstractPage
    {
        private const string BASE_URL = "http://kinogo.club/favorites/";

        [FindsBy(How = How.Id, Using = "fav-id-1078")]
        private IWebElement buttonAddFavourite;

        
 
        public FavouritesPage(IWebDriver driver)
            : base(driver)
        {

            PageFactory.InitElements(this.driver, this);
        }
        public void DeleteFromFavourites()
        {
            buttonAddFavourite.Click();
        }
        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public int isDeletedFromFavourite()
        {
            System.Threading.Thread.Sleep(2000);
            IWebElement imgDeleteFavourite = driver.FindElement(By.XPath("//*[@id='fav-id-1078']/img"));
            return imgDeleteFavourite.GetAttribute("title").CompareTo("Добавить в свои закладки на сайте"); ;
      
        }
    }
}
