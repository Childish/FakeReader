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
        public IActionResult IDReader(int? includefaceimage, int? includeimagenormallight, string? callback, int? id)
        {
            if (string.IsNullOrEmpty(callback))
            {
                return BadRequest("Callback parameter is required.");
            }

            if (id.HasValue)
            {
                var scanData = _scanDataService.GetScanData(id.Value);
                if (scanData != null)
                {
                    return Jsonp(scanData, callback);
                }
                return Jsonp(new { status = "error", reason = "Scan not completed or invalid ID" }, callback);
            }
            else
            {
                var scanId = _scanDataService.CreateNewScanData();
                return Jsonp(new { id = scanId }, callback);
            }
        }

        private IActionResult Jsonp(object data, string callback)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(data);
            return Content($"{callback}({json});", "application/javascript");
        }
    }
}