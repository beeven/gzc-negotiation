using System;
using GZCNegotiation.Services.EtgInfoLib.Data;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public interface ISessionInfoHandler
    {
        void SaveAccessToken(string accessToken);
        string GetAccessToken();
        void SaveUserInfo(UserInfo userInfo);
        UserInfo GetUserInfo();

        void SaveCompanyInfo(CompanyInfo companyInfo);
        CompanyInfo GetCompanyInfo();
    }
}