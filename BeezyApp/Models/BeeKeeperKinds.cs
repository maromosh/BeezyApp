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
            Kinds.Add("דבוראים חובבים");
            Kinds.Add("דבוראים מקצועיים");
            Kinds.Add("דבוראים טיפוליים");
            Kinds.Add("דבוראים אורגניים / ביודינמיים");
            Kinds.Add("דבוראים מורים / מדריכים");
            Kinds.Add("דבוראים חקלאיים");
            Kinds.Add("דבוראים כימיים / מדעיים");
        }
    }
}
