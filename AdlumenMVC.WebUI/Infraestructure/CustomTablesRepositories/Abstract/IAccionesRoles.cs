using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract
{
    public interface IAccionesRoles
    {
        IEnumerable<AccionesRole> GetAll();
        IEnumerable<AccionesRole> GetByRole(string id);
        bool exist(int moduleId, int actionId, string roleId);

        void assignPermission(List<AccionesRole> _accionesRol);
    }
}
