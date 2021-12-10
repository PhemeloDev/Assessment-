using AssesmentTest.Models;
using AssesmentWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ICoinJar _coinJar;

        public MainController(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        [HttpPost("AddCoin")]
        public ActionResult<ResponseObj> AddCoin(CoinDTO coin)
        {
            var response = new ResponseObj();


            _coinJar.AddCoin(coin);

            response.Status = true;

            return Ok(response);

        }

        [HttpGet("GetTotalAmount")]
        public ActionResult GetTotalAmount()
        {
            var response = new ResponseObj();

            var totalAmount = _coinJar.GetTotalAmount();

            response.Status = true;

            return Ok(response);

        }

        [HttpDelete("Reset")]
        public ActionResult Reset()
        {
            var response = new ResponseObj();
            response.Status = true;
            _coinJar.Reset();
            return Ok(response);

        }
    }
}
