using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Resources
{
    public class ReportProjectionDto
    {
        public int? Id { get; set; }
        public int ReportId { get; set; }
        public int ProjectionDataId { get; set; }
    }
}
