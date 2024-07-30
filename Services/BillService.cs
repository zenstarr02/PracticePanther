using PP.Library.Models;
using PP.Library.Models;
using PP.Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Services
{
    public class BillService
    {
        private int LastId
        {
            get { return Bills.Any() ? Bills.Select(c => c.Id).Max() : 1; }
        }

        private static BillService? instance;
        private static object _lock = new object();
        public static BillService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new BillService();
                    }
                    return instance;
                }
            }
        }


        private BillService()
        {
            bills = new List<Bill>();
        }

        private List<Bill> bills;

        public List<Bill> Bills
        {
            get { return bills; }
        }


        public void AddOrUpdate(Bill c)
        {

            var isAdd = false;
            if (c.Id == 0)
            {
                isAdd = true;
                c.Id = LastId + 1;
            }

            if (isAdd)
            {
                c.DueDate = DateTime.Now.AddDays(30);
                Bills.Add(c);
            }
        }

        public Bill? Get(int id)
        {
            return Bills.FirstOrDefault(p => p.Id == id);
        }

        
    }
}
