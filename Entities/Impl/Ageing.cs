using Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Impl
{
    public class Ageing : AbstractEntityBase
    {
        public string cob { get; set; }
        public double fo_posn { get; set; }
        public double bo_posn { get; set; }
        public double fo_price { get; set; }
        public double bo_price { get; set; }
        public double fo_panl { get; set; }
        public double bo_panl { get; set; }
        public double fo_value { get; set; }
        public double bo_value { get; set; }
        public string comment { get; set; }
        public string last_upd_by { get; set; }
        public string last_upd { get; set; }
        public override string CreateGetAllEntitiesSQL()
        {
            return @"SELECT	dt_loaded,
                    bo_posn,
                    bo_price,
                    bo_value,
                    fo_posn,
                    fo_price,
                    fo_value,
                    ROUND(fo_PandL / er.buy_rate, 2) 'fo_PandL',
                    ROUND(bo_PandL / er.buy_rate, 2) 'bo_PandL',
                    er.buy_rate,
                    currency,
                    fo_source 'fo_source',
                    bo_source 'bo_source',
                    narrative 'narrative',
                    last_upd_user 'last_upd_user',
                    last_upd_date 'last_upd_date',
                    0 'posn_age_brk',
                    0 'price_age_brk',
                    0 'pandl_age_brk',
                    0 'display_type'
                    FROM		rec_posn,
                                exchange_rate er,
                                trading_book tb
                    WHERE		dt_loaded						IN (@param1)
                    AND		centre							= @param2
                    AND		hugo_code						= @param3
                    AND		rec_source						= @param4
                    and		er.date							= dt_loaded
                    and		er.from_ccy_code				= currency
                    AND		tb.trading_book = @param2
                    AND		tb.exch_rate_type = er.exch_rate_type";
        }
    }
}
