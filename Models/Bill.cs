using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Bill
    {
        public Bill() { }

        public Bill(int projId)
        {
            TotalAmount = 0;

            List<Time> times= new(TimeService.Current.Times.Where((c)=>c.ProjectId == projId));
            
            for(int i = 0; i < times.Count; i++)
            {
                var e = EmployeeService.Current.Get(times[i].EmployeeId).Rate;
                TotalAmount += (double)times[i].Hours * e;
            }
            
            DueDate = DateTime.Now.AddDays(30);
        }

        public Bill Add(Bill bill)
        {
            TotalAmount += bill.TotalAmount;
            DueDate = DueDate.AddDays(10);

            return this;

        }

        public int Id { get; set; }

        public int ClientId { get; set; }
        public int ProjectId { get; set; }

        public int TimeId { get; set; }

        public double TotalAmount { get; set; }

        public DateTime DueDate { get; set; }


    }
}
