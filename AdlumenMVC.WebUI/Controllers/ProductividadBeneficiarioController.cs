using AdlumenMVC.Bussiness.AbstractRepositories;
using AdlumenMVC.Bussiness.RealRepositories;
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

    [Authorize(Roles="SuperAdmin")]
    public class ProductividadBeneficiarioController : ApiController
    {

        private IProductividadBeneficiario Context;

        public ProductividadBeneficiarioController(IProductividadBeneficiario _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> getProductividadBeneficiario()
        {
            return Context.GetProductividadBeneficiario();
        }

        public Pry_ProductividadBeneficiario getProductividadBeneficiarioById(int idProductividadBeneficiario)
        {
            return Context.GetProductividadBeneficiarioById(idProductividadBeneficiario);
        }

        public void postProductividadBeneficiario(JObject productividad)
        {
            Pry_ProductividadBeneficiario _productividad = new Pry_ProductividadBeneficiario()
            {
                IdBeneficiario = (int)productividad.SelectToken("cmbIdBeneficiario"),
                AreaSembrada = (decimal)productividad.SelectToken("txtAreaSembrada"),
                CultivoSembrado = (string)productividad.SelectToken("txtCultivoSembrado"),
                CantidadSembrada = (decimal)productividad.SelectToken("txtCantidadSembrada"),
                ProduccionCultivo = (decimal)productividad.SelectToken("txtProduccionCultivo")
            };

            Context.addProductividadBeneficiario(_productividad);
        }


    }
}
