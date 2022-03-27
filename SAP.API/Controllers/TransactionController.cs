using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_BusinessLogic.DTOs;
using System.Collections.Generic;

namespace SAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public TransactionController()
        {

        }

        [HttpGet("Get-Transaction")]
        public IActionResult GetTransaction(string TransactionId)
        {
            return null;
        }

        [HttpPost("Post-Transaction")]
        public IActionResult PostTransaction(TransactionDto transaction)
        {
            List<TransactionDto> trans = new List<TransactionDto>();
            var result = "";

            return null;
        }
    }
}
