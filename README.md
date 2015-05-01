## WechatPayment.SDK
C#版微信支付SDK（基于.NET Framework 4.0）
###目前已支持的API情况 
1. 统一下单API  
2. 订单查询API  
3. 申请退款API  

###客户端调用SDK涉及的命名空间
1. WechatPayment.SDK  
   该命名空间下是微信支付调用的核心类：WechatPaymentConfig和WechatPaymentClient
2. WechatPayment.SDK.Request  
   该命名空间下是微信支付对应的请求类  
3. WechatPayment.SDK.Response  
   该命名空间下是微信支付对应的响应类，一个Request类对应一个Response类  
4. WechatPayment.SDK.Notify  
   该命名空间下是微信支付异步回调对应的通知类

###如何使用SDK  
1. 初始化化配置参数（例如ASP.NET在Global.asax的Application_Start中配置）   
<pre>
   <code>
      WechatPaymentConfig.Initalize(
         secret: "Test1", //商户平台密匙
         appId: "Test1",  //公众号Id
         mchId: "Test1",  //商户Id
         certFilePath: "" //退款API需使用的证书路径
      );
   </code>
</pre>
2. 执行请求模板  
<pre>
   <code>
      //调用订单查询API
      OrderQueryRequest request = new OrderQueryRequest
      {
         TradeNum = "TEMP"
      };
      OrderQueryResponse response = WechatPaymentClient.Excute(request);
   </code>
</pre>
