using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Helpers;
using SAP_BusinessLogic.Models;
using SAP_BusinessLogic.Services.Concrete;
using SAP_BusinessLogic.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private ILogger<BillersController> logger;
        private readonly IUtil _util;
        private readonly IAccountSetupService _accountCreationService;
       
        public AccountController(IAccountSetupService accountCreationService, IUtil util)
        {
            _accountCreationService = accountCreationService;
            _util = util;
        }
        
        // Create SAP account endpoint.
        [HttpPost]
        //[ValidateModel]
        [Route("CreateSAPAccount")]
        public async Task<IActionResult> CreateSAP_Account(AccountCreationDto dto)
        {
            try
            {
                var error = new ApiResponse() { Code = "400", Description = "One or more input field not correctly passed/empty" };
                if (!ModelState.IsValid)
                    return BadRequest(error);
                var response = await _accountCreationService.AccountCreation(dto);

                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse() { 
                    Code = "96",
                    Description = "System malfunction"

                });
            }
        }

        // Insert into SAP account endpoint.
        [HttpPost]
        //[ValidateModel]
        [Route("Deposit-Account")]
        public async Task<IActionResult> DepositSAP_Account(AccountCreationDto dto)
        {
            try
            {
                var error = new ApiResponse() { Code = "400", Description = "One or more input field not correctly passed/empty" };
                if (!ModelState.IsValid)
                    return BadRequest(error);
                var response = await _accountCreationService.AccountCreation(dto);

                var statusCode = _util.GetStatusCode(response.Code);

                return StatusCode(statusCode, response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse()
                {
                    Code = "96",
                    Description = "System malfunction"

                });
            }
        }

        // Update SAP account endpoint.
        // PUT
        [HttpPut]
        [Route("Update-Account-Details")]
        public async Task<IActionResult> UpdateSAP_Account(AccountCreationDto update)
        {
            return null;
        }

        // Get SAP account endpoints.
        [HttpGet]
        [Route("Get-Account-Details")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<MySapAcc>))]
        public async Task<ActionResult> GetAccount()
        {
            try
            {
                string responseCode = "";
                var error = new ApiResponse() { Code = "400", Description = "One or more input field not correctly passwed/empty" };
                if (!ModelState.IsValid)
                    return BadRequest(error);
                var response = await _accountCreationService.GetAccountCreation();

                var statusCode = _util.GetStatusCode(responseCode);

                return StatusCode(statusCode, response);

                //var response = await _
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return null;
        }

        // Delete SAP account endpoint.
        
    }
}
