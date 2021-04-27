using KiproshBirthdayCelebration.DataAccess;
using KiproshBirthdayCelebration.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entities;
using System;
using KiproshBirthdayCelebration.BuisnessLogic.Abstract;

namespace KiproshBirthdayCelebration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        private readonly IAssociateService Service;
        public AssociateController(IAssociateService service)
        {
            Service = service;
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet("getsystemassociates")]
        public IActionResult GetAllAssociates()
        {
            return Ok(Service.GetAllAssociates());
        }

        [HttpGet("getassociatebyid")]
        public IActionResult GetById([FromQuery] int id)
        {
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Unauthorized();

            var assoicate = Service.GetAssociateById(id);
            if (assoicate == null)
                return NotFound();

            return Ok(assoicate);
        }

        [HttpGet("getcurrentassociate")]
        public IActionResult GetCurrentUser()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var currentAssociateId = int.Parse(User.Identity.Name);
                return Ok(Service.GetAssociateById(currentAssociateId));
            }
            else
            {
                return Unauthorized();
            }
        }


    }
}
