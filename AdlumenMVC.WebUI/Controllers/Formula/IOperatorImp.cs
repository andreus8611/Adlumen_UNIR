using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Controllers.Formula
{
    //Reused from silverlight implementation
    //Adlumen2.BizEntities.Projects.Formula.IOperatorImp
    public abstract class IOperatorImp
    {
        public virtual double ApplyOp(string Op, double operand1, double operand2)
        {
            double z = 0;
            switch (Op)
            {
                case "+": z = operand1 + operand2; break;
                case "-": z = operand1 - operand2; break;
                case "*": z = operand1 * operand2; break;
                case "/": z = operand1 / operand2; break;
                case "^": z = System.Math.Pow(operand1, operand2); break;
                case "&&": z = System.Convert.ToDouble(System.Convert.ToBoolean(operand1) && System.Convert.ToBoolean(operand2)); break;
                case "||": z = System.Convert.ToDouble(System.Convert.ToBoolean(operand1) || System.Convert.ToBoolean(operand2)); break;
                case "=": z = operand2; break;
                default:
                    {
                        ErrorException Er = new ErrorException("Unknown Operator " + Op);
                        throw Er;

                    }


            }
            return z;
        }
    }
}