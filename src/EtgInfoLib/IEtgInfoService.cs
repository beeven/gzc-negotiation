using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using GZCNegotiation.Services.EtgInfoLib.Data;

namespace GZCNegotiation.Services.EtgInfoLib
{
    public interface IEtgInfoService
    {
        UserInfo GetCurrentUser();
        CompanyInfo GetCompanyInfo();
        Task<UserInfo> RegisterUserAsync(string requestToken);
    }
}