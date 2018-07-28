using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Resources
{
    public class ProjectionDataDto : UserDto
    {
        public int? Id { get; set; }
        // Building
        public string BuildingTitle { get; set; }
        public string Class { get; set; }
        public string Submarket { get; set; }
        public string BuildingAddress { get; set; }
        public string BuildingCity { get; set; }
        public string BuildingState { get; set; }
        public string BuildingCountry { get; set; }
        public string BuildingZip { get; set; }

        // Employee
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Designation { get; set; }
        public string EmployeeAddress { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeCountry { get; set; }
        public string EmployeeZip { get; set; }

        public float Duration { get; set; }
        public float Distance { get; set; }
    }
}
