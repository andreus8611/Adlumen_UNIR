using AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract;
using AdlumenMVC.WebUI.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Concrete
{
    public class AccionesRoleRepository : IAccionesRoles
    {
        public IEnumerable<AccionesRole> GetAll()
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var accionesxRol = Context.AccionesRoles.ToList();

                return accionesxRol;
            }
        }

        public IEnumerable<AccionesRole> GetByRole(string id)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var accionesxRol = Context.AccionesRoles.Where(a => a.RoleId == id);

                return accionesxRol;
            }
        }

        public bool exist(int moduleId, int actionId, string roleId)
        {
            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var accionesxRol = Context.AccionesRoles.Any(ar => ar.AccionesId == actionId && ar.RoleId == roleId);

                return accionesxRol;
            }
        }

        public void assignPermission(List<AccionesRole> _accionesRol)
        {
            string roleId = _accionesRol.FirstOrDefault().RoleId;

            using (ApplicationDbContext Context = new ApplicationDbContext())
            {
                var accionesxRol = Context.AccionesRoles.Where(ar => ar.RoleId == roleId);

                Context.AccionesRoles.RemoveRange(accionesxRol);

                Context.AccionesRoles.AddRange(_accionesRol);

                Context.SaveChanges();
            }
        }
    }
}