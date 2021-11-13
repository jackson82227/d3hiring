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
    public class RegisterControllerTest
    {

        [TestMethod]
        public void Post()
        {
            //Arrange
            RegisterController controller = new RegisterController();
            controller.SetHttpRequestMessage();

            //Possitive Case
            var lessonModel = new d3hiring.MVC.Models.LessonModel();
            lessonModel.teacher = "teacherken@gmail.com";
            lessonModel.students = new string[] { "studentjon@gmail.com", "studenthon@gmail.com" };
            HttpResponseMessage httpResponseMessage = controller.Post(lessonModel);
            Assert.AreEqual(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);


            //Negative Case (VAPT)
            lessonModel = new d3hiring.MVC.Models.LessonModel();
            lessonModel.teacher = ";drop table student; --";
            lessonModel.students = new string[] { "studentjon@gmail.com", "studenthon@gmail.com" };
            httpResponseMessage = controller.Post(lessonModel);
            Assert.AreEqual(HttpStatusCode.NoContent, httpResponseMessage.StatusCode);
        }
    }
}
