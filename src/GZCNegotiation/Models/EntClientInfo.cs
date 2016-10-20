using System;

namespace GZCNegotiation.Models
{
    /// <summary>
    /// 企业信息--用于显示在客服界面上
    /// </summary>
    public class EntClientInfo
    {
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Name {get;set;}

        /// <summary>
        /// 企业十位编码
        /// </summary>
        public string TradeCode {get;set;}

        /// <summary>
        /// 社会信用代码
        /// </summary>
        public string SocialSecurityCode {get;set;}
    }
}