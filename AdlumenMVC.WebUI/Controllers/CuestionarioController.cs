using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class CuestionarioController : ApiController
    {
        private ICuestionarioRepository Context;

        public CuestionarioController(ICuestionarioRepository _Context)
        {
            Context = _Context;
        }

        [AllowAnonymous]
        // GET api/cuestionario
        public IEnumerable<Object> Get()
        {
            return Context.GetCuestionarios();
        }

        [AllowAnonymous]
        // GET api/cuestionario/5
        public Object Get(int id)
        {
            return Context.GetCuestionarioById(id);
        }

        [AllowAnonymous]
        // POST api/preguntas
        public void Post(JObject value)
        {
            M_EncuestasResueltas encuestaResuelta = new M_EncuestasResueltas()
            {
                IdEncuesta = (int)value["idEncuesta"],
                Usuario = "Anonimo",
                Fecha = DateTime.Now
            };
            JArray preguntasEnCuestionario = (JArray)value["preguntasAMostrar"];
            foreach (JObject oPregunta in preguntasEnCuestionario)
            {
                string textoRespuesta = null;

                //Obtener el valor del texto
                if (!string.IsNullOrEmpty(oPregunta["textoRespuesta"].ToString())) 
                {
                    textoRespuesta = oPregunta["textoRespuesta"].ToString();
                }
                else if (!string.IsNullOrEmpty(oPregunta["numeroRespuesta"].ToString()))
                {
                    textoRespuesta = oPregunta["numeroRespuesta"].ToString();
                }
                else if (!string.IsNullOrEmpty(oPregunta["fechaRespuesta"].ToString()))
                {
                    textoRespuesta = oPregunta["fechaRespuesta"].ToString();
                }

                M_PreguntasResueltas preguntaResuelta = new M_PreguntasResueltas()
                {
                    IdPregunta = (int)oPregunta["idPregunta"],
                    TextoRespuesta = textoRespuesta,
                    M_EncuestasResueltas = encuestaResuelta
                };

                //Obtener el valor de simples/multiples respuestas
                if (!string.IsNullOrEmpty(oPregunta["valorRespuestaSimple"].ToString()))
                {
                    M_ValoresRespuesta valorRespuesta = new M_ValoresRespuesta()
                    {
                        M_PreguntasResueltas = preguntaResuelta,
                        Valor = (string)oPregunta["valorRespuestaSimple"]
                    };
                    preguntaResuelta.M_ValoresRespuesta.Add(valorRespuesta);
                }
                else
                {
                    JArray valoresRespuestaMultiple = (JArray)oPregunta["respuestasAMostrar"];
                    foreach (JObject valor in valoresRespuestaMultiple)
                    {
                        bool selected = (bool)valor["seleccionada"];
                        if (selected)
                        {
                            M_ValoresRespuesta valorRespuesta = new M_ValoresRespuesta()
                            {
                                M_PreguntasResueltas = preguntaResuelta,
                                Valor = (string)valor["idRespuesta"]
                            };
                            preguntaResuelta.M_ValoresRespuesta.Add(valorRespuesta);
                        }
                    }
                }

                encuestaResuelta.M_PreguntasResueltas.Add(preguntaResuelta);
            }
            Context.addEncuestaResuelta(encuestaResuelta);

        }

        // PUT api/preguntas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/preguntas/5
        public void Delete(int id)
        {
        }
    }
}
