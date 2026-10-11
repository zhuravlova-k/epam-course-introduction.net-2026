using System;
using System.Runtime.InteropServices;
using GenericMethods.Interfaces;

namespace DoubleTransformer
{
    public class GetIeee754Format : ITransformer<double, string>
    {
        public string Transform(double obj)
        {
            var converter = new DoubleToLongStruct { DoubleValue = obj };
            long bits = converter.LongValue;

            char[] bitString = new char[64];

            for (int i = 0; i < 64; i++)
            {
                bitString[63 - i] = ((bits >> i) & 1) == 1 ? '1' : '0';
            }

            return new string(bitString);
        }

        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct : IEquatable<DoubleToLongStruct>
        {
            [FieldOffset(0)]
            public double DoubleValue;

            [FieldOffset(0)]
            public long LongValue;

            public override bool Equals(object? obj)
            {
                return obj is DoubleToLongStruct other && this.Equals(other);
            }

            public bool Equals(DoubleToLongStruct other)
            {
                return this.LongValue == other.LongValue;
            }

            public override int GetHashCode()
            {
                return this.LongValue.GetHashCode();
            }
        }
    }
}
