using Differ.Application.Interfaces;
using Differ.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Differ.Services.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class DiffController : ControllerBase
    {
        private readonly IDiffAppService _diffAppService;

        public DiffController(IDiffAppService diffAppService)
        {
            _diffAppService = diffAppService;
        }

        [Route("left")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadLeftDiff([FromBody] LeftDataViewModel leftDiff)
        {
            if (!ModelState.IsValid) return BadRequest();

            Guid id = await _diffAppService.SaveLeftData(leftDiff);

            return Ok(id);
        }

        [Route("right")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UploadRightDiff([FromBody] RightDataViewModel rightDiff)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _diffAppService.SaveRightData(rightDiff);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CalculateDiff([FromBody] DiffRequestViewModel guid)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                DiffViewModel diff = await _diffAppService.CalculateDiff(guid.Id);
                return Ok(diff);
            }
            catch (Exception)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}