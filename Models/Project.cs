using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Project : Client
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public int ClientId { get; set; }
    
        public Project() 
        {
            Id = 0;
        }
        public Bill bill;   
        public Project(string name){ 
        
        }

        public override string ToString()
        {
            string x;
            if(IsActive) { x = "Active"; }else { x = "Inactive"; }

            return $"{Id}\t{ClientId}. {ShortName}\t{x}";
        }


    }



}
