using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAP.Domain.Respositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillersController : ControllerBase
    {
        private ILogger<BillersController> _logger;
        private IBillerRepository _repository;
        public BillersController(IBillerRepository repository, ILogger<BillersController> logger)
        {
            this._logger = logger;
            this._repository = repository;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> ListBillersAsync()
        {
            var response = await _repository.FindAllAsync();
            try
            {
                if(response != null)
                {

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        // Post: Create Billers / Merchants
        [HttpPost("Create-Billers")]
        public async Task<ActionResult> CreateBillersAsync()
        {
            var response = await _repository.FindAllAsync();
            try
            {
                if (response != null)
                {

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        // GET: api/values
        [HttpGet("Get-Billers-Commision")]
        public async Task<ActionResult> ListCommision()
        {
            var response = await _repository.FindAllAsync();
            try
            {
                if (response != null)
                {

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }
    }
}
