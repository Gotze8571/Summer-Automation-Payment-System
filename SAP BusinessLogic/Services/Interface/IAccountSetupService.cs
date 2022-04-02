using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAP_BusinessLogic.Services.Interface
{
    public interface IAccountSetupService
    {
        Task<ApiResponse> AccountCreation(AccountCreationDto dto);

        Task<ApiResponse> DepositAccount(AccountCreationDto dto);
        Task<AccountCreationDto> GetAccountCreation();
        
    }
}
