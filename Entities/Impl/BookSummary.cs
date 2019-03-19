using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BookSummary : AbstractEntityBase
    {
        public override string GetStoredProcedure()
        {
            return "p_fobo_ws_summary";
        }
    }
}
