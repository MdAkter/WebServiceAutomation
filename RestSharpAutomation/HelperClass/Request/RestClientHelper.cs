﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpAutomation.HelperClass.Request
{
    class RestClientHelper
    {
        private IRestClient GetRestClient()
        {
            IRestClient restClient = new RestClient();
            return restClient;
        }
        private IRestRequest GetRestRequest(string url, Dictionary<string, string> headers,Method method )
        {
            IRestRequest restRequest = new RestRequest()
            {
                Method = method,
                    Resource = url
            };
            foreach (string key in headers.Keys)
            {
                restRequest.AddHeader(key, headers[key]);
            }
            return restRequest;
        }
        private IRestResponse SendRequest(IRestRequest restRequest)
        {
            IRestClient restClient = GetRestClient();
            IRestResponse restResponse = restClient.Execute(restRequest);

            return restResponse;
        
        }
        private IRestResponse<T> SendRequest<T>(IRestRequest restRequest) where T : new()
        {
            IRestClient restClient = GetRestClient();
            IRestResponse<T> restResponse = restClient.Execute<T>(restRequest);
            return restResponse;

        }
            public IRestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
            {
                IRestRequest restRequest = GetRestRequest(url, headers, Method.GET);
            IRestResponse restResponse = SendRequest(restRequest);
            return restResponse;
            }

        public IRestResponse<T> PerformGetRequest<T>(string url, Dictionary<string, string> headers) where T : new()
        {
            IRestRequest restRequest = GetRestRequest(url, headers, Method.GET);
            IRestResponse<T> restResponse = SendRequest<T>(restRequest);
            return restResponse;
        }




    }

}
