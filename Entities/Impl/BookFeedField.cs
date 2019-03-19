using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BookFeedField : AbstractEntityBase
    {
        public string name { get; set; }
        public string value { get; set; }
        public string display_name { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return @"SELECT * FROM {0}";
        }
    }
}
