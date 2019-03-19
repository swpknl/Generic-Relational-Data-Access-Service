using Dapper.Contrib.Extensions;
using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class Book : AbstractEntityBase
    {
        public string bu_name { get; set; }
        public string description { get; set; }
        public string bu_type_cd { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return @"Select * FROM business_unit,   
                    business_unit_component,   
                    trading_book tb  
                    WHERE ( business_unit.bu_name = business_unit_component.entity_code ) and  
                    ( ( business_unit_component.bu_name = @param ) AND  
                    ( tb.trading_book =* substring(business_unit.bu_name,6,999) ) ) AND   business_unit.bu_type_cd not in ('PLEE','PLEG','PLEC')";
        }
    }
}
