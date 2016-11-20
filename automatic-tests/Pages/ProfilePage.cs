using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace automatic_tests.Pages
{
    class ProfilePage : AbstractPage
    {
        private const string BASE_URL = "http://kinogo.club/user/testuserbstu/";

        [FindsBy(How = How.XPath, Using = "//*[@id='userinfo']/div/a")]
        private IWebElement linkEditProfile;

        [FindsBy(How = How.XPath, Using = "//*[@id='userinfo']/div/img")]
        private IWebElement imgProfile;

        [FindsBy(How = How.Name, Using = "del_foto")]
        private IWebElement checkboxDeletePhoto;
        
       public ProfilePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(this.driver, this);
        }

        public override void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
            
        }
        public void EditProfileClick()
        {
            linkEditProfile.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public void LoadPicture()
        {
            IWebElement inputChooseFile = driver.FindElement(By.Name("image"));
            inputChooseFile.SendKeys(System.IO.Path.GetFullPath(@"automatic-tests/img/images.jpg"));
            System.Threading.Thread.Sleep(2000);
            

        }
        public void SubmitClick()
        {
            IWebElement buttonSubmit = driver.FindElement(By.Name("submit"));
            buttonSubmit.Click();
            System.Threading.Thread.Sleep(2000);
        }
        public bool isDefaultImg()
        {
            Console.WriteLine(imgProfile.GetAttribute("Src"));
            return imgProfile.GetAttribute("src").Equals("http://kinogo.club/templates/kinogo/dleimages/noavatar.png");
        }
        public void SetCheckboxDeletePhoto()
        {
            checkboxDeletePhoto.Click();
        }
        public void EnterNewPasswordInfo(string oldPassword,string newPassword)
        {
            IWebElement inputOldPassword = driver.FindElement(By.Name("altpass"));
            inputOldPassword.SendKeys(oldPassword);
            IWebElement inputNewPassword = driver.FindElement(By.Name("password1"));
            inputNewPassword.SendKeys(newPassword);
            IWebElement inputRepeat = driver.FindElement(By.Name("password2"));
            inputRepeat.SendKeys(newPassword);
        }
    }
}
