using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Core.Models;
using DAL.Persistence;
using DAL.Resources;
using ApiServer.Results;
using DAL.Services.Interfaces;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IGenericService<ReportDto> reportService;

        public ReportsController(IGenericService<ReportDto> reportService)
        {
            this.reportService = reportService;
        }

        // GET: api/Reports
        [HttpGet]
        public GenericResult<IEnumerable<ReportDto>> GetReport()
        {
            var result = new GenericResult<IEnumerable<ReportDto>>();

            try
            {
                result.Result = reportService.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReport([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new GenericResult<ReportDto>();

            try
            {
                result.Result = await reportService.GetAsynById(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            if (result.Result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Reports/5
        [HttpPut("{id}")]
        public async Task<GenericResult<ReportDto>> PutReport([FromRoute] int id, [FromBody] ReportDto reportDto)
        {
            var result = new GenericResult<ReportDto>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }

                if (id != reportDto.Id)
                {
                    result.Success = false;
                    throw new Exception("Invalid Request!");
                }
                var resultData = await reportService.UpdateAsyn(reportDto, id);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST: api/Reports
        [HttpPost]
        public async Task<GenericResult<ReportDto>> PostReport([FromBody] ReportDto reportDto)
        {
            var result = new GenericResult<ReportDto>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }
                var resultData = await reportService.Create(reportDto);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
        
        // DELETE: api/Reports/5
        [HttpDelete("{id}")]
        public GenericResult<Boolean> DeleteReport([FromRoute] int id)
        {
            var result = new GenericResult<Boolean>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }
                var recordExists = ReportExists(id).Result;
                if(recordExists == false)
                {
                    result.Success = false;
                    throw new Exception("Report not found!");
                }
                var resultData = reportService.Delete(id);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }


        private async Task<bool> ReportExists(int id)
        {
            var resultData = await reportService.GetAsynById(id);
            bool result = resultData == null ? false : true;
            return await Task.FromResult(result);
        }
    }
}