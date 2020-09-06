using System;
using System.Collections.Generic;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using TestProject.WebAPI.Models;
using TestProject.WebAPI.Services;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TestProject.WebAPI.Controllers
{
    [RoutePrefix("api/ZipPay")]
    public class ZipController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("user/{id}")]
        [HttpGet()]
        public IHttpActionResult GetUser(Guid id)
        {
            if (id == Guid.Empty)
                return (IHttpActionResult)BadRequest();
            
            var user = UserService.GetUser(id);
            return (IHttpActionResult)Ok(user);            
        }

        [Route("users")]
        [HttpGet()]
        public IHttpActionResult GetAllUser()
        {
            var users = UserService.GetAllUsers();
            return (IHttpActionResult)Ok(users);
        }

        [Route("createUser")]
        [HttpPost]
        public IHttpActionResult CreateUser([FromBody]User user)
        {
            if (user == null)
                return (IHttpActionResult)BadRequest();

            UserService.CreateUser(user);
            return (IHttpActionResult)Ok();

        }

        [Route("createAccount/{userId}")]
        [HttpPost]
        public IHttpActionResult CreateAccount(Guid userId)
        {
            if (userId == Guid.Empty)
                return (IHttpActionResult)BadRequest();

            var message = AccountService.CreateAccount(userId);
            return (IHttpActionResult)Ok(message);

        }

        [Route("accounts")]
        [HttpGet()]
        public IHttpActionResult GetAllAccounts()
        {
            var accounts = AccountService.GetAllAccounts();
            return (IHttpActionResult)Ok(accounts);
        }

    }
}
