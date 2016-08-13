using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WechatPayment.SDK.Request
{
    using WechatPayment.SDK.Attritubes;
    using WechatPayment.SDK.Exceptions;
    using WechatPayment.SDK.Response;

    /// <summary>
    /// 统一下单Request
    /// </summary>
    public class UnifiedOrderRequest : BasicRequest<UnifiedOrderResponse>
    {
        /// <summary>
        /// 统一下单ApiUrl
        /// </summary>
        public override string ApiUrl { get { return "https://api.mch.weixin.qq.com/pay/unifiedorder"; } }

        /// <summary>
        /// 自定义验证参数
        /// </summary>
        public override void Validate()
        {
            //基础参数验证
            base.Validate();

            //自定义验证参数
            if (TradeType == "NATIVE" && string.IsNullOrEmpty(ProductId))
            {
                throw new RequestParameterIsRequireException("ProductId");
            }

            if (TradeType == "JSAPI" && string.IsNullOrEmpty(OpenId))
            {
                throw new RequestParameterIsRequireException("OpenId");
            }
        }

        /// <summary>
        /// 终端设备号
        /// </summary>
        [RequestParameter("device_info")]
        public string DeviceInfo { get; set; }

        /// <summary>
        /// 商品或支付单间要描述
        /// </summary>
        [RequestParameter("body", true)]
        public string Desc { get; set; }

        /// <summary>
        /// 商品名称明细
        /// </summary>
        [RequestParameter("detail")]
        public string ProductDetail { get; set; }

        /// <summary>
        /// 附加数据
        /// </summary>
        [RequestParameter("attach")]
        public string Attach { get; set; }

        /// <summary>
        /// 商户系统内部订单号
        /// </summary>
        [RequestParameter("out_trade_no", true)]
        public string TradeNum { get; set; }

        /// <summary>
        /// 货币类型
        /// </summary>
        [RequestParameter("fee_type")]
        public string FeeType { get; set; }

        /// <summary>
        /// 订单总金额
        /// </summary>
        [RequestParameter("total_fee", true)]
        public int? TotalFee { get; set; }

        /// <summary>
        /// 终端IP
        /// </summary>
        [RequestParameter("spbill_create_ip", true)]
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// 交易开始时间
        /// </summary>
        [RequestParameter("time_start")]
        public string TimeStart { get; set; }

        /// <summary>
        /// 交易结束时间
        /// </summary>
        [RequestParameter("time_expire")]
        public string TimeExpire { get; set; }

        /// <summary>
        /// 商品标记
        /// </summary>
        [RequestParameter("goods_tag")]
        public string ProductTag { get; set; }

        /// <summary>
        /// 接收微信支付异步通知回调地址
        /// </summary>
        [RequestParameter("notify_url", true)]
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 交易类型
        /// <example>JSAPI|NATIVE|APP|WAP</example>
        /// </summary>
        [RequestParameter("trade_type", true)]
        public string TradeType { get; set; }

        /// <summary>
        /// 商品Id(trade_type=NATIVE，此参数必传)
        /// </summary>
        [RequestParameter("product_id")]
        public string ProductId { get; set; }

        /// <summary>
        /// 用户标识(trade_type=JSAPI，此参数必传)
        /// </summary>
        [RequestParameter("openid")]
        public string OpenId { get; set; }
    }
}