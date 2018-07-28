using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Core.Models
{
    public class Project : Trackable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Building> Buildings { get; set; }

        public Project()
        {
            Buildings = new HashSet<Building>();
        }
    }
}
