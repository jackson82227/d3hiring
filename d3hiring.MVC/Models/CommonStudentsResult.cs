using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d3hiring.MVC.Models
{
    public class CommonStudentsResult
    {
        public List<String> students { get; set; }

        public CommonStudentsResult()
        {
            students = new List<string>();
        }
    }
}