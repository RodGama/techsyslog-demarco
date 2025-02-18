using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Results
{
    public class LoginResult
    {
        public string Token { get; set; }
        public bool IsValid { get; set; }
        public IList<string> Errors { get; set; }
    }
}