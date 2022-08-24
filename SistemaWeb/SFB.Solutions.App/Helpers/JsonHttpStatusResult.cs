using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SFB.Solutions.App.Helpers
{
    public class JsonHttpStatusResult : JsonResult
    {
        private readonly HttpStatusCode _httpStatus;
        private readonly object _data;
        public JsonHttpStatusResult(object data, HttpStatusCode httpStatus)
        {
            _data = data;
            _httpStatus = httpStatus;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatus;
            base.ExecuteResult(context);
        }
    }
}