using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class BookDetail : AbstractEntityBase
    {
        public string centre { get; set; }
        public string hugo_code { get; set; }
        public string description { get; set; }
        public string ccy { get; set; }
        public int posn_diff { get; set; }
        public int price_diff { get; set; }
        public int pandl_diff { get; set; }
        public int pv_diff { get; set; }
        public int posn_age_break { get; set; }
        public string narrative { get; set; }
        public string last_upd_username { get; set; }
        public string last_upd_date { get; set; }
        public string rec_source { get; set; }
        public string dt_loaded { get; set; }
        public string bo_source { get; set; }
        public string fo_source { get; set; }
        public string trading_book { get; set; }
        public string aries_book { get; set; }
        public string book_desc { get; set; }
        public string prod_code { get; set; }
        public string isin { get; set; }
        public double multi { get; set; }
        public double fctr { get; set; }
        public double bo_posn { get; set; }
        public double bo_price { get; set; }
        public double bo_value { get; set; }
        public double bo_pandl { get; set; }
        public double fo_posn { get; set; }
        public double fo_price { get; set; }
        public double fo_value { get; set; }
        public double fo_pandl { get; set; }
        public string prod_type { get; set; }
        public string prod_type_desc { get; set; }
        public double ticker { get; set; }
        public double pool_factor { get; set; }
        public int price_age_break { get; set; }
        public int pandl_age_break { get; set; }
        public double gmi_trade_price_multi { get; set; }
        public double gmi_strike_price_multi { get; set; }
        public double bo_dividend_pandl { get; set; }
        public string ticker_code { get; set; }
        public string product_category { get; set; }
        public override string GetStoredProcedure()
        {
            return "p_fobo_ws_summary";
        }

        public override string CreateGetByIdSQL()
        {
            return "SELECT * FROM rec_posn WHERE dt_loaded = @param1 AND rec_source = @param2 AND centre = @param3 AND hugo_code = @param4";
        }

        public override string CreateUpdateSQL()
        {
            return "UPDATE rec_posn SET narrative = @param1, last_upd_user = @param2, last_upd_date = @param3 WHERE dt_loaded = @param4 AND rec_source = @param5 AND centre = @param6 AND hugo_code = @param7";
        }
    }
}
