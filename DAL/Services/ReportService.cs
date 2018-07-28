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
    public class ReportService : IGenericService<ReportDto>
    {
        private readonly IUnitOfWork uow;

        public ReportService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<ReportDto> Create(ReportDto item)
        {
            var report = item.MapTo<Report>();
            try
            {
                uow.ReportRepository.Add(report);
                await uow.Commit();
            }
            catch
            {
                uow.RejectChanges();
                throw;
            }
            return await GetAsynById(report.Id);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ReportDto> GetAll()
        {
            var reports = uow.ReportRepository.GetAll();
            return reports.EnumerableTo<ReportDto>();
        }

        public Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ReportDto> GetAsynById(int id)
        {
            var report = await uow.ReportRepository.GetAsync(m => m.Id == id, x => x.Projections);
            var reportDto = report.MapTo<ReportDto>();
            return await Task.FromResult<ReportDto>(reportDto);
        }

        public ReportDto GetById(int id)
        {

            throw new NotImplementedException();
        }

        public bool Update(ReportDto item)
        {
            throw new NotImplementedException();
        }

        public Task<ReportDto> UpdateAsyn(ReportDto item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
