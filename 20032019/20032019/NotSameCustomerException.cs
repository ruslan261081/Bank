﻿using System;
using System.Runtime.Serialization;

namespace _20032019
{
    [Serializable]
    internal class NotSameCustomerException : Exception
    {
        public NotSameCustomerException()
        {
        }

        public NotSameCustomerException(string message) : base(message)
        {
        }

        public NotSameCustomerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSameCustomerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}