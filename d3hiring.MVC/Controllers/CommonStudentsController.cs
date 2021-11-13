//Question 2
using d3hiring.Data;
using d3hiring.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace d3hiring.MVC.Controllers
{
    public class CommonStudentsController : BaseController
    {
        

        // GET api/commonstudents
        //Example value: commonstudents?teacher=teacherken%40gmail.com&teacher=teacherjoe%40gmail.com
        public HttpResponseMessage Get([FromUri] string[] teacher)
        {
            try
            {
                var result = new CommonStudentsResult();
                
                using (var db = new d3hiringDb())
                {
                    foreach (var item in teacher)
                    {
                        //Get teacher
                        var teacherObj = teacherBiz.getTeacherByEmail(db, item.Trim());

                        if(teacherObj !=null)
                        {
                            //Get student if registered in the lesson
                            var tempResult = lessonBiz.getStudentsByTeacherInLesson(db, teacherObj);

                            if (tempResult.Count > 0)
                            {
                                if (result.students.Count == 0)
                                {
                                    //First set, add to list for comparison on next set.
                                    result.students.AddRange(tempResult);
                                }
                                else
                                {
                                    //if student found, intersect with previous set
                                    result.students = result.students.Intersect(tempResult).ToList();
                                }
                            }
                        }

                        //Todo: What if teacher not found ?
                        
                    }
                }

                return CreateOKResponse(JsonConvert.SerializeObject(result));

            }
            catch (Exception ex)
            {
                return CreateErrorResponse(ex);
            }
        }

    }
}