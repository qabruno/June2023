using June2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        // open chrome browser
        IWebDriver driver = new ChromeDriver();
        Thread.Sleep(1000);

        // Login page object initialization and definition
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginSteps(driver);

        // Home page object intialization and definition
        HomePage homePageObj = new HomePage();
        homePageObj.GoToTMPage(driver);

        // TM page object initialization and definition
        TM_Page tmPageObj = new TM_Page();
        tmPageObj.CreateTimeRecord(driver);

        // Edit Time record
        tmPageObj.EditTimeRecord(driver);

        // Delete Time record
        tmPageObj.DeleteTimeRecord(driver);
       




       




    }
}