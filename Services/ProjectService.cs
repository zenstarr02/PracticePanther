using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.Library.Models;


namespace PP.Library.Services
{   
    public class ProjectService
    {
        private int LastId
        {
            get { return Projects.Any() ? Projects.Select(c => c.Id).Max() : 1; }
        }
        private static ProjectService? instance;
        private static object _lock = new object();
  public static ProjectService Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new ProjectService();
                    }
                    return instance;
                }               
            }
        }

    private List<Project> projects;

        private ProjectService()
        {

            projects = new List<Project> {
                new Project{Id = 1 , ShortName = "Project 1", ClientId = 1}
                , new Project{Id = 2, ShortName = "Project 2", ClientId = 2}
                , new Project{Id = 3, ShortName = "Project 3", ClientId = 3}
                , new Project{Id = 4, ShortName = "Project 4", ClientId = 4}
                , new Project{Id = 5, ShortName = "Project 5", ClientId = 5}
                , new Project{Id = 6, ShortName = "Project 6", ClientId = 6}
            };
        
        }


        public List<Project> Projects
        {
            get {return projects;}
           
        }

        public Project? Get(int id)
        {
            return projects.FirstOrDefault(p => p.Id == id);

        }

        public Project? GetByClient(int id)
        {
            return projects.FirstOrDefault(p => p.ClientId == id);

        }



        public void Add(Project p) 
        {
            p.IsActive = true;

            if (p.Id == 0)
            {
                p.Id = LastId + 1;
            }
            projects.Add(p); 
        
        }
        public void Remove(Project project) { projects.Remove(project); }


        public void AddOrUpdate(Project c)
        {

            
            var isAdd = false;
            if (c.Id == 0)
            {
                isAdd = true;
                c.Id = LastId + 1;
            }

            if (isAdd)
            {
                c.IsActive = true;
                c.OpenDate = DateTime.Now;
                Projects.Add(c);
            }
        }
        public void Read()
        {
           projects.ForEach(Console.WriteLine);
        }

        public void Close(int id)
        {
            var c = Get(id);
            if (c != null) 
            {
                c.IsActive = false;
                c.CloseDate = DateTime.Now;
            }
        }

        public void Delete(int id)
        {
            if (Get(id) != null)
            {
                projects.Remove(Get(id));
            }
        }

    }
}
