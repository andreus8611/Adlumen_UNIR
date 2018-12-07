using System;
using System.Collections.Generic;

namespace AdlumenMVC.Models.Model
{
    public partial class PRY_INFORMESICADETALLE : ITenant
    {
        public int IDDETALLE { get; set; }
        public int IDINFORME { get; set; }
        public string DATOSFINANCIEROS { get; set; }
        public string OBSERVACIONES { get; set; }
        public string LOGROSPRINCIPALES { get; set; }
        public string PROBLEMASYACCIONES { get; set; }
        public string SUPUESTOS { get; set; }
        public string RECOMENDACIONES { get; set; }
        public string FACTORESEXITO { get; set; }
        public string FACTORESLIMITANTES { get; set; }
        public string CONDICIONALIDAD { get; set; }
        public string SOSTENIBILIDAD { get; set; }
        public string EFICACIAPROYECTO { get; set; }
        public string EFICACIARESULTADOS { get; set; }
        public string RELEVANCIAOBJETIVOS { get; set; }
        public string RELEVANCIAEXTERNA { get; set; }
        public string SOSTENIBILIDADBENEFICIOS { get; set; }
        public string SOSTENIBILIDADCAPACIDADES { get; set; }
        public string SOSTENIBILIDADPERTENECIA { get; set; }
        public string SOSTENIBILIDADOREPLICAS { get; set; }
        public string IMPACTOOBJETIVOS { get; set; }
        public string IMPACTOGENERAL { get; set; }
        public string IMPACTOALIANZAS { get; set; }
        public string IMPACTODIALOGO { get; set; }
        public int IdTenant { get; set; }
        public virtual PRY_INFORMESICA PRY_INFORMESICA { get; set; }
    }
}
