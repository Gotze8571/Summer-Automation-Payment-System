using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SAP_BusinessLogic.Models;
using SAP_BusinessLogic.Models.API;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAP_BusinessLogic.Extensions
{
    public class LogHelper
    {
        public static string RequestPayload = "";

        public static async void EnrichFromRequest(IDiagnosticContext diagnosticContext, HttpContext httpContext)
        {
            var request = httpContext.Request;

            diagnosticContext.Set("RequestBody", RequestPayload);

            string reponseBodyPayload = await ReadResponseBody(httpContext.Response);
            diagnosticContext.Set("ResponseBody", reponseBodyPayload);
            ApiResponse responseBody = (ApiResponse)JsonConvert.DeserializeObject(reponseBodyPayload, typeof(ApiResponse));

            if (responseBody != null)
            {
                diagnosticContext.Set("ResponseCode", responseBody.Code);
                diagnosticContext.Set("Description", responseBody.Description);
            }

            // Set all the common properties available to every request
            diagnosticContext.Set("Host", request.Host);
            diagnosticContext.Set("Protocol", request.Protocol);
            diagnosticContext.Set("Scheme", request.Scheme);

            // Only set it if available. You're not sending sensitive data in a querystring right?!
            if (request.QueryString.HasValue)
            {
                diagnosticContext.Set("QueryString", request.QueryString.Value);
            }

            // Set the content-type of the Response at the point
            diagnosticContext.Set("ContentType", httpContext.Response.ContentType);

            // Retrieve the IEndpointFeature selected for the request
            var endpoint = httpContext.GetEndpoint();
            if (endpoint is object) // endpoint != null;
            {
                diagnosticContext.Set("EndpointName", endpoint.DisplayName);
            }
            var clientId = httpContext.Request.Headers["client_id"];

            diagnosticContext.Set("ClientId", clientId);

            var productIdRes = JsonConvert.DeserializeObject<GetProductId>(RequestPayload);

            if (productIdRes != null && !string.IsNullOrWhiteSpace(productIdRes.productId))
            {
                diagnosticContext.Set("productId", productIdRes.productId);
            }
            else
            {
                string headerProductId = string.Empty;

                var prodKey = httpContext.Request.Headers.Keys.FirstOrDefault(n => n.ToLower().Equals("product_id"));
                if (!string.IsNullOrWhiteSpace(prodKey))
                {
                    diagnosticContext.Set("productId", productIdRes.productId);
                }
                else
                {
                    string correlationId = string.Empty;

                    var key = context.Request.Headers.Keys.FirstOrDefault(p => p.ToLower().Equals("x-correlationId"));
                    if (!string.IsNullOrWhiteSpace(key))
                    {
                        correlationId = context.Request.Headers[key];
                    }
                    else
                    {
                        correlationId = Guid.NewGuid().ToString();
                    }
                    diagnosticContext.Set("CorrelationId", correlationId);
                    diagnosticContext.Set("ClientId", context.Connection.RemoteIpAddress.ToString());
                    context.Response.Headers.Append("x-correlation-id", correlationId);
                }
            }
        }

        private static async Task<string> ReadResponseBody(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return $"{responseBody}";
        }
    }
}
