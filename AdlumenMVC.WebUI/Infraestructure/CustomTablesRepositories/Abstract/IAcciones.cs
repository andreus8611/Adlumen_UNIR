using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract
{
    public interface IAcciones
    {
        IEnumerable<Acciones> GetAll();
        Acciones GetById(int id);

        Acciones GetByName(string name, int moduleId);
    }
}
