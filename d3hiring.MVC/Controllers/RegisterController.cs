//Question 1

using d3hiring.Biz;
using d3hiring.Data;
using d3hiring.MVC.Models;
using System;
using System.Net.Http;

namespace d3hiring.MVC.Controllers
{
    public class RegisterController : BaseController
    {
        // POST api/register
        public HttpResponseMessage Post(LessonModel data)
        {
            try
            {
                using (var db = new d3hiringDb())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        //Get Teacher
                        var teacherObj = teacherBiz.registerTeacherByEmail(db, data.teacher.Trim());

                        foreach (var item in data.students)
                        {
                            //Get Student
                            var studentObj = studentBiz.registerStudentByEmail(db, item.Trim());

                            //Register to lesson
                            lessonBiz.registerStudentToLesson(db, teacherObj, studentObj);

                        }

                        db.SaveChanges();
                        transaction.Commit();
                    }
                }
                return CreateNoContentResponse("");
            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }            
        }

       
    }
}