using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using GZCNegotiation.Services.EtgInfoLib.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public class RemoteInfoFetcher : IRemoteInfoFetcher
    {
        private readonly string appId;
        private HttpClient httpClient;
        public RemoteInfoFetcher(string serviceUrl, string appId)
        {
            this.httpClient = new HttpClient() { BaseAddress = new Uri(serviceUrl) };
            this.appId = appId;
        }

        public class AccessTokenResponse
        {
            public string access_token { get; set; }
        }
        public async Task<string> GetAccessTokenAsync(string requestToken)
        {
            var responseString = await httpClient.GetStringAsync($"/token/getAccessToken/{requestToken}/{appId}");
            var res = JsonConvert.DeserializeObject<AccessTokenResponse>(responseString);
            return res.access_token;
        }
        
        public class CompanyInfoResponse
        {
            public string _id {get;set;}
            public string companyName {get;set;}
            public string scc {get;set;}
        }

        public async Task<CompanyInfo> GetCompanyInfoAsync(string accessToken)
        {
            var responseString = await httpClient.GetStringAsync($"/user/getCompany/{accessToken}");
            var res = JsonConvert.DeserializeObject<CompanyInfoResponse>(responseString);
            return new CompanyInfo()
            {
                Id = res._id,
                Name = res.companyName,
                SocialCreditCode = res.scc
            };

        }
        public class UserInfoResponse
        {
            public string _id {get;set;}
            public string displayName {get;set;}
            public string email {get;set;}
            public string companyId {get;set;}
            public string mobile {get;set;}
        }

        public async Task<UserInfo> GetUserInfoAsync(string accessToken)
        {
            var responseString = await httpClient.GetStringAsync($"/user/getUser/{accessToken}");
            var res = JsonConvert.DeserializeObject<UserInfoResponse>(responseString);
            return new UserInfo()
            {
                Id = res._id,
                Name = res.displayName,
                Mobile = res.mobile,
                CompanyId = res.companyId,
                Email = res.email
            };
            
        }
    }
}