using Newtonsoft.Json.Linq;
using Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdlumenMVC.WebUI.Controllers
{
    public class TranslationsController : ApiController
    {

        [AllowAnonymous]
        // GET: api/Translations/5
        public IHttpActionResult Get(string id)
        {

            var resourceJson = new JObject();

            var _resources = resources.ResourceManager.GetResourceSet(new CultureInfo(id), true, true).GetEnumerator();

            while (_resources.MoveNext())
            {
                resourceJson.Add(_resources.Key.ToString(), _resources.Value.ToString());
            }

            return Ok(resourceJson);
        }

    }
}
