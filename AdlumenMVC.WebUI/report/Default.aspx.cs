using AdlumenMVC.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdlumenMVC.WebUI.Reports
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["path"]))
                {
                    var reportpath = HttpUtility.HtmlDecode(Request.QueryString["path"]);
                    int aantalKeys = Request.Params.AllKeys.Length;

                    var parameters = new List<ReportParameter>();
                    for (int i = 1; i < aantalKeys; i++)
                    {
                        var value = Request.Params[i];
                        var key = Request.Params.Keys[i];
                        if (key.Contains("_RAP"))
                        {
                            int index = key.IndexOf('_');
                            key = key.Substring(0, index);
                            var parameter = new ReportParameter(key, HttpUtility.HtmlDecode(value));
                            parameters.Add(parameter);
                        }
                    }
                    this.RenderReport(reportpath, parameters);
                }

            }
        }

        private void RenderReport(string reportpath, List<ReportParameter> parameters = null)
        {
            var User = ConfigurationManager.AppSettings["reporting:user"];
            var Pass = ConfigurationManager.AppSettings["reporting:pass"];
            var ReportServerUrl = ConfigurationManager.AppSettings["reporting:url"];

            var uri = new Uri(ReportServerUrl);
            var irsc = new CustomReportCredentials(User, Pass, string.Empty);

            viewer.Visible = true;
            viewer.ServerReport.ReportServerCredentials = irsc;
            viewer.ServerReport.ReportServerUrl = new Uri(uri.AbsoluteUri);
            viewer.ServerReport.ReportPath = reportpath;
            
            parameters.Add(new ReportParameter("ConnectionString", 
                ConfigurationManager.ConnectionStrings["Reporting"].ConnectionString));

            var tenant = TenantUtil.GetTenantFromUrl();
            if (tenant == null)
            {
                throw new Exception("no tenant");
            }

            parameters.Add(new ReportParameter("IdTenant", tenant.Id.ToString()));

            if (parameters != null && parameters.Count != 0)
            {
                viewer.ServerReport.SetParameters(parameters);
            }
            viewer.ServerReport.Refresh();
        }

        private Dictionary<string, object> GetCurrentParameters()
        {

            var parameterCollection = viewer.ServerReport.GetParameters();

            var param = new Dictionary<string, object>();
            foreach (var p in parameterCollection)
            {
                var name = p.Name;
                if (p.DataType == ParameterDataType.DateTime)
                {
                    var d = Convert.ToDateTime(p.Values[0]);
                    param[name] = d.ToString("dd-MM-yyyy");
                }
                else
                {
                    var values = p.Values.ToList();
                    param[name] = values;
                }
            }
            return param;
        }
    }

    [Serializable]
    public class CustomReportCredentials : IReportServerCredentials
    {
        private string _UserName;
        private string _PassWord;
        private string _DomainName;

        public CustomReportCredentials()
        {

        }

        public CustomReportCredentials(string UserName, string PassWord, string DomainName)
        {
            _UserName = UserName;
            _PassWord = PassWord;
            _DomainName = DomainName;
        }

        public WindowsIdentity ImpersonationUser
        {
            get { return null; }
        }

        public ICredentials NetworkCredentials
        {
            get { return new NetworkCredential(_UserName, _PassWord, _DomainName); }
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string user, out string password, out string authority)
        {
            authCookie = null;
            user = password = authority = null;
            return false;
        }
    }
}