using log4net;
using SnsApi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using GZH.CL.Config.Entity;
using GZH.CL.SnsApi;

namespace GZH.CL.Config
{
    public class AgentConfig
    {
        ILog logs = LogManager.GetLogger("AgentConfig");
        public CacheItemRemovedCallback onRemove = null;
        private string configPath = GZH.CL.ConfigSetting.weixinAgent;

        public WeixinAgentItem GetItemConfig(int id)
        {
            WeixinAgentItem r = null;
            WeixinAgent weixinAgent = GetConfig();
            //logs.Fatal(weixinAgent.AgentItem.Length);

            Array arr =
                (from weixinAgentItem in weixinAgent.AgentItem
                 where (weixinAgentItem.id == id)
                 select weixinAgentItem).ToArray<WeixinAgentItem>();

            if(arr.Length>0)
                r = (WeixinAgentItem)arr.GetValue(0);

            return r;
        }

        public WeixinAgent GetConfig()
        {
            WeixinAgent r = null;
            string cacheName = GZH.CL.Config.ConfigSetting.GetWeixinWeb().AgentCacheName;
            if (HttpContext.Current.Cache[cacheName] == null || HttpContext.Current.Cache[cacheName].ToString() == "")
            {
                r = GetFromFile();
                SetWeixinAgent2Cache(cacheName, r);
                //logs.Fatal("GetConfig From File......");
            }
            else
            {
                //logs.Fatal("GetConfig From Cache......");
                r = (WeixinAgent)HttpContext.Current.Cache.Get(cacheName);
            }
            return r;
        }

        private WeixinAgent GetFromFile()
        {
            return GZH.CL.Config.ConfigSetting.GetWeixinAgent();
        }

        private void SetWeixinAgent2Cache(string cacheName, WeixinAgent weixinAgent)
        {
            onRemove = new CacheItemRemovedCallback(RemovedCallback);
            try
            {
                CacheDependency dep = new CacheDependency(configPath);

                HttpContext.Current.Cache.Add(cacheName, weixinAgent, dep, DateTime.Now.Add(new TimeSpan(30, 0, 0, 0)), System.Web.Caching.Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable, onRemove);
                //logs.Fatal("SetToken2Cache >> "+ cacheName);
            }
            catch (Exception e)
            {
                //NCD.WebLog.SysWebLog.WriteLog("error:" + e.ToString());
            }
        }

        private void RemovedCallback(string key, object value, CacheItemRemovedReason reason)
        {
            Oauth2Token oauth2Token = new Oauth2Token();
            string[] scopes = new string[] { "snsapi_base", "snsapi_userinfo" };
            foreach (string scope in scopes)
            {
                oauth2Token.RemoveCache(scope);
            }

            logs.Fatal("AgentConfig RemovedCallback to remove token");
        }

    }
}
