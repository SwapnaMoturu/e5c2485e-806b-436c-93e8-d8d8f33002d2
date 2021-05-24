using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LIS_Api.Controllers
{
    public class Response
    {
        public string Output { get; set; }
    }
    public class LISController : Controller
    {
        private readonly ILogger<LISController> _logger;

        public LISController(ILogger<LISController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string GetLIS([FromBody] string inputValues)
        {
            Response resp = new Response();
            LIS objLIS = new LIS();
            Regex rgx = new Regex(@"^[\d\s]+$");
            if (!String.IsNullOrEmpty(inputValues) && rgx.IsMatch(inputValues))
            {
                int[] line = Array.ConvertAll<string, int>(inputValues.ToString().Split(' '), Convert.ToInt32);
                if (line != null)
                {
                    objLIS.Solve(line);
                    if (objLIS.output != null)
                        resp.Output = String.Join(" ", objLIS.output);
                }
            }
            return resp.Output;
        }
    }
}
