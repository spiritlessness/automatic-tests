using NUnit.Framework;


namespace automatic_tests.Tests
{
    [TestFixture]
    class Tests
    {
            private Steps.Steps steps = new Steps.Steps();
            private const string USERNAME = "testuserbstu";
            private const string PASSWORD = "1234567890";
            private const string WRONG_PASSWORD = "1234";
            private const string TEXT_TO_SEARCH = "Крестный отец (1972)";
            private const string NAVIGATION_LINK = "Исторические";
            private const string TEXT_COMMENT = "Потрясающий фильм. Классика кинематографа, которая остается актуальной и в современном обществе. Погрузившись в этот мир, мир мафии, вы никогда уже не сможете его забыть.";
            private const string FILM_NAME = "Кабинет доктора Калигари";
            private const string ORIGIGNAL_NAME = "Das Cabinet des Dr. Caligari";
            private const string NEW_PASSWORD = "123456789";
            [SetUp]
            public void Init()
            {
                steps.InitBrowser();
            }

            [TearDown]

            public void Cleanup()
            {
                steps.CloseBrowser();
            }

            [Test]
            public void LoginKinogo()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                Assert.True(steps.IsLoggedIn(USERNAME));
            }
            [Test]
            public void LogOffKinogo()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.LogOffKinogo();
                Assert.True(steps.IsLoggedOff());
            }
            [Test]
            public void Search()
            {
                steps.SearchFilm(TEXT_TO_SEARCH);
                Assert.True(steps.IsSearchedFilm(TEXT_TO_SEARCH));
            }
            [Test]
            public void AddToFavourites()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.AddFavourite();
                Assert.AreEqual(0, steps.IsAddedToFavourites());
                steps.DeleteFavorite();
            }
            [Test]
            public void DeleteFromFavourites()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.AddFavourite();
                steps.DeleteFavorite();
                Assert.AreEqual(steps.IsDeletedFavourite(), 0);
            }
            [Test]
            public void WrongLoginKinogo()
            {
                steps.LoginKinogo(USERNAME, WRONG_PASSWORD);
                Assert.True(steps.IsLoggedError());
            }
            [Test]
            public void NavigationPanelTest()
            {
                steps.GoThroughPanel(NAVIGATION_LINK);
                Assert.True(steps.IsHistoryPage(NAVIGATION_LINK));
            }
            [Test]
            public void RateFilmTest()
            {
                steps.RateFilm();
                Assert.True(steps.IsRated());
            }
            [Test]
            public void AddCommentWithoutAuthorization()
            {
                steps.CommentFilm();
                Assert.True(steps.IsCommentError());
            }
            [Test]
            public void AddComment()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.CommentFilm(TEXT_COMMENT);
                Assert.True(steps.IsCommentAdded());
            }
            [Test]
            public void AddAvatar()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.ChangeAvatar();
                Assert.False(steps.IsDefaultAvatar());
                steps.DeleteAvatar();
            }
            [Test]
            public void DeleteAvatar()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.ChangeAvatar();
                steps.DeleteAvatar();
                Assert.True(steps.IsDefaultAvatar());
            }
            [Test]
            public void OrderFilm()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.OrderFilm(FILM_NAME, ORIGIGNAL_NAME);
                Assert.True(steps.IsOrderAdded(FILM_NAME));
            }
            [Test]
            public void AddFavouritesWithoutAuthorization()
            {
                steps.AddFavouriteWithoutAuthorization();
                Assert.True(steps.IsRegistryPage());
            }
            [Test]
            public void ChangePassword()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                steps.ChangePassword(PASSWORD, NEW_PASSWORD);
                steps.LogOffKinogo();
                steps.LoginKinogo(USERNAME, NEW_PASSWORD);
                Assert.True(steps.IsLoggedIn(USERNAME));
                steps.ChangePassword(NEW_PASSWORD, PASSWORD);
            }
        }
    }