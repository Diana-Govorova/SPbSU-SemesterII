using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Class with an exception thrown if an attempt is made to add an existing item to the list.
    /// </summary>
    public class ItemAlreadyImplementedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyImplementedException"/> class.
        /// </summary>
        public ItemAlreadyImplementedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyImplementedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public ItemAlreadyImplementedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyImplementedException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public ItemAlreadyImplementedException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAlreadyImplementedException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected ItemAlreadyImplementedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
