using KiproshBirthdayCelebration.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.SecurityExtensions.Abstract;

namespace KiproshBirthdayCelebration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService Service;
        private readonly ILoggedInAssociateService LoggedInService;
        public GreetingController(
            IGreetingService service,
            ILoggedInAssociateService loggedInService)
        {
            Service = service;
            LoggedInService = loggedInService;
        }

        [HttpPost("sendgreetings")]
        public IActionResult GetCurrentBirthdays([FromBody] GreetingSaveViewModel model)
        {
            Service.SubmitWishes(LoggedInService.UserId, model);
            return Ok(model);
        }
    }
}
