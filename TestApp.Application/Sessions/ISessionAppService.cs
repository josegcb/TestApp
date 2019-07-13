using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Library;
using TestApp.Dtos;
using TestApp.Sessions.Dto;

namespace TestApp.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        void SetCurrentMFCs(List<MfcDto> valCurrentMFCs);

        void SetCurrentMFC(string valKey, object valValue);

        object GetCurrentMFC(string valKey);

        IEnumerable<MfcDto > GetCurrentMFCs();


    }
}
