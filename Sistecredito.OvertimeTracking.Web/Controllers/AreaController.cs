using Microsoft.AspNetCore.Mvc;
using Sistecredito.OvertimeTracking.Application.Dtos.Authentication;
using Sistecredito.OvertimeTracking.Application.Dtos.Common;
using Sistecredito.OvertimeTracking.Application.Dtos.Core;
using Sistecredito.OvertimeTracking.Application.Helpers;
using Sistecredito.OvertimeTracking.Application.Interfaces.Authentication;
using Sistecredito.OvertimeTracking.Application.Interfaces.Core;
using Sistecredito.OvertimeTracking.Core.Exceptions;
using System.Net;

namespace Sistecredito.OvertimeTracking.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService; 
        }

        /// <summary>
        /// Method for create an Area record
        /// </summary>
        /// <param name="areaDto">Dto Area parameter</param>
        /// <returns>ResponseDto from dtoArea Object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.CreateAsync(areaDto,true);
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
        public async Task<IActionResult> UpdateAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.UpdateAsync(areaDto);
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
        public async Task<IActionResult> DeleteAsync([FromBody] AreaDto areaDto)
        {
            try
            {
                var response = await _areaService.DeleteAsync(areaDto.AreaId);
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
                var responseDto = new ResponseDTO<IEnumerable<AreaDto>>();
                responseDto.Data = await _areaService.GetAllAsync();
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
                var responseDto = new ResponseDTO<AreaDto>();
                responseDto.Data = _areaService.FindByIdAsync(id).Result.Data;
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
