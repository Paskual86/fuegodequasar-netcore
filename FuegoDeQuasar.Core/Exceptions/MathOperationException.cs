using System;

namespace FuegoDeQuasar.Core.Exceptions
{
    [Serializable]
    public class MathOperationException : Exception
    {
        public MathOperationException():base()
        {

        }

        public MathOperationException(string message)
        : base(message)
        {

        }
    }
}
