using System;
using System.Web;

namespace GZH.CL
{
    public class ConfigSetting
    {
        public static string configPath = AppDomain.CurrentDomain.BaseDirectory + "/config/";
        //public static string configPath = @"C:\projects\Weixin\GZH\Api\Weixin.Api\config\";
        public static string weixin = configPath + "NCD.Weixin.config";
        public static string weixinWeb = configPath + "NCD.Weixin.Web.config";
        public static string weixinAgent = configPath + "NCD.Weixin.Agent.config";
    }
}
