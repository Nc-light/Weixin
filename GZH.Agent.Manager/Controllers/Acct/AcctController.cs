using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using GZH.Agent.Manager.Models;
using GZH.CL.Common.Serialize;

namespace GZH.Agent.Manager.Controllers.Acct
{
    public class AcctController : ApiController
    {
        [Route("adm/acct/login/")]
        [HttpPost]
        public MsgEntity AccountLogin(string name, string pwd)
        {
            MsgEntity r;

            string path = GZH.CL.ConfigSetting.weixinAgentAccount;
            Account accountEntity = XmlHelper.XmlDeserializeFromFile<GZH.Agent.Manager.Models.Account>(path, Encoding.UTF8);
            List<AccountItem> accountNames = (from a in accountEntity.accountItem where (a.name == name && a.pwd == pwd) select a).ToList<AccountItem>();

            if (accountNames.Count > 0)
            {
                if (accountNames[0].status)
                    r = ResponseMsg.SetEntity(out r, 4000);
                else
                    r = ResponseMsg.SetEntity(out r, 4101);
            }
            else
                r = ResponseMsg.SetEntity(out r, 4100);

            return r;
        }
    }
}
