﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ProductManagementSystem
{
    public static class GlobalVariables
    {
        public static HttpClient webapiClient = new HttpClient();

        static GlobalVariables()
        {
            webapiClient.BaseAddress = new Uri("http://localhost:2200/api");
            webapiClient.DefaultRequestHeaders.Clear();
            webapiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}