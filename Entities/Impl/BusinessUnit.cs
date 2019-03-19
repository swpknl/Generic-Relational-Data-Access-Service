using Dapper.Contrib.Extensions;
using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BusinessUnit : AbstractEntityBase
    {
        public string bu_type_cd { get; set; }
        public string bu_name { get; set; }
        public string description { get; set; }
        public string user_id { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return @"SELECT business_unit.bu_type_cd,   
                    rtrim(ltrim(business_unit.bu_name)) bu_name,   
                    rtrim(ltrim(business_unit.description)) description,
                    business_unit.user_id
                    FROM business_unit   
                    WHERE business_unit.bu_type_cd = @param";
        }
    }
}
