using GZH.CL.Common.Serialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GZH.CL.Config
{
    public class ConfigSetting : GZH.CL.ConfigSetting
    {
        public static GZH.CL.Config.Entity.Weixin GetWeixin()
        {
            string path = GZH.CL.ConfigSetting.weixin;
            GZH.CL.Config.Entity.Weixin r = XmlHelper.XmlDeserializeFromFile<GZH.CL.Config.Entity.Weixin>(path, Encoding.UTF8);

            return r;
        }

        public static GZH.CL.Config.Entity.WeixinWeb GetWeixinWeb()
        {
            string path = GZH.CL.ConfigSetting.weixinWeb;
            GZH.CL.Config.Entity.WeixinWeb r = XmlHelper.XmlDeserializeFromFile<GZH.CL.Config.Entity.WeixinWeb>(path, Encoding.UTF8);

            return r;
        }

        public static GZH.CL.Config.Entity.WeixinAgent GetWeixinAgent()
        {
            string path = GZH.CL.ConfigSetting.weixinAgent;
            GZH.CL.Config.Entity.WeixinAgent r = XmlHelper.XmlDeserializeFromFile<GZH.CL.Config.Entity.WeixinAgent>(path, Encoding.UTF8);

            return r;
        }
    }
}
