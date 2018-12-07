using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Controllers.Formula
{
    public class ExpEvaluator : IOperatorImp
    {
        //can be user specific
        private IOperatorImp _OpInst = null;
        private IParser _exp_parser = null;
        private ExpTreeNode _exp_tree = null;

        public ExpEvaluator(IOperatorImp _ops)
        {
            //Use IParser to parse it 
            _OpInst = _ops;

            // TODO: Add constructor logic here
        }
        public ExpEvaluator(IParser _parser)
        {
            //Use IParser to parse it 
            _exp_parser = _parser;

            // TODO: Add constructor logic here
        }
        public ExpEvaluator(IParser _parser, IOperatorImp _ops)
        {
            //Use IParser to parse it 
            _OpInst = _ops;
            _exp_parser = _parser;
            // TODO: Add constructor logic here
        }
        //Indexed property for setting the Symbol--
        //Can be done while parsing only..But Ok this way also--Infact better
        //This way the value of the Symbol can be chnaged after the parsing is
        //done even and Expression can be 
        //re-valuated without parsing again.
        public double this[string sym]
        {
            //Get needs to be witten 
            set
            {
                if (_exp_tree != null)
                {
                    _exp_tree[sym] = value;
                }
                else
                {
                    ErrorException Er = new ErrorException("Formula Invalida");
                    throw Er;
                }
            }

        }
        public bool SetExpression(string _exp)
        {
            //Clear the Previous Exp
            _exp_parser.Clear();
            //Now Parse the Exp
            _exp_tree = _exp_parser.ParseExpression(_exp);
            return true;
        }
        public double Evaluate()
        {
            //parse the Exp
            if (_exp_tree != null)
            {
                _exp_tree.ValidateExpTree();
                return _evaluate_exp(_exp_tree);
            }
            else
                return 0;
        }
        private double _evaluate_exp(ExpTreeNode n)
        {
            if (n == null)
            {
                ErrorException Er = new ErrorException("No hay formula para evaluar. ");
                throw Er;
            }
            double x, y;
            if (n._ndType == ExpTreeNode.NodeType.Operator)
            {

                x = _evaluate_exp(n._left);
                y = _evaluate_exp(n._right);
                return (_OpInst == null) ? ApplyOp(n._value.ToString(), x, y) : _OpInst.ApplyOp(n._value.ToString(), x, y);
            }
            return (System.Convert.ToInt64(n._value));

        }
    }
}