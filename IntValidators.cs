using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    class IntInputValidator : BaseValidator<int>
    {
        private Input<int> input;

        public IntInputValidator(Input<int> input)
        {
            this.input = input;
        }

        public override int Evaluate()
        {
            return input.Value;
        }
    }

    class IntSumValidator : BaseValidator<int>
    {
        private List<BaseValidator<int>> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is BaseValidator<int> intChildValidator)
                    childValidators.Add(intChildValidator);
                else
                    throw new BadValidatorTypeException();
            }
        }

        public override int Evaluate()
        {
            int sum = 0;
            foreach (var childValidator in childValidators)
                sum += childValidator.Evaluate();

            return sum;
        }
    }
}
