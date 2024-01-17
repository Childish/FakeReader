using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Mime;

namespace FakeReader.Extensions
{
    public class JsonpResult : ContentResult
    {
        public JsonpResult(object data, string callback)
        {
            if (string.IsNullOrEmpty(callback))
            {
                throw new ArgumentNullException(nameof(callback));
            }

            Content = $"{callback}({JsonConvert.SerializeObject(data)});";
            ContentType = "application/javascript";
        }
    }

}
