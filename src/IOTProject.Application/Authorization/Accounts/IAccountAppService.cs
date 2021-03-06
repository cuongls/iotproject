﻿using System.Threading.Tasks;
using Abp.Application.Services;
using IOTProject.Authorization.Accounts.Dto;

namespace IOTProject.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
