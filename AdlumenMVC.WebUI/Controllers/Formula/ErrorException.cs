using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdlumenMVC.WebUI.Controllers.Formula
{
    //Reused from silverlight implementation
    //Adlumen2.BizEntities.Projects.Formula.ErrorException
    public class ErrorException : Exception
    {
        public ErrorException(long MessageId, string Message)
        {
            _message = Message;
            _messageId = MessageId;
        }
        public ErrorException(string Message)
        {
            _message = Message;
        }
        public ErrorException(long MessageId)
        {
            _messageId = MessageId;
        }
        public string _message;
        public long _messageId;
    }
}