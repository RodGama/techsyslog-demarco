using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.TechsysLog.Results
{
    public class ResultTemplate
    {
        public string Endpoint { get; set; }
        public bool Success { get; set; }
        public IList<string> Errors { get; set; }
    }
}