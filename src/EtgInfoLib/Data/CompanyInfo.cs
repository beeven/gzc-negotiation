using System;
using ProtoBuf;

namespace GZCNegotiation.Services.EtgInfoLib.Data
{
    [ProtoContract]
    /// <summary>
    /// 企业信息
    /// </summary>
    public class CompanyInfo
    {
        [ProtoMember(1)]
        public string Id {get;set;}

        [ProtoMember(2)]
        public string Name {get;set;}

        [ProtoMember(3)]
        /// <summary>
        /// 社会信用代码
        /// </summary>
        public string SocialCreditCode {get;set;}
    }
}