using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BUCCriteriaLineRequest
    {
        public string user_id { get; set; }
        public string created_at { get; set; }
        public string prod_type_ie { get; set; }
        public bool breaks { get; set; }
        public double pv_tol { get; set; }
        public double pl_tol { get; set; }
        public string posn_date { get; set; }
        public string bo_source { get; set; }
        public string fo_source { get; set; }
        public string bu_name { get; set; }
    }
}
