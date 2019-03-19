using Dapper.Contrib.Extensions;
using Entities.Contracts;
using System;

namespace Entities.Impl
{
    public class BreakReason : AbstractEntityBase
    {
        public string reason_code { get; set; }
        public string description { get; set; }
        public string last_upd_by { get; set; }
        public DateTime last_upd_dt { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return "SELECT * FROM buc_fobo_break_reason";
        }

        public override string CreateInsertSQL()
        {
            return "INSERT INTO dbo.buc_fobo_break_reason(reason_code, description, last_upd_by, last_upd_dt) VALUES(@param1, @param2, @param3, @param4)";
        }

        public override string CreateUpdateSQL()
        {
            return "UPDATE dbo.buc_fobo_break_reason SET description = @param1, last_upd_by = @param2, last_upd_dt = @param3 where reason_code = @param4";
        }

        public override string CreateGetByIdSQL()
        {
            return "SELECT * FROM buc_fobo_break_reason WHERE reason_code = @param1";
        }

        public override string CreateDeleteSQL()
        {
            return "DELETE FROM buc_fobo_break_reason WHERE reason_code = @param1";
        }
    }
}
