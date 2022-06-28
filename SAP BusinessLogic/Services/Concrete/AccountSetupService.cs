using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Models;
using SAP_BusinessLogic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAP_BusinessLogic.Services.Concrete
{
    public class AccountSetupService : IAccountSetupService
    {
        private readonly IAccountSetupRepo _repo;
        public Task<ApiResponse> AccountCreation(AccountCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DepositAccount(AccountCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<AccountCreationDto> GetAccountCreation(string AccountNo)
        {
            throw new NotImplementedException();
        }
    }
}
