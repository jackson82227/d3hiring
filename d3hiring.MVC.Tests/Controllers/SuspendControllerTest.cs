using d3hiring.MVC;
using d3hiring.MVC.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace d3hiring.MVC.Tests.Controllers
{
    [TestClass]
    public class SuspendControllerTest
    {

        [TestMethod]
        public void Post()
        {
            //Arrange
            SuspendController controller = new SuspendController();
            controller.SetHttpRequestMessage();

            //Possitive Case
            var suspendModel = new d3hiring.MVC.Models.SuspendModel();
            suspendModel.student = "studenthon@gmail.com";
            HttpResponseMessage httpResponseMessage = controller.Post(suspendModel);
            Assert.AreEqual(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);

            //Negative Case
            suspendModel.student = "Notfound_studenthon@gmail.com";
            httpResponseMessage = controller.Post(suspendModel);
            Assert.AreEqual(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);

        }
    }
}
