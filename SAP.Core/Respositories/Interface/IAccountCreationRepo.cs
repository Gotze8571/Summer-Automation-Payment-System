using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Respositories.Interface
{
    public interface IAccountCreationRepo
    {
        Task<ApiResponse> AccountCreation(AccountCreationDto dto);
    }
}
