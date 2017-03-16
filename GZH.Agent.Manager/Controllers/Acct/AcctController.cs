using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Http;
using GZH.Agent.Manager.Models;
using GZH.CL.Common.Serialize;
using log4net;
using System.Web;
using System.Web.Configuration;

namespace GZH.Agent.Manager.Controllers.Acct
{
    public class AcctController : ApiController
    {
        ILog logs = LogManager.GetLogger("AcctController");

        [Route("adm/acct/login/")]
        [HttpPost]
        public MsgEntity AccountLogin(AccountItem account)
        {
            MsgEntity r;

            string path = GZH.CL.ConfigSetting.weixinAgentAccount;
            Account accountEntity = XmlHelper.XmlDeserializeFromFile<GZH.Agent.Manager.Models.Account>(path, Encoding.UTF8);
            List<AccountItem> accounts = (from a in accountEntity.accountItem where (a.name == account.name && a.pwd == account.pwd) select a).ToList<AccountItem>();

            if (accounts.Count > 0)
            {
                if (accounts[0].status)
                {
                    r = ResponseMsg.SetEntity(out r, 4000);

                    string sessionName = WebConfigurationManager.AppSettings["loginSessionName"];
                    HttpContext.Current.Session[sessionName] = accounts[0];
                    logs.Fatal(accounts[0].name + " is logined");
                }
                else
                    r = ResponseMsg.SetEntity(out r, 4101);
            }
            else
                r = ResponseMsg.SetEntity(out r, 4100);

            return r;
        }
    }
}
