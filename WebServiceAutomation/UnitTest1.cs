﻿using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WebServiceAutomation
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Step1 : Create http client object
            HttpClient httpClient = new HttpClient();

            httpClient.Dispose(); // close the connection and release the resource

        }
    }
}
