using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator
{
    public sealed class FibonacciEnumerable : IEnumerable<int>
    {
        private readonly int count;
        private readonly int skipCount;

        public FibonacciEnumerable(int count = int.MaxValue, int skipCount = 0)
        {
            if (count >= 0)
            {
                if (skipCount >= 0)
                {
                    this.count = count;
                    this.skipCount = skipCount;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(skipCount));
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new FibonacciEnumerator(this.count, this.skipCount);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
