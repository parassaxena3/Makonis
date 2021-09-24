using Makonis.Common;
using Makonis.Common.Models;
using Makonis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Makonis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormController : ControllerBase
    {

        private readonly ILogger<FormController> _logger;
        private readonly IFileSaverService _fileSaverService;
        public FormController(ILogger<FormController> logger, IFileSaverService fileSaverService)
        {
            _logger = logger;
            _fileSaverService = fileSaverService;
        }


        [Route("save/file")]
        [HttpPost]
        public ActionResult SaveToFile([FromBody] User user)
        {
            if (!IsValidUser(user))
                return BadRequest(new ResponseModel(false, "Invalid input."));

            try
            {
                var path = _fileSaverService.SaveUserDetailsToFile(user);
                return Ok(new ResponseModel(true, "Saved successfully at " + path));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving to file");
                return StatusCode(500);
            }

        }
        private bool IsValidUser(User user)
        {
            if (user != null && !string.IsNullOrEmpty(user.FirstName) && !string.IsNullOrEmpty(user.LastName))
                return true;

            return false;
        }
    }
}
