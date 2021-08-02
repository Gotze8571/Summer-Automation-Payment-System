using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Models;
using SAP_BusinessLogic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SAP_BusinessLogic.Services.Concrete
{
    public class AcoountCreationService : IAccountCreationService
    {
        public Task<ApiResponse> AccountCreation(AccountCreationDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
