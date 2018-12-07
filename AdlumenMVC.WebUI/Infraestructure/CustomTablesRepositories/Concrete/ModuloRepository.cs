using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Concrete
{
    public class ModuloRepository : IModules
    {
        public List<Modulo> GetAll()
        {
            using(ApplicationDbContext Context = new ApplicationDbContext())
            {
                var modules = Context.Modulo.ToList();

                return modules;
            };
        }

        public Modulo Get(int id)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var module = Context.Modulo.FirstOrDefault(m => m.ModuloId == id);

                return module;
            }
        }

        public Modulo GetByName(string name)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var module = Context.Modulo.FirstOrDefault(m => m.Nombre == name);

                return module;
            }
        }
    }
}