using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PP.Library.Models;
using PP.Library.Utilities;

namespace PP.Library.Services
{
    public class ClientService
    {

        private int LastId
        {
            get { return Clients.Any() ? Clients.Select(c => c.Id).Max() : 1; }
        }
        private static ClientService? instance;
        private static object _lock = new object();
        public static ClientService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ClientService();
                    }
                    return instance;
                }
            }
        }

        private List<Client> clients;


        public List<Client> Clients
        {
            get
            {
                /*var response = new WebRequestHandler().Get("/Client/GetClients").Result;
                var clients = JsonConvert.
                    DeserializeObject<List<Client>>(response);
                return clients??new List<Client>(); }*/
                return clients;
            }
        }

        private ClientService()
        {

            clients = new List<Client>
            {
                new Client{Id = 1 , Name = "Client 1", IsActive= true}
                , new Client{Id = 2, Name = "Client 2" ,IsActive= true}
                , new Client{Id = 3, Name = "Client 3",IsActive= false}
                , new Client{Id = 4, Name = "Client 4", IsActive= true}
                , new Client{Id = 5, Name = "Client 5", IsActive = true}
                , new Client{Id = 6, Name = "Client 6", IsActive = false }

            };
        }

        public Client? Get(int id)
        {
            return Clients.FirstOrDefault(p => p.Id == id);
        }

        public void AddOrUpdate(Client c)
        {
            
            var isAdd = false;
            if (c.Id == 0) 
            {
                isAdd = true;
                c.Id = LastId + 1;
            }

            if(isAdd)
            {
                c.IsActive = true;
                c.OpenDate = DateTime.Now;
                Clients.Add(c);
            }
        }

        public void Remove(Client c) 
        { 
            Clients.Remove(c); 
        }

        public void Delete(int id)
        {
            if(Get(id) != null) 
            {
                Clients.Remove(Get(id));
            }
        }

        // int Count() { return clients.Count; }

        public void Close(int id)
        {
            var c = Get(id); if(c != null)
            {
                c.IsActive = false;
                c.CloseDate = DateTime.Now;
            }
        }

        public void Read()
        {
            Clients.ForEach(Console.WriteLine);
        }
    }
}

