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
    public class ApprovalStatusController : ControllerBase
    {
        private readonly IApprovalStatusService _approvalStatusService;

        public ApprovalStatusController(IApprovalStatusService approvalStatusService)
        {
            _approvalStatusService = approvalStatusService;
        }

        /// <summary>
        /// Method for create an approval status record
        /// </summary>
        /// <param name="areaDto">Dto Approval Status parameter</param>
        /// <returns>ResponseDto from Approval Status Dto Object</returns>
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync([FromBody] ApprovalStatusDto approvalStatusDto)
        {
            try
            {
                var response = await _approvalStatusService.CreateAsync(approvalStatusDto, true);
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
        public async Task<IActionResult> UpdateAsync([FromBody] ApprovalStatusDto approvalStatusDto)
        {
            try
            {
                var response = await _approvalStatusService.UpdateAsync(approvalStatusDto);
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
        public async Task<IActionResult> DeleteAsync([FromBody] ApprovalStatusDto approvalStatusDto)
        {
            try
            {
                var response = await _approvalStatusService.DeleteAsync(approvalStatusDto.StatusId);
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
                var responseDto = new ResponseDTO<IEnumerable<ApprovalStatusDto>>();
                responseDto.Data = await _approvalStatusService.GetAllAsync();
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
                var responseDto = new ResponseDTO<ApprovalStatusDto>();
                responseDto.Data = _approvalStatusService.FindByIdAsync(id).Result.Data;
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
