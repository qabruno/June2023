

namespace June2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TM_Page tmPageObj = new TM_Page();

        [SetUp]
        public void TM_SetUp()
        {
            // open chrome browser
            driver = new ChromeDriver();
            Thread.Sleep(1000);

            // Login page object initialization and definition
            
            loginPageObj.LoginSteps(driver);

            // Home page object intialization and definition
            
            homePageObj.GoToTMPage(driver);
        }

        [Test, Order(1), Description("This test checks if a user is able to create a new time record")]
        public void CreateTime_Test()
        {
            // TM page object initialization and definition
            
            tmPageObj.CreateTimeRecord(driver, "bruno", "June2023");
        }

        [Test, Order(2), Description("This test checks if a user is able to edit an existing time record")]
        public void EditTime_Test()
        {
            tmPageObj.EditTimeRecord(driver);
        }

        [Test, Order(3), Description("This test checks if a user is able to delete an existing time record")]
        public void DeleteTime_Test()
        {
            tmPageObj.DeleteTimeRecord(driver);
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }












    }
}
