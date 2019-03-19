using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class RecPosnRequest
    {
        public string description { get; set; }
        public string last_upd_by { get; set; }
        public DateTime last_update_dt { get; set; }
        public string dt_loaded { get; set; }
        public string rec_source { get; set; }
        public string centre { get; set; }
        public string hugo_code { get; set; }

    }
}
