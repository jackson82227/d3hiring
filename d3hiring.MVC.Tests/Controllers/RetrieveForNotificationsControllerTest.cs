using d3hiring.MVC;
using d3hiring.MVC.Controllers;
using d3hiring.MVC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
    public class RetrieveForNotificationsControllerTest
    {

        [TestMethod]
        public void Post()
        {
            //Arrange
            RetrieveForNotificationsController controller = new RetrieveForNotificationsController();
            controller.SetHttpRequestMessage();

            //Possitive Case
            var retrieveForNotificationsModel = new d3hiring.MVC.Models.RetrieveForNotificationsModel();
            retrieveForNotificationsModel.teacher = "teacherjoe@gmail.com";
            retrieveForNotificationsModel.notification = "Hello students! ;drop table student; -- @studenthon82@gmail.com";

            HttpResponseMessage httpResponseMessage = controller.Post(retrieveForNotificationsModel);
            Assert.AreEqual(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);

            //compare with expected result
            RetrieveForNotificationsResult expectedResult = new RetrieveForNotificationsResult()
            {
                recipients = { "studenthon@gmail.com", "studentjon2@gmail.com", "studenthon2@gmail.com", "studenthon82@gmail.com" }
            };
            RetrieveForNotificationsResult result = JsonConvert.DeserializeObject<RetrieveForNotificationsResult>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(false, result.recipients.Except(expectedResult.recipients).Any());

        }
    }
}
