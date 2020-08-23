using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Response
{
    public class ServiceResponse
    {
        public bool IsSuccessFull { get; set; }

        public string ErrorMessage { get; set; }

        public Exception Exception { get; set; }

        public Object Result { get; set; }
    }
}
