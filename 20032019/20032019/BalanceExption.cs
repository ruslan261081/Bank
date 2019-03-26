using System;
using System.Runtime.Serialization;

namespace _20032019
{
    [Serializable]
    internal class BalanceExption : Exception
    {
        public BalanceExption()
        {
        }

        public BalanceExption(string message) : base(message)
        {
        }

        public BalanceExption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BalanceExption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}