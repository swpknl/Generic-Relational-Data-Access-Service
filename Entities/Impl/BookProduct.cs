using Entities.Contracts;

namespace Entities.Impl
{
    public class BookProduct : AbstractEntityBase
    {
        public string dl_position_id { get; set; }
        public string prod_id_type { get; set; }
        public string prod_id { get; set; }
        public string company_code { get; set; }
        public string trading_book { get; set; }
        public string posn_dt { get; set; }
        public string posn_source { get; set; }
        public double quantity { get; set; }
        public double bid_price { get; set; }
        public double offer_price { get; set; }
        public double cost { get; set; }

        public override string CreateGetAllEntitiesSQL()
        {
            return @"SELECT NULL dl_position_id,
                    prod_id_type,
                    prod_id,
                    company_code,
                    trading_book,
                    posn_dt,
                    posn_source,
                    quantity,
                    bid_price,
                    offer_price,
                    cost,
                    NULL price_source,
                    ccy_code cost_ccy,
                    value,
                    ccy_code value_ccy,
                    status,
                    base_equiv_posn,
                    prod_code,
                    dt_loaded,
                    accrual_factor,
                    last_upd_dt,
                    last_upd_by,
                    delta_factor,
                    mtd_real_pl,
                   mtd_unreal_pl,
                   mtd_net_pl,
                   mtd_div_rec,
                   mtd_div_rec_ccy,
                    product_type_id,
                   vega_factor,
                   gamma_factor,
                   volatility,
                   value_dated_position,
                   value_dated_cost,
                   accretion_income,
                   forward_purch_int,
                   past_purch_int,
                   avg_price,
                   cum_acc_int,
                   settl_date_mkt_val_cons,
                   ind_load_to_core,
                   ind_via_cda,
                   id_batch,
                   pmultf,
                   coupon_income 
                FROM buc_dl_product_position
                WHERE	posn_dt = @param1
                AND	trading_book != 'DIASOFT'
                AND	trading_book = @param2
                AND	prod_id = @param3

                UNION ALL
                SELECT NULL dl_position_id,
                    prod_id_type,
                    prod_id,
                    company_code,
                    trading_book,
                    posn_dt,
                    posn_source,
                    quantity,
                    bid_price,
                    offer_price,
                    cost,
                    NULL price_source,
                    ccy_code cost_ccy,
                    value,
                    ccy_code value_ccy,
                    status,
                    base_equiv_posn,
                    prod_code,
                    dt_loaded,
                    accrual_factor,
                    last_upd_dt,
                    last_upd_by,
                    delta_factor,
                    mtd_real_pl,
                   mtd_unreal_pl,
                   mtd_net_pl,
                   mtd_div_rec,
                   mtd_div_rec_ccy,
                    product_type_id,
                   vega_factor,
                   gamma_factor,
                   volatility,
                   value_dated_position,
                   value_dated_cost,
                   accretion_income,
                   forward_purch_int,
                   past_purch_int,
                   avg_price,
                   cum_acc_int,
                   settl_date_mkt_val_cons,
                   ind_load_to_core,
                   ind_via_cda,
                   id_batch,
                   pmultf,
                   coupon_income 
                FROM buc_dl_product_position
                WHERE	posn_dt = @param1
                AND	trading_book = 'DIASOFT'
                AND	company_code = '679'
                AND	prod_id = @param3";
        }
    }
}
