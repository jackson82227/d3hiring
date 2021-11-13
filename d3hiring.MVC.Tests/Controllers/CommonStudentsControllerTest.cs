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
    public class CommonStudentsControllerTest
    {

        [TestMethod]
        public void Get()
        {
            //Arrange
            CommonStudentsController controller = new CommonStudentsController();
            controller.SetHttpRequestMessage();

            //Possitive Case
            HttpResponseMessage httpResponseMessage = controller.Get(new string[] { "teacherjoe@gmail.com", "teacherLim@gmail.com" });
            Assert.AreEqual(HttpStatusCode.OK, httpResponseMessage.StatusCode);

            //compare with expected result
            CommonStudentsResult expectedResult = new CommonStudentsResult()
            {
                students = { "studentjon2@gmail.com", "studenthon@gmail.com" }
            };
            CommonStudentsResult result = JsonConvert.DeserializeObject<CommonStudentsResult>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(false, result.students.Except(expectedResult.students).Any());

        }
    }
}
