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
    [Authorize(Roles = "Admin")]
    public class BeneficiariosController : ApiController
    {
        private IBeneficiarios Context;

        public BeneficiariosController(IBeneficiarios _Context)
        {
            Context = _Context;
        }

        public IEnumerable<Object> GetBeneficiarios()
        {
            return Context.GetBeneficiarios();
        }

        public Pry_Beneficiarios GetBeneficiarioById(int idBeneficiario)
        {
            return Context.GetBeneficiarioById(idBeneficiario);
        }

        public void postBeneficiarios(JObject beneficiario)
        {
            Pry_Beneficiarios _beneficiario = new Pry_Beneficiarios()
            {
                IdObjetivo = (int)beneficiario.SelectToken("cmbIdObjetivo"),
                Nombre = (string)beneficiario.SelectToken("txtNombre"),
                Email = (string)beneficiario.SelectToken("txtEmail"),
                Telefono = (string)beneficiario.SelectToken("txtTelefono"),
                Direccion = (string)beneficiario.SelectToken("txtDireccion"),
                extensionTerritorial = (decimal)beneficiario.SelectToken("txtExtensionTerritorial"),
                Status = 1
            };

            Context.addBeneficiario(_beneficiario);
        }

        public void putBeneficiarios(JObject beneficiario)
        {
            Pry_Beneficiarios _beneficiario = new Pry_Beneficiarios()
            {
                IdBeneficiario = (int)beneficiario.SelectToken("idBeneficiario"),
                IdObjetivo = (int)beneficiario.SelectToken("cmbIdObjetivo"),
                Nombre = (string)beneficiario.SelectToken("txtNombre"),
                Email = (string)beneficiario.SelectToken("txtEmail"),
                Telefono = (string)beneficiario.SelectToken("txtTelefono"),
                Direccion = (string)beneficiario.SelectToken("txtDireccion"),
                extensionTerritorial = (decimal)beneficiario.SelectToken("txtExtensionTerritorial"),
                Status = (byte)beneficiario.SelectToken("status"),
            };

            Context.updateBeneficiario(_beneficiario);
        }

    }
}
