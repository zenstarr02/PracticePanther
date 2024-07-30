using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Time
    {
        public DateTime Date {get; set;}

        public string? Narrative { get; set;}

        public decimal Hours { get; set;}

        public int Id { get; set;}
        public int ProjectId { get; set;}


        public Bill Bill { get; set;}

        public int EmployeeId { get; set; }

        public Time()
        {
            Id = 0;
        }

    }
}
