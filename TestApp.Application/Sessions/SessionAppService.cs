using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;
using Library;
using Library.Helpers;
using Newtonsoft.Json;
using TestApp.Dtos;
using TestApp.Sessions.Dto;

namespace TestApp.Sessions
{
    public class SessionAppService : TestAppAppServiceBase, ISessionAppService
    {
       
        [DisableAuditing]
        public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
        {
            var output = new GetCurrentLoginInformationsOutput();

            if (AbpSession.UserId.HasValue)
            {
                output.User = (await GetCurrentUserAsync()).MapTo<UserLoginInfoDto>();
            }

            if (AbpSession.TenantId.HasValue)
            {
                output.Tenant = (await GetCurrentTenantAsync()).MapTo<TenantLoginInfoDto>();
            }

            return output;
        }

        public object GetCurrentMFC(string valKey) {
            return ClaimHelper.GetCurrentMFC(valKey);
        }

        public void SetCurrentMFCs(List<MfcDto> valCurrentMFCs) {
            ClaimHelper.SetCurrentMFCs(valCurrentMFCs);
        }

        public void SetCurrentMFC(string valKey, object valvalue) {
            ClaimHelper.SetCurrentMFC(valKey, valvalue);
        }

        public IEnumerable<MfcDto> GetCurrentMFCs() {
            return ClaimHelper.GetCurrentMFCs();
        }
    }
}