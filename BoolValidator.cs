using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    abstract class BoolValidator : BaseValidator
    {
        public virtual bool Evaluate() => false;
    }

    class AndValidator : BoolValidator
    {
        private List<BoolValidator> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is BoolValidator boolChildValidator)
                    childValidators.Add(boolChildValidator);
                else
                    throw new BadValidatorTypeException();
            }
        }

        public override bool Evaluate()
        {
            foreach (var childValidator in childValidators)
                if (!childValidator.Evaluate())
                    return false;

            return true;
        }
    }

    class IntConverterValidator : BoolValidator
    {
        private List<IntValidator> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            if (inputChildValidators.Count != 2)
                throw new ArgumentException();

            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is IntValidator intChildValidator)
                    childValidators.Add(intChildValidator);
                else
                    throw new BadValidatorTypeException();
            }
        }

        public override bool Evaluate()
        {
            return childValidators[0].Evaluate() == childValidators[1].Evaluate();
        }
    }
}
