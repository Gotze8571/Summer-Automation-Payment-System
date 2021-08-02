using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SAP_BusinessLogic.DTOs;
using SAP_BusinessLogic.Models;
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
        private readonly IUtil util;
        public AccountController()
        {

        }
        
        // Create account endpoint.
        [HttpPost]
        //[ValidateModel]
        [Route("CreateSAPAccount")]
        public async Task<IActionResult> CreateSAPAccount(CreateAccountDto dto)
        {
            try
            {
                var error = new ApiResponse() { Code = "400", Description = "One or more input field not correctly passed/empty" };
                if (!ModelState.IsValid)
                    return BadRequest(error);
                var response = await _accountService.CreateSAPAccount(dto);
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        // Insert into account endpoint.

        // Update account endpoint.

        // Get account endpoints.

        // Delete account endpoint.
        
    }
}
