using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GZH.Agent.Manager.Controllers
{
    public class TestController : ApiController
    {
        [Route("test/{testId}")]
        [HttpGet]
        public string Test(int testId)
        {
            return "id is " + testId;
        }
    }
}
