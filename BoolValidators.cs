using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    class AndValidator : BaseValidator<bool>
    {
        private List<BaseValidator<bool>> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is BaseValidator<bool> boolChildValidator)
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

    class IntConverterValidator : BaseValidator<bool>
    {
        private List<BaseValidator<int>> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            if (inputChildValidators.Count != 2)
                throw new ArgumentException();

            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is BaseValidator<int> intChildValidator)
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
