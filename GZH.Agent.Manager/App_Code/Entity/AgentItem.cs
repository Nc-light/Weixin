using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GZH.Agent.Manager.App_Code.Entity
{
    public class AgentItem
    {
        public int id { get; set; }

        public string agent { get; set; }

        public string name { get; set; }

        public bool authorize { get; set; }

        public bool token { get; set; }

        public string sn { get; set; }

        public bool signature { get; set; }

        public DateTime begin { get; set; }

        public int end { get; set; }
    }
}