using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FocusValidation
{
    static class InputProvider
    {
        private static List<Input> inputs;

        public static void ParseInputValuesFromJson(string json)
        {
            inputs = new List<Input>();
            // TODO
        }

        public static Input<T> GetInput<T>(int ID)
        {
            var input = inputs.Find(x => x.ID == ID);
            if (input is Input<T> typedInput)
                return typedInput;
            else
                throw new BadInputTypeException();
        }
    }

    [Serializable]
    public class BadInputTypeException : Exception
    {
        public BadInputTypeException() { }

        public BadInputTypeException(string message) : base(message) { }

        public BadInputTypeException(string message, Exception innerException) : base(message, innerException) { }
    }

    class Input
    {
        public int ID { get; protected set; }

        public Input(int ID)
        {
            this.ID = ID;
        }
    }

    class Input<T> : Input
    {
        public Input(int ID) : base(ID) { }

        public T Value { get; set; }
    }
}
