using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week4.Academy.Test.Core.Models;
using Week4.Academy.Test.Core.Repositories;

namespace Week4.Academy.Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IBusinessLayer mainBL;

        public OrdersController(IBusinessLayer mainBL)
        {
            this.mainBL = mainBL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = mainBL.FetchOrder();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetByIDOrder(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID");
            try
            {
                var result = mainBL.GetByIDOrder(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation");
            }
        }

        [HttpPost]
        public IActionResult Post(Order newOrder)
        {
            try
            {
                if (newOrder == null)
                    return BadRequest("Order not valid");
                bool result = mainBL.AddOrder(newOrder);
                if (!result)
                    return BadRequest("Could not add order");
                return CreatedAtAction("Post", newOrder);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Order updatedOrder)
        {
            try
            {
                if (id != updatedOrder.ID_Order)
                    return BadRequest("IDs not matching");
                bool result = mainBL.UpdateOrder(updatedOrder);
                if (!result)
                    return BadRequest("Could not update order");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid ID");
                bool result = mainBL.DeleteByIdOrder(id);
                if (!result)
                    return BadRequest("Could not delete order");
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "Error executing operation");
            }
        }
    }
}
