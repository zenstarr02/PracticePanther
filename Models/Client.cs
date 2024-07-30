using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Client
    {
  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; } 
    public bool IsActive { get; set; } 

        
       

        public Client() { Id = 0; }

        public Client(string name, int id)
        {
            Name = name??string.Empty;
            Id = id;
        }
        

        public string Display
        {
            get { return ToString(); }
        }


        public override string ToString()
        {
            string x;
            if (IsActive) { x = "Open"; } else { x = "Closed"; }

            return $"{Id}. {Name}\t{x}";
        }

        public void activate() { IsActive = true; }
        public void deactivate() { IsActive = false; }


    }
}
