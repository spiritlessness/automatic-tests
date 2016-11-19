using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
     
    class OrderPage : AbstractPage
    {
        private const string BASE_URL = "http://kinogo.club/index.php?do=orderdesc";


        [FindsBy(How = How.Id, Using = "orderdesc-add")]
        private IWebElement buttonAddOrder;

        
        public OrderPage(IWebDriver driver): base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }
        public override void OpenPage()
        {
            System.Threading.Thread.Sleep(2000);
            driver.Navigate().GoToUrl(BASE_URL);
            
        }

        public void AddOrderButtonClick()
        {
            buttonAddOrder.Click();
        }
        public void EnterInfo(string filmName,string originalName)
        {
            IWebElement inputFilmName = driver.FindElement(By.Id("orderdesc_title"));
            inputFilmName.SendKeys(filmName);
            IWebElement inputOriginalName = driver.FindElement(By.Name("orig_title"));
            inputOriginalName.SendKeys(originalName);
           
        }
        public void AddClick()
        {
            IWebElement buttonAdd = driver.FindElement(By.Id("orderdesc-add-submit"));
            buttonAdd.Click();
        }
        public bool isOrderAdded(string filmName)
        {
            IWebElement lastAddedFilm = driver.FindElement(By.XPath("//*[@id='orderdesc-table']/tbody/tr[1]/td[2]/h2"));
            return lastAddedFilm.Text.Equals(filmName);
        }

    }
}
