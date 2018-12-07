using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Models.Model;
using AdlumenMVC.WebUI.Infrastructure;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class FinancieroController : ApiController
    {
        private IFinancieroRepository Context;

        public FinancieroController(IFinancieroRepository _Context)
        {
            Context = _Context;
        }

        [Authorize(Roles = "Admin, manager, SuperAdmin")]
        // GET api/financiero
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "Lectura")]
        // GET api/financiero/5
        public object Get(int id)
        {
            var userId = User.Identity.GetUserId();
            var user = UserUtil.GetUserById(userId);
            var data = Context.GetTotalesMovimientoPorProyecto(id, user.IdTenant);

            return data;
        }

        [ClaimsAuthorization(Modulo = "Gastos", ActionName = "Escritura")]
        // POST api/financiero
        public async Task<IHttpActionResult> Post(JObject value)
        {
            dynamic data = value;
            string action = (string)data.action;
            string userName = null;
            if (data.userId != null)
            {
                userName = Context.GetUsuarioById((int)data.userId).UserName;
            }

            switch (action)
            {
                case "addMovimiento":
                    {
                        Pry_Movimientos movimiento = new Pry_Movimientos()
                        {
                            IdPresupuesto = (int)data.idPresupuesto,
                            IdProveedor = (int?)data.idProveedor,
                            Monto = (double?)data.monto,
                            Fecha = (DateTime?)data.fecha,
                            Observaciones = (string)data.observaciones,
                            UrlSoporte = (string)data.urlSoporte,
                            IdPeriodo = (int?)data.idPeriodo,
                            BENEFICIARIO = (string)data.beneficiario,
                            MEDIOPAGO = (string)data.medioPago,
                            CONTRAPARTIDA = !string.IsNullOrEmpty((string)data.contraPartida) ? ((decimal?)data.contraPartida) : null,
                            APORTEPROGRAMA = !string.IsNullOrEmpty((string)data.aportePrograma) ? ((decimal?)data.aportePrograma) : null,
                            IDPARTIDAGASTO = (int?)data.idPartidaGasto,
                            USUARIOCREACION = userName,
                            FECHACREACION = DateTime.Now,
                            APORTEMONEDALOCAL = (decimal?)data.aporteMonedaLocal,
                            MONEDALOCAL = (int?)data.moneda
                        };
                        Context.addMovimiento(movimiento);
                        for (int i = 0; i < ((JArray)data.montosDonantes).Count; i++)
                        {
                            if (data.montosDonantes[i].monto != null && (double)data.montosDonantes[i].monto != 0)
                            {
                                double monto = 0;
                                bool ok = double.TryParse((string)data.montosDonantes[i].monto, out monto);

                                if (ok)
                                {
                                    Pry_MontoDonacion montoDonacion = new Pry_MontoDonacion()
                                    {
                                        IdMovimiento = movimiento.IdMovimiento,
                                        IdDonante = (int)data.montosDonantes[i].idDonante,
                                        Monto = monto
                                    };

                                    Context.addMontoDonacion(montoDonacion);
                                }
                            }
                        }
                    }
                    break;
                case "modifyMovimiento":
                    {
                        Pry_Movimientos movimiento = Context.GetMovimiento((int)data.idMovimiento);
                        bool modified = false;
                        if (movimiento.IdPresupuesto != (int)data.idPresupuesto)
                        {
                            movimiento.IdPresupuesto = (int)data.idPresupuesto;
                            modified = true;
                        }
                        if (movimiento.IdProveedor != (int?)data.idProveedor)
                        {
                            movimiento.IdProveedor = (int?)data.idProveedor;
                            modified = true;
                        }
                        if (movimiento.Monto != (double?)data.monto)
                        {
                            movimiento.Monto = (double?)data.monto;
                            modified = true;
                        }
                        if (movimiento.Fecha != (DateTime?)data.fecha)
                        {
                            movimiento.Fecha = (DateTime?)data.fecha;
                            modified = true;
                        }
                        if (movimiento.Observaciones != (string)data.observaciones)
                        {
                            movimiento.Observaciones = (string)data.observaciones;
                            modified = true;
                        }
                        if (movimiento.UrlSoporte != (string)data.urlSoporte)
                        {
                            movimiento.UrlSoporte = (string)data.urlSoporte;
                            modified = true;
                        }
                        if (movimiento.IdPeriodo != (int?)data.idPeriodo)
                        {
                            movimiento.IdPeriodo = (int?)data.idPeriodo;
                            modified = true;
                        }
                        if (movimiento.BENEFICIARIO != (string)data.beneficiario)
                        {
                            movimiento.BENEFICIARIO = (string)data.beneficiario;
                            modified = true;
                        }
                        if (movimiento.MEDIOPAGO != (string)data.medioPago)
                        {
                            movimiento.MEDIOPAGO = (string)data.medioPago;
                            modified = true;
                        }
                        if (movimiento.CONTRAPARTIDA != (decimal?)data.contraPartida)
                        {
                            movimiento.CONTRAPARTIDA = (decimal?)data.contraPartida;
                            modified = true;
                        } 
                        if (movimiento.APORTEPROGRAMA != (decimal?)data.aportePrograma)
                        {
                            movimiento.APORTEPROGRAMA = (decimal?)data.aportePrograma;
                            modified = true;
                        }
                        if (movimiento.IDPARTIDAGASTO != (int?)data.idPartidaGasto)
                        {
                            movimiento.IDPARTIDAGASTO = (int?)data.idPartidaGasto;
                            modified = true;
                        }
                        if (movimiento.APORTEMONEDALOCAL != (decimal?)data.aporteMonedaLocal)
                        {
                            movimiento.APORTEMONEDALOCAL = (decimal?)data.aporteMonedaLocal;
                            modified = true;
                        }
                        if (movimiento.MONEDALOCAL != (int?)data.moneda)
                        {
                            movimiento.MONEDALOCAL = (int?)data.moneda;
                            modified = true;
                        }
                        if (modified)
                        {
                            movimiento.FECHAMODIFICACION = DateTime.Now;
                            movimiento.USUARIOMODIFICACION = userName;
                        }
                        Context.modifyMovimiento();
                        Context.deleteMontoDonacion(movimiento);
                        for (int i = 0; i < ((JArray)data.montosDonantes).Count; i++)
                        {
                            if (data.montosDonantes[i].monto != null && (int)data.montosDonantes[i].monto != 0)
                            {
                                double monto = 0;
                                bool ok = double.TryParse((string)data.montosDonantes[i].monto, out monto);

                                if (ok)
                                {
                                    Pry_MontoDonacion montoDonacion = new Pry_MontoDonacion()
                                    {
                                        IdMovimiento = movimiento.IdMovimiento,
                                        IdDonante = (int)data.montosDonantes[i].idDonante,
                                        Monto = monto
                                    };

                                    Context.addMontoDonacion(montoDonacion);
                                }
                            }
                        }
                    }
                    break;
                case "deleteMovimiento":
                    {
                        Pry_Movimientos movimiento = Context.GetMovimiento((int)data.idMovimiento);
                        Context.deleteMontoDonacion(movimiento);
                        Context.deleteMovimiento(movimiento);
                    }
                    break;
                case "import":
                    {
                        JArray movimientos = (JArray)value["movimientos"];
                        foreach (JObject movimientodata in movimientos)
                        {
                            dynamic movdata = movimientodata;
                            DateTime? fechaFormateada = null;

                            string[] dateformat = {"yyyy/MM/dd"};
                            DateTime date;

                            if (DateTime.TryParseExact((string)movdata.fecha,
                                                       dateformat, 
                                                       System.Globalization.CultureInfo.InvariantCulture,
                                                       System.Globalization.DateTimeStyles.None, 
                                                       out date))
                            {
                                 fechaFormateada = date;
                            }

                            Pry_Movimientos movimiento = new Pry_Movimientos()
                            {
                                IdPresupuesto = (int)movdata.idPresupuesto,
                                IdProveedor = (int?)movdata.idProveedor,
                                Monto = (double?)movdata.monto,
                                Fecha = fechaFormateada,
                                Observaciones = (string)movdata.observaciones,
                                UrlSoporte = (string)movdata.urlSoporte,
                                IdPeriodo = (int?)movdata.idPeriodo,
                                BENEFICIARIO = (string)movdata.beneficiario,
                                MEDIOPAGO = (string)movdata.medioPago,
                                CONTRAPARTIDA = !string.IsNullOrEmpty((string)movdata.contraPartida) ? ((decimal?)movdata.contraPartida) : null,
                                APORTEPROGRAMA = !string.IsNullOrEmpty((string)movdata.aportePrograma) ? ((decimal?)movdata.aportePrograma) : null,
                                IDPARTIDAGASTO = (int?)movdata.idPartidaGasto,
                                USUARIOCREACION = userName,
                                FECHACREACION = DateTime.Now,
                                APORTEMONEDALOCAL = (decimal?)movdata.aporteMonedaLocal,
                                MONEDALOCAL = (int?)movdata.moneda
                            };
                            Context.addMovimiento(movimiento);
                        }
                    }
                    break;
            }
            return Ok();
        }

        // PUT api/financiero/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/financiero/5
        public void Delete(int id)
        {
        }
    }
}
