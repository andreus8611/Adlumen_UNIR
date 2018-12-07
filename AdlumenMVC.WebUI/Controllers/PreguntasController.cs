using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
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
    public class PreguntasController : ApiController
    {
        private IPreguntasRepository Context;

        public PreguntasController(IPreguntasRepository _Context)
        {
            Context = _Context;
        }

        [ClaimsAuthorization(Modulo = "Encuestas", ActionName = "Lectura")]
        // GET api/preguntas
        public IEnumerable<Object> Get()
        {
            return Context.GetAll();
        }

        [ClaimsAuthorization(Modulo = "Encuestas", ActionName = "Escritura")]
        // POST api/preguntas
        public void Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            switch (action)
            {
                case "addmodify":
                    {
                        if (data.idPregunta == 0) //Nueva Pregunta
                        {
                            M_Preguntas pregunta = new M_Preguntas()
                            {
                                IdEncuesta = data.idEncuesta,
                                Orden = data.orden,
                                Pregunta = data.pregunta,
                                Tipo = data.tipo.id
                            };

                            var posiblesRespuestasArr = data.m_PosiblesRespuestas;

                            if (posiblesRespuestasArr != null && posiblesRespuestasArr.Count > 0)
                            {
                                //List<string> posiblesRespuestasArray = posiblesRespuestasArr[0].ToString().Split(new char[] { '\n' }).ToList();
                                foreach (var respuesta in posiblesRespuestasArr)
                                {
                                    var posibleRespuesta = new M_PosiblesRespuestas()
                                    {
                                        Respuesta = respuesta,
                                        M_Preguntas = pregunta
                                    };

                                    pregunta.M_PosiblesRespuestas.Add(posibleRespuesta);
                                }
                            }
                            Context.addPregunta(pregunta);
                        }
                        else
                        {
                            var pregunta = Context.GetPreguntaById((int)data.idPregunta);
                            if (pregunta.Orden != (int)data.orden) pregunta.Orden = (int)data.orden;
                            if (pregunta.Pregunta != (string)data.pregunta) pregunta.Pregunta = (string)data.pregunta;
                            if (pregunta.Tipo != (int)data.tipo.id) pregunta.Tipo = (int)data.tipo.id;
                            Context.modifyPregunta(pregunta);
                            Context.deletePosiblesRespuestas(pregunta);

                            var posiblesRespuestasArr = data.m_PosiblesRespuestas;

                            if (posiblesRespuestasArr != null && posiblesRespuestasArr.Count > 0)
                            {
                                //List<string> posiblesRespuestasArray = posiblesRespuestasArr[0].ToString().Split(new char[] { '\n' }).ToList();
                                foreach (string respuesta in posiblesRespuestasArr)
                                {
                                    var posibleRespuesta = new M_PosiblesRespuestas()
                                    {
                                        Respuesta = respuesta,
                                        M_Preguntas = pregunta
                                    };

                                    pregunta.M_PosiblesRespuestas.Add(posibleRespuesta);
                                }
                            }
                            Context.modifyPregunta(pregunta);
                        }
                    }
                    break;
                case "delete":
                    {
                        M_Preguntas pregunta = Context.GetPreguntaById((int)data.idPregunta);
                        Context.deletePosiblesRespuestas(pregunta);
                        Context.deletePregunta(pregunta);
                    }
                    break;
            };
        }

    }
}
