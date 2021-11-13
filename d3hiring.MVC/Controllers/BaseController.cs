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
using System.Web.Http;
using d3hiring.MVC.Models.Response;
using d3hiring.Biz;

namespace d3hiring.MVC.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected lessonBiz lessonBiz;
        protected studentBiz studentBiz;
        protected teacherBiz teacherBiz;
        
        private string format = "application/json";

        public BaseController()
        {
            lessonBiz = new lessonBiz();
            studentBiz = new studentBiz();
            teacherBiz = new teacherBiz();
        }

        /// <summary>
        /// Return InternalserverError (500)
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected HttpResponseMessage CreateErrorResponse(Exception ex)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(JsonConvert.SerializeObject(new ExceptionModel() { message = ex.Message }), Encoding.UTF8, format);
            return response;
        }

        /// <summary>
        /// Return 204 (NoContent)
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        protected HttpResponseMessage CreateNoContentResponse(String body)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.NoContent);
            response.Content = new StringContent(body, Encoding.UTF8, format);
            return response;
        }

        /// <summary>
        /// Return 200 (OK)
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        protected HttpResponseMessage CreateOKResponse(String body)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(body, Encoding.UTF8, format);
            return response;
        }


    }
}