﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Task2
{
    /// <summary>
    /// Class with an exception thrown if an attempt is made to add an existing item to the list.
    /// </summary>
    public class DeleteNonexistentItemException : System.Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNonexistentItemException"/> class.
        /// </summary>
        public DeleteNonexistentItemException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNonexistentItemException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public DeleteNonexistentItemException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNonexistentItemException"/> class.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="inner">Inner exception.</param>
        public DeleteNonexistentItemException(string message, Exception inner)
            : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNonexistentItemException"/> class.
        /// </summary>
        /// <param name="info">Serialization information.</param>
        /// <param name="context">Streaming context.</param>
        protected DeleteNonexistentItemException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}