﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CheckOutCore.Domain
{
    public class CheckOutHttpClientResponse
    {
        public bool IsSuccessFull { get; set; }
        public string Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<CheckOutError> Error { get; set; }
        public Exception Exception { get; set; }
    }
}

