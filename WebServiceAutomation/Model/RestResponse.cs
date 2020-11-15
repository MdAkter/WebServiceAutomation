﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceAutomation.Model
{
    public class RestResponse
    {
        private int statusCode;
        private string responseData;
      public RestResponse(int statusCode, string responseData)
        {
            this.statusCode = statusCode;
            this.responseData = responseData;
        }
        public int StatusCode
        {
            get
            {
                return statusCode;

            }
        }

        public string ResponseContent
        {
            get
            {
                return responseData;
            }
        }
        public override string ToString()
        {
            return String.Format("StatusCode : {0} responseData : {1}", statusCode, responseData);
        }
    }
}
