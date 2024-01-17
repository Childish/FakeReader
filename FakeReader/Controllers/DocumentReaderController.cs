using FakeReader.Dto;
using FakeReader.Extensions;
using FakeReader.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeReader.Controllers
{
    [ApiController]
    [Route("IDReader")]
    public class DocumentReaderController : ControllerBase
    {
        private readonly IScanDataService _scanDataService;

        public DocumentReaderController(IScanDataService scanDataService)
        {
            _scanDataService = scanDataService;
        }

        [HttpGet]
        public IActionResult IDReader(int? includefaceimage, int? includeimagenormallight, int? id)
        {
            // Extract callback parameters from the query
            var callbackParameters = HttpContext.Request.Query["callback"];
            string callbackName = null;

            if (callbackParameters.Count > 0)
            {
                callbackName = callbackParameters.Last(); // Prioritize the jQuery-generated callback
            }

            if (string.IsNullOrEmpty(callbackName))
            {
                return BadRequest("Callback parameter is required.");
            }

            if (id.HasValue)
            {
                var scanData = _scanDataService.GetScanData(id.Value);
                if (scanData != null)
                {
                    return Jsonp(scanData, callbackName);
                }
                return Jsonp(new { status = "error", reason = "Scan not completed or invalid ID" }, callbackName);
            }
            else
            {
                var scanId = _scanDataService.CreateNewScanData();
                return Jsonp(new { id = scanId }, callbackName);
            }
        }

        private IActionResult Jsonp(object data, string callback)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            return Content($"{callback}({json});", "application/javascript");
        }
    }
}