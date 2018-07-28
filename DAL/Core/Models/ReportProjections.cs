using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Core.Models
{
    public class ReportProjection : Trackable
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int ProjectionDataId { get; set; }

        public Report Report { get; set; }
        public ProjectionData ProjectionData { get; set; }

        public ReportProjection()
        {

        }
    }
}
