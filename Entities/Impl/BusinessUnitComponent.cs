using Dapper.Contrib.Extensions;
using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BusinessUnitComponent : AbstractEntityBase
    {
        public string bu_name { get; set; }
        public string bu_type_cd { get; set; }
        public string entity_type { get; set; }
        public string entity_code { get; set; }
        public char include_flag { get; set; }
        public string sequence { get; set; }
    }
}
