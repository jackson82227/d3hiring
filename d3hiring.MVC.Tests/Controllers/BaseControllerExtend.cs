using d3hiring.MVC;
using d3hiring.MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace d3hiring.MVC.Tests.Controllers
{
    public static class BaseControllerExtend
    {
        public static void SetHttpRequestMessage(this BaseController controller)
        {
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();
        }
    }
}
