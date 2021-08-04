using SAP_BusinessLogic.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP.Core.Respositories.Interface
{
    public interface IGetSAP_Account
    {
        Task<AccountCreation> GetSAP_Account();
    }
}
