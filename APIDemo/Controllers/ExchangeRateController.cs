using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.Data;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDemo
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRateController : ControllerBase
    {

        // GET: api/<ExchangeRateController>
        [HttpGet]
        public IEnumerable<ExchangeRate> Get([FromQuery] string BaseCurrency)
        {
            if (BaseCurrency != null && BaseCurrency.ToLower() == "usd")
                return Singleton.Instance.ExchangeRates.Select(x => new ExchangeRate { Date = x.Date, GTQ = x.GTQ / x.USD, USD = 1 });

            return Singleton.Instance.ExchangeRates;
        }

        // GET api/<ExchangeRateController>/5
        [HttpGet("{date}")]
        public ExchangeRate GetByDate([FromRoute] string date)
        {
            return Singleton.Instance.ExchangeRates.Where(x => x.Date == Convert.ToDateTime(date)).FirstOrDefault<ExchangeRate>();
        }

        // POST api/<ExchangeRateController>
        [HttpPost]
        public ActionResult Post([FromBody] ExchangeRate newValue)
        {
            try
            {
                Singleton.Instance.ExchangeRates.Add(newValue);
                return Created("",newValue);
            }
            catch (Exception ex)
            {
                return BadRequest(); 
            }
            
        }

        // PUT api/<ExchangeRateController>/5
        [HttpPut("{date}")]
        public ActionResult Put(string date, [FromBody] ExchangeRate value)
        {
            var result = Singleton.Instance.ExchangeRates.Where(x => x.Date == Convert.ToDateTime(date)).First<ExchangeRate>();
            if (result == null) return NotFound();

            Singleton.Instance.ExchangeRates.RemoveAll(x => x.Date == Convert.ToDateTime(date));
            Singleton.Instance.ExchangeRates.Add(value);
            return NoContent();
        }

        // DELETE api/<ExchangeRateController>/5
        [HttpDelete("{date}")]
        public ActionResult Delete(string date)
        {
            var result = Singleton.Instance.ExchangeRates.Where(x => x.Date == Convert.ToDateTime(date)).First<ExchangeRate>();
            if (result == null) return NotFound();

            Singleton.Instance.ExchangeRates.RemoveAll(x => x.Date == Convert.ToDateTime(date));
            return NoContent();
        }
    }
}
