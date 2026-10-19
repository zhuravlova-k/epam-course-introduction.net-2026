using System;
using System.Collections;
using System.Collections.Generic;

namespace FibonacciIterator
{
    public sealed class FibonacciEnumerator : IEnumerator<int>
    {
        private readonly int count;
        private readonly int skipCount;
        private int yieldedCount;
        private int currentStep;
        private int prev;
        private int current;

        public FibonacciEnumerator(int count, int skipCount)
        {
            this.count = count;
            this.skipCount = skipCount;
            this.Reset();
        }

        public int Current
        {
            get
            {
                if (this.currentStep < this.skipCount)
                {
                    throw new InvalidOperationException();
                }

                return this.current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public bool MoveNext()
        {
            if (this.count <= this.skipCount)
            {
                return false;
            }

            if (this.yieldedCount >= this.count - this.skipCount)
            {
                return false;
            }

            if (this.currentStep == -1)
            {
                this.prev = 1;
                this.current = 0;
                this.currentStep = 0;

                while (this.currentStep < this.skipCount)
                {
                    if (this.current > int.MaxValue - this.prev)
                    {
                        return false;
                    }

                    int next = this.prev + this.current;
                    this.prev = this.current;
                    this.current = next;
                    this.currentStep++;
                }
            }
            else
            {
                if (this.current > int.MaxValue - this.prev)
                {
                    return false;
                }

                int next = this.prev + this.current;
                this.prev = this.current;
                this.current = next;
                this.currentStep++;
            }

            this.yieldedCount++;
            return true;
        }

        public void Reset()
        {
            this.yieldedCount = 0;
            this.currentStep = -1;
            this.prev = 1;
            this.current = 0;
        }

        public void Dispose()
        {
        }
    }
}
