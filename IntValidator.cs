using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    abstract class IntValidator : BaseValidator
    {
        public virtual int Evaluate() => 0;
    }

    class IntInputValidator : IntValidator
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

    class IntSumValidator : IntValidator
    {
        private List<IntValidator> childValidators;

        protected override void SetChildValidators(List<BaseValidator> inputChildValidators)
        {
            foreach (var childValidator in inputChildValidators)
            {
                if (childValidator is IntValidator intChildValidator)
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
