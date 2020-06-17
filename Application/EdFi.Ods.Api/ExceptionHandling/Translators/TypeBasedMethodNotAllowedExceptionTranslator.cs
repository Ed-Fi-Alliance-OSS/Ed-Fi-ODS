using System;
using System.Linq;
using System.Net;
using EdFi.Ods.Common.Exceptions;
using EdFi.Ods.Common.Extensions;

namespace EdFi.Ods.Api.ExceptionHandling.Translators
{
    public class TypeBasedMethodNotAllowedExceptionTranslator : IExceptionTranslator
    {
        private readonly Type[] _exceptionTypes =
        {
            typeof(MethodNotAllowedException),
        };

        public bool TryTranslateMessage(Exception ex, out RESTError webServiceError)
        {
            webServiceError = null;

            if (!_exceptionTypes.Contains(ex.GetType()))
                return false;

            webServiceError = new RESTError
            {
                Code = (int) HttpStatusCode.MethodNotAllowed,
                Type = "Method Not Allowed",
                Message = ex.GetAllMessages()
            };

            return true;
        }
    }
}
