using Dapper.Contrib.Extensions;
using Entities.Contracts;
using System;

namespace Entities.Impl
{
    public class ProductType : AbstractEntityBase
    {
        public string group { get; set; }
        public string group_desc { get; set; }
        public int prod_type { get; set; }
        public string prod_type_desc { get; set; }
        public override string CreateGetAllEntitiesSQL()
        {
            return @"select distinct r.parent_id 'group', pt2.description 'group_desc', convert(numeric,pt.product_type_id) 'prod_type',
                    pt.description 'prod_type_desc' from product_type pt, related_prod_type r, product_type pt2 where r.child_id = pt.product_type_id and r.parent_id = pt2.product_type_id";
        }
    }
}
