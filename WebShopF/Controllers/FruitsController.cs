﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.ApplicationServices;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebShopF.Controllers
{
    [Route("api/[controller]")]
    public class FruitsController : ControllerBase
    {
        readonly IFruitService _fruitService;

        public FruitsController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        public ActionResult<IEnumerable<Fruit>> Get()
        {
            return Ok(_fruitService.GetFruit());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Fruit> Get(int id)
        {
            if (id < 1) return BadRequest("Id has to be higher than 1");
            return _fruitService.ReadFruit(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Fruit> Post([FromBody] Fruit fruit)
        {
            return _fruitService.CreateFruit(fruit);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Fruit> Put(int id, [FromBody] Fruit fruit)
        {
            if (id < 1 || id != fruit.Id)
            {
                return BadRequest("The ids must match");
            }

            _fruitService.UpdateFruit(fruit);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Fruit> Delete(int id)
        {
            Fruit fruit = _fruitService.DeleteFruit(id);
            if (fruit == null)
            {
                return BadRequest("Id must be the same as fruit Id");
            }
            return Ok("Fruit with id: " + id + " has been deleted");
        }
    }
}
