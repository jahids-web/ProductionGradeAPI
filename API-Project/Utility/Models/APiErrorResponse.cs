using System;
using System.Collections.Generic;
using System.Text;

namespace Utility.Models
{
    public class APiErrorResponse
    {
        public string Message { get; set; } 
        public string Details { get; set; }
        public bool IsSuccess { get; set; }
    }
}
