﻿


namespace June2023.Pages
{
    public class TM_Page
    {
        public void CreateTimeRecord(IWebDriver driver, string code, string description)
        {
            // Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            // Select Time from dropdown list
            IWebElement dropdownList = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            dropdownList.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            timeOption.Click();

            // Enter code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys(code);

            // Enter description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys(description);

            // Enter price per unit
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("20");

            // Click on save button
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 3);
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(3500);

            // Check if new Time record has been created successfully
   
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            Assert.That(newCode.Text == code, "New time record has not been created. Test failed!");
        }

        public void EditTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(4000);
            //Select a record and click edit button
            IWebElement llastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            llastPageButton.Click();
            Thread.Sleep(2000);

            IWebElement recordToBeEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(recordToBeEdited.Text == "bruno")
            {
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited has not been found.");
            }
           
           
            try
            {
                //Edit the code details
                IWebElement ccodeTextbox = driver.FindElement(By.Id("Code"));
                ccodeTextbox.Clear();
                ccodeTextbox.SendKeys("sanal jacob");
            }
            catch (Exception ex)
            {
                Assert.Fail("Edit button isn't working", ex.Message);
            }


            //Click save
            IWebElement ssaveButton = driver.FindElement(By.Id("SaveButton"));
            ssaveButton.Click();
            Thread.Sleep(1500);

            //Check if the edit functionality is properly working or not

            IWebElement lllastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lllastPageButton.Click();
            Thread.Sleep(1500);

            IWebElement neweditedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            
            Assert.That(neweditedCode.Text == "sanal jacob", "Editing functionality working failed");
  
            Thread.Sleep(1500);
        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            

            Thread.Sleep(4000); Thread.Sleep(2000);
            IWebElement llastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            llastPageButton.Click();
            Thread.Sleep(5000);

            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if(recordToBeDeleted.Text == "sanal jacob")
            {
                //Click on delete button on a selected record
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();                                                             
            }
            else
            {
                Assert.Fail("Record to deleted has not been found.");
            }
            
            Thread.Sleep(1500);
            
            //Click OK to delete
            driver.SwitchTo().Alert().Accept();

            Thread.Sleep(4000);

            driver.Navigate().Refresh();

            Thread.Sleep(4000);
            //Check if the record is deleted
            IWebElement lPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lPageButton.Click();
            
            IWebElement deletedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           
            Assert.That(deletedCode.Text != "sanal jacob", "Record hasn't been deleted successfully. Test Failed");
  
        }
    }
}
