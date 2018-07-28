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
    public class ReportProjectionService : IGenericService<ReportProjectionDto>
    {
        private readonly IUnitOfWork uow;

        public ReportProjectionService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ReportProjectionDto> Create(ReportProjectionDto item)
        {
            var reportProjection = item.MapTo<ReportProjection>();
            try
            {
                uow.ReportProjectionRepository.Add(reportProjection);
                await uow.Commit();
            }
            catch
            {
                uow.RejectChanges();
                throw;
            }
            return await GetAsynById(reportProjection.Id);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportProjectionDto> GetAll()
        {
            var reportProjections = uow.ReportProjectionRepository.GetAll();
            return reportProjections.EnumerableTo<ReportProjectionDto>();
        }

        public Task<IEnumerable<ReportProjectionDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReportProjectionDto> GetAsynById(int id)
        {
            var reportProjection = await uow.ReportProjectionRepository.GetAsync(m => m.Id == id);
            var reportProjectionDto = reportProjection.MapTo<ReportProjectionDto>();
            return await Task.FromResult<ReportProjectionDto>(reportProjectionDto);
        }

        public ReportProjectionDto GetById(int id)
        {

            throw new NotImplementedException();
        }

        public bool Update(ReportProjectionDto item)
        {
            throw new NotImplementedException();
        }

        public Task<ReportProjectionDto> UpdateAsyn(ReportProjectionDto item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
