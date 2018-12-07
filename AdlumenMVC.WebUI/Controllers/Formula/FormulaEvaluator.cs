using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Controllers.Formula
{
    public static class FormulaEvaluator
    {
        public static string Evaluar(string strFormula)
        {
            string strError = "";
            ExpTreeNode[] sk = new ExpTreeNode[10];
            int i = 0;
            string NExp = strFormula;
            string[] lines = NExp.Split(';');
            string _expression = "";
            foreach (string _line in lines)
            {
                if (_line.IndexOf("=") > 0)
                {
                    string[] Sybl = _line.Split('=');
                    if (Sybl[0].Trim().Length < 1)
                    {
                        strError = "FORMULA_ERROR_SIMBOLO_NO_VALIDO: " + Sybl[0];
                        return strError;
                    }
                    if (Sybl[0].Trim().Length < 1)
                    {
                        strError = "FORMULA_ERROR_VALOR_NO_PERMITIDO: " + Sybl[0];
                        return strError;
                    }
                    ExpTreeNode tmp = new ExpTreeNode();
                    tmp._symbol = Sybl[0].Trim();
                    tmp._value = System.Convert.ToInt64(Sybl[1].Trim());
                    sk[i++] = tmp;
                }
                else
                {
                    if (_line.Length > 0)
                        _expression = _line;
                }
            }

            try
            {
                IParser par = new ExpParser();
                ExpEvaluator eu = new ExpEvaluator(par);
                eu.SetExpression(_expression);
                eu["y"] = 1;
                for (int j = 0; j < i; j++)
                {
                    eu[sk[j]._symbol] = System.Convert.ToInt64(sk[j]._value);
                }
                double res = eu.Evaluate();
                //strError = res.ToString();
                strError = "OK"; //+ res.ToString();
                return strError;
            }
            catch (ErrorException ka)
            {
                strError = ka._message;
                return strError;
            }
        }
    }
}