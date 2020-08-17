using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutCore.Domain
{
    public class CheckOutError
    {
            public string Field { get; set; }
            public string Code { get; set; }
            public string Message { get; set; }   
    }
}
