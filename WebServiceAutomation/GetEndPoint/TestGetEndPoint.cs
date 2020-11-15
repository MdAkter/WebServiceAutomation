using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebServiceAutomation.Model;
using WebServiceAutomation.Model.JsonModel;

namespace WebServiceAutomation.GetEndPoint
{
    [TestClass]
    public class TestGetEndPoint

    { 
        private String getUrl = "https://reqres.in/api/users?page=2";
    
        [TestMethod]
        public void TestGetAllUsers()
        {
            HttpClient httpclient = new HttpClient();
            Task<HttpResponseMessage> HttpResponse=httpclient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            httpclient.Dispose();

        }

        [TestMethod]
        public void TestGetAllUsersWithURI()
        {
            HttpClient httpclient = new HttpClient();
            Uri getUri = new Uri(getUrl + "/.000001");
            Task<HttpResponseMessage> HttpResponse=httpclient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage=HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status code is : " +statusCode);
            Console.WriteLine("Status code is : " + (int)statusCode);

            httpclient.Dispose();

        }

        [TestMethod]
        public void TestGetAllUsersWithInvalidURI()
        {
            HttpClient httpclient = new HttpClient();            
            Uri getUri = new Uri(getUrl);
            Task<HttpResponseMessage> HttpResponse = httpclient.GetAsync(getUri);
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            //status code
            Console.WriteLine("Status code is : " + statusCode);
            Console.WriteLine("Status code is : " + (int)statusCode);
            httpclient.Dispose();
        }
        [TestMethod]
        public void TestGetAllUsersInJSONFormat()
        {
            HttpClient httpclient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpclient.DefaultRequestHeaders;
            requestHeaders.Add("accept", "application/json");
            Task<HttpResponseMessage> HttpResponse = httpclient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            //status code
            Console.WriteLine("Status code is : " + statusCode);
            Console.WriteLine("Status code is : " + (int)statusCode);
            HttpContent httpContent = httpResponseMessage.Content;
              Task<string> responseData =httpContent.ReadAsStringAsync();
           String data = responseData.Result;
            Console.WriteLine(data);
            httpclient.Dispose();
        }
        [TestMethod]
        public void TestGetAllUsersInXmlFormat()
        {
            HttpClient httpclient = new HttpClient();
            HttpRequestHeaders requestHeaders = httpclient.DefaultRequestHeaders;
            requestHeaders.Add("accept", "application/xml");
            Task<HttpResponseMessage> HttpResponse = httpclient.GetAsync(getUrl);
            HttpResponseMessage httpResponseMessage = HttpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            //status code
            Console.WriteLine("Status code is : " + statusCode);
            Console.WriteLine("Status code is : " + (int)statusCode);
            HttpContent httpContent = httpResponseMessage.Content;
            Task<string> responseData = httpContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpclient.Dispose();          
        }

        [TestMethod]
        public void TestGetUsersUsingSendAsync()
        {


            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.RequestUri = new Uri(getUrl);
            httpRequestMessage.Method = HttpMethod.Get;
            httpRequestMessage.Headers.Add("accept", "application/json");
            HttpClient httpClient = new HttpClient();
            Task<HttpResponseMessage> httpResponse= httpClient.SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());
            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            //status code
            Console.WriteLine("Status code is : " + statusCode);
            Console.WriteLine("Status code is : " + (int)statusCode);
            HttpContent httpContent = httpResponseMessage.Content;
            Task<string> responseData = httpContent.ReadAsStringAsync();
            String data = responseData.Result;
            Console.WriteLine(data);
            httpClient.Dispose();
        }

        [TestMethod]
        public void TestUsingstatement()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                using(HttpRequestMessage httpRequestMessage = new HttpRequestMessage())
                
                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {

                        Console.WriteLine(httpResponseMessage.ToString());
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //status code
                        Console.WriteLine("Status code is : " + statusCode);
                        Console.WriteLine("Status code is : " + (int)statusCode);
                        HttpContent httpContent = httpResponseMessage.Content;
                        Task<string> responseData = httpContent.ReadAsStringAsync();
                        String data = responseData.Result;
                        Console.WriteLine(data);
                        Console.WriteLine("###############################################");
                        Console.WriteLine("###############################################");
                        Console.WriteLine("###############################################");
                        RestResponse restResponse = new RestResponse((int)statusCode, data);
                        Console.WriteLine(restResponse.ToString());

                    }

                }

            }

        }

        [TestMethod]
        public void DeserializationOfJsonResponse()
        {

            using (HttpClient httpClient = new HttpClient())
            {
                using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage())

                {
                    httpRequestMessage.RequestUri = new Uri(getUrl);
                    httpRequestMessage.Method = HttpMethod.Get;
                    httpRequestMessage.Headers.Add("accept", "application/json");

                    Task<HttpResponseMessage> httpResponse = httpClient.SendAsync(httpRequestMessage);

                    using (HttpResponseMessage httpResponseMessage = httpResponse.Result)
                    {

                        Console.WriteLine(httpResponseMessage.ToString());
                        HttpStatusCode statusCode = httpResponseMessage.StatusCode;
                        //status code
                        Console.WriteLine("Status code is : " + statusCode);
                        Console.WriteLine("Status code is : " + (int)statusCode);
                        HttpContent httpContent = httpResponseMessage.Content;
                        Task<string> responseData = httpContent.ReadAsStringAsync();
                        String data = responseData.Result;
                        Console.WriteLine(data);
                        Console.WriteLine("###############################################");
                        Console.WriteLine("###############################################");
                        Console.WriteLine("###############################################");
                        RestResponse restResponse = new RestResponse((int)statusCode, data);
                        // Console.WriteLine(restResponse.ToString());

                       List<JsonRootObject> jsonRootObject = JsonConvert.DeserializeObject<List<JsonRootObject>>(restResponse.ResponseContent);
                        Console.WriteLine(jsonRootObject[0].ToString());
                    }

                }

            }
        }
    }

}
