using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABS_Insurance.Data.Dto;
using ABS_Insurance.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABS_Insurance.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        
        private readonly ICalculatePremuimService _calculatePremiumService;

        public TransactionController(ICalculatePremuimService calculatePremiumService)
        {
            _calculatePremiumService = calculatePremiumService;
        }
        // GET: api/Transaction
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        // GET: api/Transaction/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/Transaction
        [HttpPost("premium")]
        public IActionResult CalculatePremium ([FromBody] CalPremiumDto calPolicy)
        {
            var premium = _calculatePremiumService.CalculatePremium(calPolicy.MarketValue, calPolicy.PolicyId);
            return Ok(premium);
        }

        // PUT: api/Transaction/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // DELETE: api/Transaction/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}