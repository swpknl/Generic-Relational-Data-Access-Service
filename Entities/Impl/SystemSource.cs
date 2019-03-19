using Dapper.Contrib.Extensions;
using Entities.Contracts;

namespace Entities.Impl
{
    public class SystemSource : AbstractEntityBase
    {
        public string rec_source { get; set; }
        public string front { get; set; }
        public string back { get; set; }
        public override string CreateGetAllEntitiesSQL()
        {
            return "SELECT * FROM rec_source_system";
        }
    }
}
