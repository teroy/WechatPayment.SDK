using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Request
{
    using WechatPayment.SDK.Attritubes;
    using WechatPayment.SDK.Response;

    /// <summary>
    /// 查询订单Request
    /// </summary>
    public class OrderQueryRequest : BasicRequest<OrderQueryResponse>
    {
        /// <summary>
        /// 查询订单ApiUrl
        /// </summary>
        public override string ApiUrl { get { return "https://api.mch.weixin.qq.com/pay/orderquery"; } }

        /// <summary>
        /// 自定义参数验证
        /// </summary>
        public override void Validate()
        {
            //基础参数验证
            base.Validate();
        }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [RequestParameter("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部的订单号
        /// </summary>
        [RequestParameter("out_trade_no")]
        public string TradeNum { get; set; }
    }
}