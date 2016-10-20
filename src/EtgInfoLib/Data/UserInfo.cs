using System;
using ProtoBuf;

namespace GZCNegotiation.Services.EtgInfoLib.Data
{
    [ProtoContract]
    public class UserInfo
    {
        [ProtoMember(1)]
        public string Id {get;set;}

        [ProtoMember(2)]
        public string Name {get;set;}

        [ProtoMember(3)]
        public string Mobile {get;set;}

        [ProtoMember(4)]
        public string Email {get;set;}
        
        [ProtoMember(5)]
        public string CompanyId {get;set;}
    }
}