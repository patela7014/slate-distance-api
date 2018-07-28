using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Resources
{
    public class ProjectDto
    {
        public ProjectDto()
        {
            Buildings = new HashSet<BuildingDto>();
        }

        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public ICollection<BuildingDto> Buildings { get; set; }
    }
}
