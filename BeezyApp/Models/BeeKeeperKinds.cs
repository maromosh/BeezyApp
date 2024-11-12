using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeezyApp.Models
{
    public class BeeKeeperKinds
    {
        public List<string> Kinds { get; set; }
        public BeeKeeperKinds() 
        {
            Kinds = new List<string>();
            Kinds.Add("דבוראים מקצועיים");
            Kinds.Add("1דבוראים מקצועיים");
            Kinds.Add("דבוראים מקצועיים2");
            Kinds.Add("דבוראים מקצועיים3");


        }
    }
}
