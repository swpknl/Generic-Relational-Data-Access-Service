using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BUCCriteriaLine : AbstractEntityBase
    {
        public string user_id { get; set; }
        public string type { get; set; }
        public string value { get; set; }
        public DateTime created_dt { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return "SELECT * FROM buc_criteria_line WHERE user_id = @param1";
        }

        public override string CreateInsertSQL()
        {
            return "INSERT INTO dbo.buc_criteria_line(user_id, type, value, created_dt) " +
                    "VALUES(@param1, @param2, @param3, @param4)";
        }
    }
}
