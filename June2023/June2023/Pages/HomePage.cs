


namespace June2023.Pages
{
    public class HomePage
    {
        // This comment should be pushed to the branch
        public void GoToTMPage(IWebDriver driver)
        {
            // Navigate to time and material page
            IWebElement administrationTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
            administrationTab.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 7);

            IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            tmOption.Click();
        }

        public void GoToEmployeesPage()
        {
            // Code that navigates to Employee page
        }
    }
}
