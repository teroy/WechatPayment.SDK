using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WechatPayment.SDK.Response
{
    /// <summary>
    /// 退款申请Response
    /// </summary>
    [XmlRoot("xml")]
    public class RefundResponse : BasicResponse
    {
        /// <summary>
        /// 业务结果
        /// </summary>
        [XmlElement("result_code")]
        public string ResultCode { get; set; }

        /// <summary>
        /// 错误代码
        /// </summary>
        [XmlElement("err_code")]
        public string ErrorCode { get; set; }

        /// <summary>
        /// 错误代码描述
        /// </summary>
        [XmlElement("err_code_des")]
        public string ErrorCodeDesc { get; set; }

        /// <summary>
        /// 公众号Id
        /// </summary>
        [XmlElement("appid")]
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        [XmlElement("mch_id")]
        public string MerchantId { get; set; }

        /// <summary>
        /// 设备号
        /// </summary>
        [XmlElement("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 随机字符串
        /// </summary>
        [XmlElement("nonce_str")]
        public string NonceStr { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        [XmlElement("sign")]
        public string Sign { get; set; }

        /// <summary>
        /// 微信支付订单号
        /// </summary>
        [XmlElement("transaction_id")]
        public string TransactionId { get; set; }

        /// <summary>
        /// 商户系统的订单号
        /// </summary>
        [XmlElement("out_trade_no")]
        public string TradeNum { get; set; }

        /// <summary>
        /// 商户系统内部的退款单号
        /// </summary>
        [XmlElement("out_refund_no")]
        public string RefundNum { get; set; }

        /// <summary>
        /// 微信退款单Id
        /// </summary>
        [XmlElement("refund_id")]
        public string RefundId { get; set; }

        /// <summary>
        /// 退款渠道 <example>ORIGINAL | BALANCE</example>
        /// </summary>
        [XmlElement("refund_channel")]
        public string RefundChannel { get; set; }

        /// <summary>
        /// 退款总金额
        /// </summary>
        [XmlElement("refund_fee")]
        public int? RefundFee { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [XmlElement("total_fee")]
        public int? TotalFee { get; set; }

        /// <summary>
        /// 订单货币种类
        /// </summary>
        [XmlElement("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 现金支付金额
        /// </summary>
        [XmlElement("cash_fee")]
        public int? CashFee { get; set; }

        /// <summary>
        /// 现金退款金额
        /// </summary>
        [XmlElement("cash_refund_fee")]
        public int? CashRefundFee { get; set; }

        /// <summary>
        /// 代金券或立减优惠退款金额
        /// </summary>
        [XmlElement("coupon_refund_fee")]
        public int? CouponRefundFee { get; set; }

        /// <summary>
        /// 代金券或立减优惠使用数量
        /// </summary>
        [XmlElement("coupon_refund_count")]
        public int? CouponRefundCount { get; set; }

        /// <summary>
        /// 代金券或立减优惠ID
        /// </summary>
        [XmlElement("coupon_refund_id")]
        public string CouponRefundId { get; set; }
    }
}