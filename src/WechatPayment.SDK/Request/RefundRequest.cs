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
    /// 退款单申请Request
    /// </summary>
    public class RefundRequest : BasicRequest<RefundResponse>
    {
        /// <summary>
        /// 退款单申请ApiUrl
        /// </summary>
        public override string ApiUrl { get { return "https://api.mch.weixin.qq.com/secapi/pay/refund"; } }

        /// <summary>
        /// 请求需要调用证书
        /// </summary>
        public override bool IsPostRequireCertificate { get { return true; } }

        /// <summary>
        /// 终端设备号
        /// </summary>
        [RequestParameter("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 微信订单号
        /// </summary>
        [RequestParameter("transaction_id", true)]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统内部的订单号
        /// </summary>
        [RequestParameter("out_trade_no", true)]
        public string TradeNum { get; set; }

        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
        [RequestParameter("out_refund_no", true)]
        public string RefundNum { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [RequestParameter("total_fee", true)]
        public int? TotalFee { get; set; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        [RequestParameter("refund_fee", true)]
        public int? RefundFee { get; set; }

        /// <summary>
        /// 退款货币种类
        /// </summary>
        [RequestParameter("refund_fee_type")]
        public string RefundFeeType { get; set; }

        /// <summary>
        /// 退款操作员（默认为商户号）
        /// </summary>
        [RequestParameter("op_user_id", true)]
        public string OperationUserId { get; set; }
    }
}