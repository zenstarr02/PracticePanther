using PP.Library.Models;
using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class TimeService
    {
        private int LastId
        {
            get { return Times.Any() ? Times.Select(c => c.Id).Max() : 1; }
        }


       
        private static TimeService? instance;
        private static object _lock = new object();
        public static TimeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new TimeService();
                    }
                    return instance;
                }
            }
        }

        private List<Time> times;
        public List<Time> Times
        {
            get
            {
                return times;
            }
        }
        public TimeService()
        {
            times = new List<Time>() { new Time() { Id = 1, EmployeeId = 1, ProjectId = 1 , Narrative = "TEST TIME", Hours = 1.25M},
                                        new Time() { Id = 2, EmployeeId = 2, ProjectId = 2 , Narrative = "TEST TIME2" ,Hours = 1.5M},
                                        new Time() { Id = 3, EmployeeId = 3, ProjectId = 3 , Narrative = "TEST TIME3", Hours = 2M}};
        }

        public Time? Get(int id)
        {
            return times.FirstOrDefault(p => p.Id == id);

        }

        public void AddOrUpdate(Time c)
        {


            var isAdd = false;
            if (c.Id == 0)
            {
                isAdd = true;
                c.Id = LastId + 1;
            }

            if (isAdd)
            {
               Times.Add(c);
            }
        }

        public void Delete(int id)
        {
            if(id != 0 && Get(id) != null)
            {
                Times.Remove(Get(id));

            }
        }


    }
}
