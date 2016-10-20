using System;
using System.Threading.Tasks;
using GZCNegotiation.Services.EtgInfoLib.Data;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public interface IRemoteInfoFetcher
    {
        Task<string> GetAccessTokenAsync(string requestToken);
        Task<UserInfo> GetUserInfoAsync(string accessToken);
        Task<CompanyInfo> GetCompanyInfoAsync(string accessToken);
    }
}