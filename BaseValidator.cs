using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    abstract class BaseValidator
    {
        protected virtual void SetChildValidators(List<BaseValidator> childValidators) { }

        public static List<BaseValidator> CreateValidators(string parameters)
        {
            List<BaseValidator> validators = new List<BaseValidator>();
            /*
             * vyparsuje se první vrstva z parameters (jakože nejvrchnější názvy validátorů)
             * vnitřek, který se ještě nevyparsoval, bude string innerParameters
             * z nich se vytvoří list
             * rekurzivně se vyparsuje vrstva pod tím, čímž dostaneme pro každý validátor list pod-validátorů, které mu předáme jako argumenty
             * např.:
             *      var validator = new AndValidator();
             *      var childValidators = BaseValidator.CreateValidators(innerParameters);
             *      validator.SetChildValidators(childValidators);
             *      validators.Add(validator)
             *      
             * pro input se postupuje jinak, vytvoří se např. IntInputValidator, kterému se předá příslušný Input
             */
            return validators;
        }
    }

    [Serializable]
    public class BadValidatorTypeException : Exception
    {
        public BadValidatorTypeException() { }

        public BadValidatorTypeException(string message) : base(message) { }

        public BadValidatorTypeException(string message, Exception innerException) : base(message, innerException) { }
    }
}
