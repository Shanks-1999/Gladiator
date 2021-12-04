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
    public class ClaimController : ControllerBase
    {
        InsuranceContext ctx = new InsuranceContext();
        //http://localhost:?/api/Claim/List
        [HttpGet]
        [Route("List")]
        public IActionResult GetClaim()
        {
            var data = ctx.Claims.ToList();
            return Ok(data);
        }
        //http://localhost:?/api/Claim/List/{ClaimId}
        [HttpGet]
        [Route("List/{id}")]
        public IActionResult GetClaims(long? id)
        {
            if (id == null) return BadRequest("Policy no = {id} Not found");
            var data = ctx.Claims.Find(id);
            if (data == null)
            {
                return NotFound("Data For ID={id} Not found");
            }
            return Ok(data);
        }
        //http://localhost:?/api/Claim/AddClaim
        [HttpPost]
        [Route("AddClaim")]
        public IActionResult Post([FromBody] Claim claim)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Claims.Add(claim);
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
        /*[HttpPut]
        [Route("EditClaims/{id}")]
        public IActionResult Put(long id, [FromBody] Claim claim)
        {
            if (ModelState.IsValid)
            {
                var dp = ctx.Claims.Find(id);
                ctx.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }*/
        //http://localhost:?/api/Claim/RemoveClaim/{ClaimId}
        [HttpDelete]
        [Route("RemoveClaim/{id}")]
        public IActionResult Delete(long? id)
        {
            if (id == null) return BadRequest("Claim No = {id} Not found");
            var data = ctx.Claims.Find(id);
            if (data == null)
            {
                return NotFound("Data For ID={id} Not found");
            }
            ctx.Claims.Remove(data);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
