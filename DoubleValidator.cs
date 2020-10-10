using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    abstract class DoubleValidator : BaseValidator
    {
        public virtual double Evaluate() => 0;
    }
}
