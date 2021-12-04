using Gladiator.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        InsuranceContext ctx = new InsuranceContext();
        //http://localhost:?/api/Policy/List
        [HttpGet]
        [Route("List")]
        public IActionResult GetPolicies()
        {
            var data = ctx.Policies.ToList();
            return Ok(data);
        }
        //http://localhost:?/api/Policy/List/{PolicyNo}
        [HttpGet]
        [Route("List/{id}")]
        public IActionResult GetPolicies(long? id)
        {
            if (id == null) return BadRequest("Policy no  = {id} Not found");
            var data = ctx.Policies.Find(id);
            if (data == null)
            {
                return NotFound("Data For ID={id} Not found");
            }
            return Ok(data);
        }
        //http://localhost:?/api/Policy/AddPolicy
        [HttpPost]
        [Route("AddPolicy")]
        public IActionResult Post([FromBody] Policy policy)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Policies.Add(policy);
                    ctx.SaveChanges();
                    return Ok();
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return Ok();
        }
        //http://localhost:?/api/Policy/EditPolicy/{PolicyNo}
        [HttpPut]
        [Route("EditPolicy/{id}")]
        public IActionResult Put(long id, [FromBody] Policy policy)
        {
            if (ModelState.IsValid)
            {
                var dp = ctx.Policies.Find(id);
                dp.PlanType = policy.PlanType;
                dp.Duration = policy.Duration;
                dp.TransactionId = policy.TransactionId;
                dp.TransactionDate = policy.TransactionDate;
                ctx.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        //http://localhost:?/api/Policy/RemovePolicy/{PolicyNo}
        [HttpDelete]
        [Route("RemovePolicy/{id}")]
        public IActionResult Delete(long? id)
        {
            if (id == null) return BadRequest("Policy No = {id} Not found");
            var data = ctx.Policies.Find(id);
            if (data == null)
            {
                return NotFound("Data For ID={id} Not found");
            }
            ctx.Policies.Remove(data);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
