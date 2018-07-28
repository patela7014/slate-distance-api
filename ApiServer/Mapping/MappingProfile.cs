using AutoMapper;
using DAL.Core.Models;
using DAL.Resources;
using System.Linq;

namespace ApiServer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to API Resouce with Reverse
            CreateMap<UserRegistration, User>()
                .ReverseMap();

            CreateMap<UsersListResource, User>()
                .ReverseMap();

            CreateMap<BuildingDto, Building>()
                .ReverseMap();

            CreateMap<EmployeeDto, Employee>()
                .ReverseMap();

            CreateMap<Project, ProjectDto>()
                .ForMember(pd => pd.CreatedBy, opt => opt.MapFrom(p => string.Format($"{p.CreatedByUser.FirstName} {p.CreatedByUser.LastName}") ));

            CreateMap<ProjectDto, Project>()
                .ForMember(p => p.Id, pd => pd.Ignore())
                .ForMember(p => p.Buildings, pd => pd.Ignore())
                .AfterMap((pd, p) =>
                {
                    var addedBuildings = pd.Buildings.Select(g => g);
                    foreach (var b in addedBuildings)
                    {
                        var building = new Building
                        {
                            ProjectId = pd.Id == 0 ? 0 : (int)pd.Id,
                            Title = b.Title,
                            City = b.City,
                            Address = b.Address,
                            Class = b.Class,
                            Country = b.Country,
                            IsActive = true,
                            State = b.State,
                            Submarket = b.Submarket,
                            Zip = b.Zip
                        };

                        p.Buildings.Add(building);
                    }

                });

            CreateMap<ProjectionDataDto, ProjectionData>()
                .ForMember(p => p.Id, opt => opt.MapFrom(pd => pd.Id == 0 ? 0 : (int)pd.Id))
                .ForMember(p => p.CreatedByUser, opt => opt.Ignore())
                .ForMember(p => p.LastUpdatedBy, opt => opt.MapFrom(pd => pd.UserId))
                .AfterMap((pd, p) =>
                {
                    if(pd.UserId == null)
                    {
                        p.CreatedBy = pd.UserId;
                    }
                })
                .ReverseMap();

            CreateMap<ReportDto, Report>()
                .ForMember(r => r.Id, rd => rd.Ignore())
                .ForMember(r => r.Projections, rd => rd.Ignore())
                .AfterMap((rd, r) =>
                {
                    var addedProjections = rd.Projections.Select(g => g);
                    foreach (var p in addedProjections)
                    {
                        var projectionData = new ProjectionData
                        {
                            BuildingAddress = p.BuildingAddress,
                            BuildingCity = p.BuildingCity,
                            BuildingCountry = p.BuildingCountry,
                            BuildingState = p.BuildingState,
                            BuildingTitle = p.BuildingTitle,
                            BuildingZip = p.BuildingZip,
                            Class = p.Class,
                            Designation = p.Designation,
                            Distance = p.Distance,
                            Duration = p.Duration,
                            Email = p.Email,
                            EmployeeAddress = p.EmployeeAddress,
                            EmployeeCity = p.EmployeeCity,
                            EmployeeState = p.EmployeeState,
                            EmployeeCountry = p.EmployeeCountry,
                            EmployeeZip = p.EmployeeZip,
                            FirstName = p.FirstName,
                            LastName = p.LastName,
                            Phone = p.Phone,
                            Submarket = p.Submarket
                        };

                        r.Projections.Add(projectionData);

                    }

                });

        }
    }
}
