using NUnit.Framework;


namespace automatic_tests.Tests
{
    [TestFixture]
    class Tests
    {
            private Steps.Steps steps = new Steps.Steps();
            private const string USERNAME = "testuserbstu";
            private const string PASSWORD = "1234567890";

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
            public void OneCanLoginKinogo()
            {
                steps.LoginKinogo(USERNAME, PASSWORD);
                
                Assert.True(steps.IsLoggedIn(USERNAME));
            }
        }
    }