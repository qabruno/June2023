

namespace June2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class Employees_Tests : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeesPage employeePageObj = new EmployeesPage();

        [SetUp]
        public void EmployeeSetUp()
        {
            driver = new ChromeDriver();

            
            loginPageObj.LoginSteps(driver);

            
            homePageObj.GoToEmployeesPage();
        }

        [Test]
        public void CreateEmployeeTest()
        {
            
            employeePageObj.CreateEmployee();
        }

        [Test]
        public void EditEmployeeTest()
        {
            employeePageObj.EditEmployee();
        }

        [Test]
        public void DeleteEmployeeTest()
        {
            employeePageObj.DeleteEmployee();
        }

        [TearDown] 
        public void TearDown() 
        {
            driver.Quit();
        }

    }
}
