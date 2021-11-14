//Question 3
using d3hiring.Biz;
using d3hiring.Data;
using d3hiring.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace d3hiring.MVC.Controllers
{
    public class RetrieveForNotificationsController : BaseController
    {
        // POST api/retrievefornotifications
        public HttpResponseMessage Post(RetrieveForNotificationsModel data)
        {
            try
            {
                if (data != null && data.teacher != null && data.notification != null)
                {
                    var result = new RetrieveForNotificationsResult();

                    using (var db = new d3hiringDb())
                    {
                        //Get Student registered under this teacher
                        var tempResult = lessonBiz.getActiveStudentsByTeacherInLesson(db, data.teacher);
                        foreach (var item in tempResult)
                        {
                            result.recipients.Add(item);
                        }

                        //Get student from the notification
                        var startIndex = data.notification.IndexOf('@', 0);
                        if (startIndex > -1)
                        {
                            var emailList = data.notification.Substring(startIndex + 1);
                            foreach (var item in emailList.Split(new string[] { " @" }, StringSplitOptions.None))
                            {
                                //Check student if exist and active
                                var student = studentBiz.getStudentByEmail(db, item.Trim());
                                if (student != null && student.active == 1)
                                {
                                    //Must be registed before and active
                                    result.recipients.Add(student.email);
                                }
                            }
                        }
                    }
                    return CreateNoContentResponse(JsonConvert.SerializeObject(result));
                }
                else
                {
                    return CreateErrorResponse(new Exception("Fail to read request body."));
                }
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }            
        }

       
    }
}