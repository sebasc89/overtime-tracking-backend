using Microsoft.AspNetCore.Mvc;
using Sistecredito.OvertimeTracking.Application.Dtos.Common;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Application.Helpers;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using System.Net;

namespace Sistecredito.OvertimeTracking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// Method for create an Position record
        /// </summary>
        /// <param name="areaDto">Dto Position parameter</param>
        /// <returns>ResponseDto from Position Dto Object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.CreateAsync(positionDto, true);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.UpdateAsync(positionDto);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] PositionDto positionDto)
        {
            try
            {
                var response = await _positionService.DeleteAsync(positionDto.PositionId);
                return Ok(response);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.NotFound, ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var responseDto = new ResponseDTO<IEnumerable<PositionDto>>();
                responseDto.Data = await _positionService.GetAllAsync();
                responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }

        [HttpGet]
        [Route("getById/{id:int}")]
        public async Task<IActionResult> GFindByIdAsync(int id)
        {
            try
            {
                var responseDto = new ResponseDTO<PositionDto>();
                responseDto.Data = _positionService.FindByIdAsync(id).Result.Data;
                responseDto.Header.ReponseCode = (int)HttpStatusCode.OK;
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseExtension.AsResponseDTO((int)HttpStatusCode.InternalServerError, (int)HttpStatusCode.InternalServerError, "Ocurrió un error en el servidor"));
            }
        }
    }
}
