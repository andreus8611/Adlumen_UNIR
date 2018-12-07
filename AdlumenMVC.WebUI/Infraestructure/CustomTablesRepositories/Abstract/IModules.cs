using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdlumenMVC.WebUI.Infraestructure.CustomTablesRepositories.Abstract
{
    public interface IModules
    {
        //Get all the modules from Modulo table in the identity database
        List<Modulo> GetAll();
        //Get Module by Id
        Modulo Get(int id);
        //If necessary add the create Module method

        Modulo GetByName(string name);
    }
}
