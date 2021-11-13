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
    public class SuspendController : BaseController
    {
        // POST api/register
        public HttpResponseMessage Post(SuspendModel data)
        {
            try
            {
                using (var db = new d3hiringDb())
                {
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        if(studentBiz.suspendStudentByEmail(db, data.student.Trim()) != null)
                        {
                            db.SaveChanges();
                            transaction.Commit();
                        }

                        //Todo: What if student not found ?
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