using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using APIDemo;
using AventStack.ExtentReports;

namespace APITests
{
    [TestClass]
    public class RegressionTests
    {
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            var dir = testContext.TestResultsDirectory;
            Reporter.SetupExtentReport("API Regression Test", "API Regression Test Report", dir);
        }

        [TestInitialize]
        public void SetupTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        public void CleanupTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status logStatus;
            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    logStatus = Status.Fail;
                    Reporter.TestStatus(logStatus.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
                default:
                    break;

            }
        }
      
        [ClassCleanup]
        public static void Cleanup()
        {
            Reporter.FlushReport();
        }
        
        [TestMethod]
        public void VerifyListOfUsers()
        {
            var demo = new Demo<ListOfUsersDTO>();
            var response = demo.GetUsers("api/users?page=2");
            Assert.AreEqual(2, response.Page);
            Reporter.LogToReport(Status.Fail, "Page number does not match");
            Assert.AreEqual("Michael", response.Data[0].first_name);
            Reporter.LogToReport(Status.Fail, "User first name does not match");

        }


        [DeploymentItem("TestData\\TestCase.csv"),
        DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestCase.csv","TestCase#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void CreateNewUser()
        {
            //String payload = @"{ 
            //                    ""name"": ""Mike"",
            //                    ""job"": ""Team leader""
            //                   }";
            //var user = new APIHelper<CreateUserDTO>();
            //var url = user.SetUrl("api/users");
            //var request = user.CreatePostRequest(payload);
            //var reponse = user.GetResponse(url, request);
            //CreateUserDTO content = user.GetContent<CreateUserDTO>(reponse);

            var users = new CreateUserRequestDTO();
            users.Name = TestContext.DataRow["name"].ToString();
            users.Job = TestContext.DataRow["job"].ToString();
            var demo = new Demo<CreateUserDTO>();
            var user = demo.CreateUser("api/users", users);

            //###################################
            Assert.AreEqual("Mike", user.Name);
            Assert.AreEqual("Lead", user.Job);
        }
    }
}
