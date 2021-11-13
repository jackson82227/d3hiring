using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d3hiring.MVC.Models
{
    public class RetrieveForNotificationsResult
    {       
        public HashSet<String> recipients { get; set; }

        public RetrieveForNotificationsResult()
        {
            recipients = new HashSet<string>();
        }
    }
}