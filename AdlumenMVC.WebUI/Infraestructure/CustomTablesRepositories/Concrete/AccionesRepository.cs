using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Concrete
{
    public class AccionesRepository : IAcciones
    {

        public IEnumerable<Acciones> GetAll()
        {
            using(ApplicationDbContext Context = new ApplicationDbContext())
            {
                return Context.Acciones.ToList();
            }
        }
        public Acciones GetById(int id)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                return Context.Acciones.FirstOrDefault(a => a.AccionesId == id);
            }
        }

        public Acciones GetByName(string name, int idModule)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Acciones.FirstOrDefault(x => x.Nombre == name && x.ModuloId == idModule);
            }
        }
    }
}