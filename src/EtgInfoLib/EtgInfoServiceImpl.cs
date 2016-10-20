using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using GZCNegotiation.Services.EtgInfoLib.Data;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public class EtgInfoServiceImpl : IEtgInfoService
    {
        private readonly IRemoteInfoFetcher remoteInfoFetcher;
        private readonly ISessionInfoHandler sessionInfoHandler;

        public EtgInfoServiceImpl(IRemoteInfoFetcher remoteInfoFetcher, ISessionInfoHandler sessionInfoHandler)
        {
            this.remoteInfoFetcher = remoteInfoFetcher;
            this.sessionInfoHandler = sessionInfoHandler;
        }

        public CompanyInfo GetCompanyInfo()
        {
            var companyInfo = sessionInfoHandler.GetCompanyInfo();
            return companyInfo;
        }

        public UserInfo GetCurrentUser()
        {
            var userInfo = sessionInfoHandler.GetUserInfo();

            return userInfo;
        }

        public async Task<UserInfo> RegisterUserAsync(string requestToken)
        {
            var accessToken = await remoteInfoFetcher.GetAccessTokenAsync(requestToken);
            sessionInfoHandler.SaveAccessToken(accessToken);
            var userInfo = await remoteInfoFetcher.GetUserInfoAsync(accessToken);
            sessionInfoHandler.SaveUserInfo(userInfo);
            var companyInfo = await remoteInfoFetcher.GetCompanyInfoAsync(accessToken);
            sessionInfoHandler.SaveCompanyInfo(companyInfo);
            return userInfo;
        }


    }
}