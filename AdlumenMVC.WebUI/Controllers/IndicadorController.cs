using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class IndicadorController : ApiController
    {
        private IIndicadoresProyectoRepository Context;

        public IndicadorController(IIndicadoresProyectoRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo="Indicadores", ActionName="Lectura")]
        // GET api/indicador/5
        public Object Get(int id)
        {
            return Context.GetIndicatorDetail(id);
        }

        [ClaimsAuthorization(Modulo = "Proyectos", ActionName = "Escritura")]
        // POST api/indicador
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            string userName = null;
            if (data.userId != null)
            {
                //modified because there is no security module yet
                userName = Context.GetUsuarioById((int)data.userId).UserName;
            }

            switch (action)
            {
                case "add":
                    {
                        Pry_DatosMuestras muestra = new Pry_DatosMuestras()
                        {
                            IdIndicador = (int)data.idIndicador,
                            IdPeriodo = (int)data.idPeriodo,
                            Observaciones = (string)data.observaciones,
                            FECHACREACION = DateTime.Now,
                            USUARIOCREACION = userName
                        };
                        Context.addDatosMuestra(muestra);

                        for (int i = 0; i < ((JArray)data.variables).Count; i++)
                        {
                            if (data.variables[i].value != null)
                            {
                                double variableValue = 0;
                                bool ok = double.TryParse((string)data.variables[i].value, out variableValue);

                                if (ok)
                                {
                                    Pry_DatosVariables variable = new Pry_DatosVariables()
                                    {
                                        IdDatosMuestra = muestra.IdDatosMuestra,
                                        IdVariable = (int)data.variables[i].id,
                                        Valor = variableValue
                                    };

                                    Context.addDatosVariable(variable);

                                }
                            }
                        }

                        for (int i = 0; i < ((JArray)data.verificators).Count; i++)
                        {
                            if ((bool)data.verificators[i].isNew)
                            {
                                Pry_DatosVerificadores verificador = new Pry_DatosVerificadores()
                                {
                                    IdDatosMuestra = muestra.IdDatosMuestra,
                                    IdVerificador = (int)data.verificators[i].idVerificator,
                                    Url = (string)data.verificators[i].url
                                };

                                Context.addDatosVerificador(verificador);
                            }
                            if ((bool)data.verificators[i].deleted && data.verificators[i].id != null){
                                Context.deleteDatosVerificador((int)data.verificators[i].id);
                            } 
                        }
                        Context.actualizarLogros(muestra, true /*nueva muestra*/);
                        Context.actualizarIndicador(muestra);
                        //To Do: Save verificadores
                    }
                    break;
                case "modify":
                    {
                        Pry_DatosMuestras muestra = Context.GetDatosMuestrasById((int)data.id);
                        if (!muestra.Observaciones.Equals((string)data.observaciones))
                        {
                            muestra.Observaciones = (string)data.observaciones;
                            muestra.FECHAMODIFICACION = DateTime.Now;
                            muestra.USUARIOMODIFICACION = userName;
                        }

                        for (int i = 0; i < ((JArray)data.variables).Count; i++)
                        {
                            if (data.variables[i].value != null)
                            {
                                double variableValue = 0;
                                bool ok = double.TryParse((string)data.variables[i].value, out variableValue);

                                if (ok)
                                {
                                    Pry_DatosVariables variable = Context.GetDatosVariablesById(muestra.IdDatosMuestra, (int)data.variables[i].id);

                                    if (variable == null)
                                    {
                                        variable = new Pry_DatosVariables()
                                        {
                                            IdDatosMuestra = muestra.IdDatosMuestra,
                                            IdVariable = (int)data.variables[i].id,
                                            Valor = variableValue
                                        };
                                        Context.addDatosVariable(variable);
                                    }
                                    else
                                    {
                                        variable.Valor = variableValue;
                                    }
                                }
                            }
                        }

                        for (int i = 0; i < ((JArray)data.verificators).Count; i++)
                        {
                            if ((bool)data.verificators[i].isNew)
                            {
                                Pry_DatosVerificadores verificador = new Pry_DatosVerificadores()
                                {
                                    IdDatosMuestra = muestra.IdDatosMuestra,
                                    IdVerificador = (int)data.verificators[i].idVerificator,
                                    Url = (string)data.verificators[i].url
                                };

                                Context.addDatosVerificador(verificador);
                            }
                            if ((bool)data.verificators[i].deleted && data.verificators[i].id != null)
                            {
                                var itemToDelete = Context.GetDatoVerificador((int)data.verificators[i].id);
                                if (itemToDelete != null)
                                {
                                    var path = HttpContext.Current.Server.MapPath(itemToDelete.Url);
                                    if (File.Exists(path))
                                    {
                                        File.Delete(path);
                                    }
                                }
                                Context.deleteDatosVerificador(itemToDelete.IdDatosFuentes);
                            }
                        }
                        Context.modifyMuestra();
                        Context.actualizarLogros(muestra, false /*muestra existente*/);
                        //To Do: Save verificadores
                    }
                    break;
                case "delete":
                    {
                        Pry_DatosMuestras muestra = Context.GetDatosMuestrasById((int)data.id);
                        Context.deleteMuestra(muestra);
                    }
                    break;
            }
        }

        [Authorize(Roles="SuperAdmin")]
        // PUT api/indicador/5
        public void Put(int id, [FromBody]string value)
        {
        }

        [Authorize(Roles="SuperAdmin")]
        // DELETE api/indicador/5
        public void Delete(int id)
        {
        }
    }
}
