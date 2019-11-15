using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("[controller]")]
    public class SellerController : Controller
    {
        
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sellerService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_sellerService.Get(id));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Seller model)
        {
            return Ok(_sellerService.Add(model));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]Seller model)
        {
            return Ok(_sellerService.Update(model));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_sellerService.Delete(id));
        }
    }
}
