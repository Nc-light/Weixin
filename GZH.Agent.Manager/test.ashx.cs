using System.Collections.Generic;
using System.Web;
using GZH.CL.Config;
using GZH.CL.Config.Entity;

namespace GZH.Agent.Manager
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("run");

            AgentConfig agentConfig = new AgentConfig();
            int[] ids = new int[] { 424, 995 };

            context.Response.Write("del num:" + agentConfig.DelItem(ids));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}