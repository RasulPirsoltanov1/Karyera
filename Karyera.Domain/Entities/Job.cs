using Karyera.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karyera.Domain.Entities
{
    /// <summary>
    /// İş elanının xüsusiyyətləri
    /// </summary>
    public class Job : BaseEntity
    {
        public Job()
        {
            Requirements = new List<string>();
        }
        public string Title { get; set; }
        public string? Company { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public DateTime? EndDate { get; set; }
        public List<string>? Requirements { get; set; }
        public string? ContactEmail { get; set; }
        public Category? Category { get; set; } = new Category();
        public int? CategoryId { get; set; }
        public bool? IsRemote { get; set; } = false;
        public decimal? Salary { get; set; }

        // Konstruktor
        public Job(string title, string company, string location, string description, DateTime endDate, List<string> requirements, string contactEmail, bool isRemote = false, decimal salary = 0)
        {
            Title = title;
            Company = company;
            Location = location;
            Description = description;
            EndDate = endDate;
            Requirements = requirements;
            ContactEmail = contactEmail;
            IsRemote = isRemote;
            Salary = salary;
        }
    }
}
