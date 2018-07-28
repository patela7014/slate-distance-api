using DAL.Core;
using DAL.Core.Models;
using DAL.Extensions;
using DAL.Resources;
using DAL.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class ProjectService : IGenericService<ProjectDto>
    {
        private readonly IUnitOfWork uow;

        public ProjectService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ProjectDto> Create(ProjectDto item)
        {
            var project = item.MapTo<Project>();
            try
            {
                uow.ProjectRepository.Add(project);
                await uow.Commit();
            }
            catch
            {
                uow.RejectChanges();
                throw;
            }
            return await GetAsynById(project.Id);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDto> GetAll()
        {
            var projects = uow.ProjectRepository.GetAll(p => p.CreatedByUser);
            return projects.EnumerableTo<ProjectDto>();
        }

        public Task<IEnumerable<ProjectDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectDto> GetAsynById(int id)
        {
            var project = await uow.ProjectRepository.GetAsync(m => m.Id == id, x=> x.Buildings);
            var projectDto = project.MapTo<ProjectDto>();
            return await Task.FromResult<ProjectDto>(projectDto);
        }

        public ProjectDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProjectDto item)
        {
            throw new NotImplementedException();
        }

        public async Task<ProjectDto> UpdateAsyn(ProjectDto item, int id)
        {
            var project = item.MapTo<Project>();
            project.Id = id;
            try
            {
                await uow.ProjectRepository.UpdateAsync(project, id);
                await uow.Commit();
            }
            catch
            {
                uow.RejectChanges();
                throw;
            }
            return await GetAsynById(project.Id);
        }
    }
}
