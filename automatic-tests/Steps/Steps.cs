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
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetLoggedInUserName());
            return (mainPage.GetLoggedInUserName().Trim().ToLower().Equals(username));
        }
        public void LogOffKinogo()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.LogOff();
        }
        public bool IsLoggedOff()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);

            return mainPage.isEnterButtonExists();
        }
        public void AddFavourite()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddFavouriteClick();
         
        }
        public void AddFavouriteWithoutAuthorization()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddFavouriteWithoutAuthorizationClick();
            System.Threading.Thread.Sleep(1000);

        }
        public int IsAddedToFavourites()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            
            return filmPage.isFavourite();
        }
        public bool IsSearchedFilm(string filmName)
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);

            return searchPage.GetFindFilm(filmName).Trim().ToLower().Equals(filmName.Trim().ToLower());
        }
        public void SearchFilm(string filmName)
        {
            Pages.SearchPage searchPage = new Pages.SearchPage(driver);
            searchPage.OpenPage();
            searchPage.Search(filmName);
        }
        public void DeleteFavorite()
        {
            Pages.FavouritesPage favouritePage = new Pages.FavouritesPage(driver);
            favouritePage.OpenPage();
            favouritePage.DeleteFromFavourites();
        }
        public int IsDeletedFavourite()
        {
            Pages.FavouritesPage favouritePage = new Pages.FavouritesPage(driver);
            return favouritePage.isDeletedFromFavourite();
        }
        public bool IsLoggedError()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            Console.WriteLine(mainPage.GetAuthorizationError());
            return (mainPage.GetAuthorizationError().Equals("Ошибка авторизации"));
        }
        public void GoThroughPanel(string filmType)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
            mainPage.GoThroughPanel(filmType);
        }
        public bool IsHistoryPage(string filmType)
        {
            IWebElement pageHeader = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div/div[1]/h1"));
            Console.WriteLine(pageHeader.Text);
            return pageHeader.Text.Equals("Раздел с фильмами " + '\u0022' + filmType + '\u0022');
        }
        public void RateFilm()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.Rate();
        }
        public bool IsRated()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isRated();
        }
        public void CommentFilm()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddCommentButtonClick();
        }
        public void CommentFilm(string text)
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            filmPage.OpenPage();
            filmPage.AddCommentButtonClick();
            filmPage.WriteComment(text);
            filmPage.ButtonAddClick();
        }
        public bool IsCommentError()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isCommentError();
        }
        public bool IsCommentAdded()
        {
            Pages.FilmPage filmPage = new Pages.FilmPage(driver);
            return filmPage.isCommentAdded();
        }
        public void ChangeAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.LoadPicture();
            profilePage.SubmitClick();
            
        }
        public bool IsDefaultAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            return profilePage.isDefaultImg();
        }
        public void DeleteAvatar()
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.SetCheckboxDeletePhoto();
            profilePage.SubmitClick();
        }
        public void OrderFilm(string filmName,string originalName)
        {
            Pages.OrderPage orderPage = new Pages.OrderPage(driver);
            orderPage.OpenPage();
            orderPage.AddOrderButtonClick();
            orderPage.EnterInfo(filmName,originalName);
            orderPage.AddClick();
        }

        public bool IsOrderAdded(string filmName)
        {
            Pages.OrderPage orderPage = new Pages.OrderPage(driver);
            return orderPage.isOrderAdded(filmName);
        }
        public bool IsRegistryPage()
        {
            return driver.Title.Equals("Регистрация посетителя");
        }
        public void ChangePassword(string oldPassword,string newPassword)
        {
            Pages.ProfilePage profilePage = new Pages.ProfilePage(driver);
            profilePage.OpenPage();
            profilePage.EditProfileClick();
            profilePage.EnterNewPasswordInfo(oldPassword, newPassword);
            profilePage.SubmitClick();

        }
    }
}
