using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAutomation.RestGetEndPoint
{
    [TestClass]
    public class TestGetEndPoint
    {
        private string getUrl = "https://reqres.in/api/users?page=2";
        [TestMethod]
        public void TestGetAllUserUsingRestSharp()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            IRestResponse restResponse = restClient.Get(restRequest);
            //Console.WriteLine(restResponse.IsSuccessful);
            //Console.WriteLine(restResponse.StatusCode);

            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code is : "+restResponse.StatusCode);
                Console.WriteLine("Response Content :"+restResponse.Content);
            }
        }

        [TestMethod]
        public void TestGetInXMLFormat()
        {
            IRestClient restClient = new RestClient();
            IRestRequest restRequest = new RestRequest(getUrl);
            restRequest.AddHeader("accept", "application/xml");
            IRestResponse restResponse = restClient.Get(restRequest);
            if (restResponse.IsSuccessful)
            {
                Console.WriteLine("Status Code is : " + restResponse.StatusCode);
                Console.WriteLine("Response Content :" + restResponse.Content);
            }
        }
    }

}
