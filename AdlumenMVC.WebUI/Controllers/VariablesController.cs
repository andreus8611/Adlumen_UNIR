using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Controllers.Formula;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class VariablesController : ApiController
    {
        private IVariablesRepository Context;

        public VariablesController(IVariablesRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Lectura")]
        // GET api/variables
        public IEnumerable<Pry_Variables> Get()
        {
            return Context.GetAllVariables();
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        // POST api/presupuestoproyecto
        public string Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;

            string strReturn = null;

            switch (action)
            {
                case "addVariable":
                    {
                        Pry_Variables variable = new Pry_Variables()
                        {
                            Nombre = (string)data.nombre,
                            FuenteInformacion = (string)data.fuenteInformacion
                        };

                        Context.addVariable(variable);
                        strReturn = variable.IdVariable.ToString();
                    }
                    break;
                case "modifyVariable":
                    {
                        Pry_Variables variable = Context.GetVariable((int)data.idVariable);
                        bool modified = false;

                        if (variable.Nombre != (string)data.nombre)
                        {
                            variable.Nombre = (string)data.nombre;
                            modified = true;
                        }
                        if (variable.FuenteInformacion != (string)data.fuenteInformacion)
                        {
                            variable.FuenteInformacion = (string)data.fuenteInformacion;
                            modified = true;
                        }
                        
                        Context.modifyData();
                    }
                    break;
                case "deleteVariable":
                    {
                        Pry_Variables variable = Context.GetVariable((int)data.idVariable);
                        Context.deleteVariable(variable);
                    }
                    break;
                case "checkFormula":
                    {
                        strReturn = FormulaEvaluator.Evaluar((string)data.strFormula);
                    }
                    break;
            }

            return strReturn;
        }

    }
}
