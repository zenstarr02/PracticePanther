using PP.Library.Models;
using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class EmployeeService
    {

        private int LastId
        {
            get { return Employees.Any() ? Employees.Select(c => c.Id).Max() : 1; }
        }

        private static EmployeeService? instance;
        private static object _lock = new object();
        public static EmployeeService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeService();
                    }
                    return instance;
                }
            }
        }

        private List<Employee> employees;

        public List<Employee> Employees { get { return employees; } }

        public EmployeeService() 
        { 
            employees = new List<Employee>() { new Employee(){ Id = 1, Name = "Joe", Rate = 50 },
                                                new Employee(){ Id = 2, Name = "David", Rate = 50 },
                                                new Employee(){ Id = 3, Name = "TEST EMPLOYEE", Rate = 50 } };
        }

        public Employee? Get(int id)
        {
            return employees.FirstOrDefault(p => p.Id == id);

        }


        public float Rate(int id)
        {
            if(id != 0 && Get(id) != null)
            {
                return Get(id).Rate;
               
            }
                return 1;

        }
        public void AddOrUpdate(Employee c)
        {


            var isAdd = false;
            if (c.Id == 0)
            {
                isAdd = true;
                c.Id = LastId + 1;
            }

            if (isAdd)
            {
                Employees.Add(c);
            }
        }

        public void Delete(int id)
        {
            if(id != 0 && Get(id) != null)
            {
                Employees.Remove(Get(id));
            }
        }
    }
}
