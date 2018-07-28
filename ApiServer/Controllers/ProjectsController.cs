using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.Resources;
using DAL.Services.Interfaces;
using ApiServer.Results;

namespace ApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IGenericService<ProjectDto> projectService;

        public ProjectsController(IGenericService<ProjectDto> projectService)
        {
            this.projectService = projectService;
        }

        // GET: api/Projects
        [HttpGet]
        public GenericResult<IEnumerable<ProjectDto>> GetProject()
        {
            var result = new GenericResult<IEnumerable<ProjectDto>>();

            try
            {
                result.Result = projectService.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
        
        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = new GenericResult<ProjectDto>();

            try
            {
                result.Result = await projectService.GetAsynById(id);
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

        // PUT: api/Projects/5
        [HttpPut("{id}")]
        public async Task<GenericResult<ProjectDto>> PutProject([FromRoute] int id, [FromBody] ProjectDto projectDto)
        {
            var result = new GenericResult<ProjectDto>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }

                if (id != projectDto.Id)
                {
                    result.Success = false;
                    throw new Exception("Invalid Request!");
                }
                var resultData = await projectService.UpdateAsyn(projectDto, id);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<GenericResult<ProjectDto>> PostProject([FromBody] ProjectDto projectDto)
        {
            var result = new GenericResult<ProjectDto>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }
                var resultData = await projectService.Create(projectDto);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // DELETE: api/Projects/5
        [HttpDelete("{id}")]
        public GenericResult<Boolean> DeleteProject([FromRoute] int id)
        {
            var result = new GenericResult<Boolean>();
            try
            {
                if (!ModelState.IsValid)
                {
                    result.Success = false;
                    throw new Exception("Please complete the required fields!");
                }
                var recordExists = ProjectExists(id).Result;
                if (recordExists == false)
                {
                    result.Success = false;
                    throw new Exception("Project not found!");
                }
                var resultData = projectService.Delete(id);
                result.Result = resultData;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        private async Task<bool> ProjectExists(int id)
        {
            var resultData = await projectService.GetAsynById(id);
            bool result = resultData == null ? false : true;
            return await Task.FromResult(result);
        }

    }
}