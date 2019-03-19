using Entities.Contracts;
using System;

namespace Entities.Impl
{
    public class TradingBook : AbstractEntityBase
    {
        public string trading_book { get; set; }
        public string company_code { get; set; }
        public string description { get; set; }
        public DateTime last_upd_dt { get; set; }
        public string tb_ac_id_c { get; set; }
        public string aries_book { get; set; }
        public char exchange_rate_type { get; set; }
        public string department { get; set; }
        public string book_grid { get; set; }
        public string gmi_source_account { get; set; }
        public string atom_code { get; set; }
        public string atom_code_prefix { get; set; }
    }
}
