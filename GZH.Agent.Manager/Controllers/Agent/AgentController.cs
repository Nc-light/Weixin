using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GZH.CL.Config;
using GZH.CL.Config.Entity;
using log4net;
using GZH.Agent.Manager.Controllers.Agent.Response;

namespace GZH.Agent.Manager.Controllers.Agent
{
    public class AgentController : ApiController
    {
        AgentConfig agentConfig;
        ILog logs = LogManager.GetLogger("AgentController");

        public AgentController()
        {
            agentConfig = new AgentConfig();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("adm/agent/{id}")]
        public WeixinAgentItem GetItem(int id)
        {
            return agentConfig.GetItem(id);
        }

        [Route("adm/agents/")]
        public List<WeixinAgentItem> GetItems()
        {
            return agentConfig.GetItems();
        }

        [Route("adm/agents/applyers")]
        public List<string> GetAgentName()
        {
            return agentConfig.GetAgentName();
        }

        [Route("adm/agent/add/")]
        [HttpPost]
        public MsgEntity PostAgent(WeixinAgentItem item)
        {
            MsgEntity r;

            if (!agentConfig.IsExist(item.id))
            {
                item = agentConfig.AddItem(item);

                if (item == null)
                    r = ResponseMsg.SetEntity(out r, 1101);
                else if (item.id > 0)
                    r = ResponseMsg.SetEntity(out r, 1000);
                else
                    r = ResponseMsg.SetEntity(out r, 1102);
            }
            else
                r = ResponseMsg.SetEntity(out r, 1100);

            return r;
        }

        [Route("adm/agent/update/")]
        [HttpPost]
        public MsgEntity PutAgent(WeixinAgentItem item)
        {
            MsgEntity r;

            if (agentConfig.IsExist(item.id))
            {
                if (agentConfig.UpdateItem(item))
                    r = ResponseMsg.SetEntity(out r, 2000);
                else
                    r = ResponseMsg.SetEntity(out r, 2101);
            }
            else
                r = ResponseMsg.SetEntity(out r, 2100);

            return r;
        }

        [Route("adm/agent/del/{id}")]
        [HttpPost]
        public MsgEntity DelAgent(int id)
        {
            MsgEntity r;

            if (agentConfig.IsExist(id))
            {
                if (agentConfig.DelItem(id))
                    r = ResponseMsg.SetEntity(out r, 3000);
                else
                    r = ResponseMsg.SetEntity(out r, 3101);
            }
            else
                r = ResponseMsg.SetEntity(out r, 3100);

            return r;
        }

        [Route("adm/agent/del/")]
        [HttpPost]
        public MsgEntity DelAgents(int[] ids)
        {
            MsgEntity r;

            int delNum = agentConfig.DelItem(ids);

            if (delNum > 0)
            {
                r = ResponseMsg.SetEntity(out r, 3000);
            }
            else if (delNum == 0)
                r = ResponseMsg.SetEntity(out r, 3100);
            else
                r = ResponseMsg.SetEntity(out r, 3101);

            return r;
        }
    }
}
