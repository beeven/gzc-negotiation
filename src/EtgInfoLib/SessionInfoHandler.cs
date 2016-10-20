using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using GZCNegotiation.Services.EtgInfoLib.Data;
using System.IO;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public class SessionInfoHandler:ISessionInfoHandler
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public SessionInfoHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            
        }

        public string GetAccessToken()
        {
            return this.httpContextAccessor.HttpContext.Session.GetString(".EtgInfo.AccessToken");
        }

        public CompanyInfo GetCompanyInfo()
        {
            var userBytes = this.httpContextAccessor.HttpContext.Session.Get(".EtgInfo.Company");
            using(var buf = new MemoryStream(userBytes))
            {
                return ProtoBuf.Serializer.Deserialize<Data.CompanyInfo>(buf);
            }
        }

        public UserInfo GetUserInfo()
        {
            var userBytes = this.httpContextAccessor.HttpContext.Session.Get(".EtgInfo.User");
            using(var buf = new MemoryStream(userBytes))
            {
                return ProtoBuf.Serializer.Deserialize<Data.UserInfo>(buf);
            }
        }

        public void SaveAccessToken(string accessToken)
        {
            this.httpContextAccessor.HttpContext.Session.SetString(".EtgInfo.AccessToken",accessToken);
        }

        public void SaveCompanyInfo(CompanyInfo companyInfo)
        {
            
            using(var buf = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(buf,companyInfo);
                this.httpContextAccessor.HttpContext.Session.Set(".EtgInfo.companyInfo",buf.ToArray());
            }
        }

        public void SaveUserInfo(UserInfo userInfo)
        {
            using(var buf = new MemoryStream())
            {
                ProtoBuf.Serializer.Serialize(buf,userInfo);
                this.httpContextAccessor.HttpContext.Session.Set(".EtgInfo.User",buf.ToArray());
            }
        }
    }
}