using Gladiator.Models;
using Gladiator.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gladiator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        InsuranceContext ctx = new InsuranceContext();
        //http://localhost:?/api/Customer/List
        [HttpGet]
        [Route("List")]
        public IActionResult GetCustomer()
        {
            var data = ctx.Customers.ToList();
            return Ok(data);
        }
        //http://localhost:?/api/Customer/List/{CustomerId}
        [HttpGet]
        [Route("List/{id}")]
        public IActionResult GetCustomer(long? id)
        {
            if (id == null) return BadRequest("CustomerId = {id} Not found");
            var data = ctx.Customers.Find(id);
            if (data == null)
            {
                return NotFound("Data For ID={id} Not found");
            }
            return Ok(data);
        }
        //http://localhost:?/api/Customer/AddCustomer
        [HttpPost]
        [Route("AddCustomer")]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ctx.Customers.Add(customer);
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
        //http://localhost:?/api/Customer/EditCustomer/{CustomerId}
        [HttpPut]
        [Route("EditCustomer/{id}")]
        public IActionResult Put(long id, [FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var dp = ctx.Customers.Find(id);
                dp.CustomerName = customer.CustomerName;
                dp.Email = customer.Email;
                dp.Dob = customer.Dob;
                dp.ContactNo = customer.ContactNo;
                dp.Address = customer.Address;
                dp.State = customer.State;
                dp.Country = customer.Country;
                dp.Pincode = customer.Pincode;
                dp.Password = customer.Password;
                ctx.SaveChanges();
                return Ok();
            }
            return BadRequest();
        }
        //http://localhost:?/api/Customer/RemoveCustomer/{CustomerId}
        [HttpDelete]
        [Route("RemoveCustomer/{id}")]
        public IActionResult Delete(long? id)
        {
            if (id == null) return BadRequest("Customer Id = {id} Not found");
            var data = ctx.Customers.Find(id);
            if (data == null)
            {
                return NotFound("Data For Customer ID={id} Not found");
            }
            ctx.Customers.Remove(data);
            ctx.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult CustomerUser([FromBody] Customer cust)
        {
            //ctx.Database.ExecuteSqlRaw("register {0},{1},username,pwd");
            ctx.Database.ExecuteSqlInterpolated($"register {cust.CustomerId},{cust.CustomerName},{cust.Email},{cust.Dob},{cust.ContactNo},{cust.Address},{cust.State},{cust.Country},{cust.Pincode},{cust.Password}");
            return Ok();
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromQuery] string Email, string Password)
        {
            var data = ctx.Login_VM.FromSqlRaw<Login_VM>($"login {Email},{Password}").AsEnumerable().FirstOrDefault();
            if (data == null)
            {
                return NotFound("Invalid Email and password");
            }
            return Ok(data);
        }
    }
}
