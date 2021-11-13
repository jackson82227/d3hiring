using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace d3hiring.MVC.Models
{
    //[Serializable]
    public class LessonModel
    {
        public String teacher { get; set; }
        public String[] students { get; set; }

        public LessonModel()
        {

        }
    }
}