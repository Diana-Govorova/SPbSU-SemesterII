using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    /// <summary>
    /// Interface of hash function.
    /// </summary>
    public interface IStack
    {
        bool IsEmpty();

        void Push(float element);

        float Pop();

        void Clear();
    }
}