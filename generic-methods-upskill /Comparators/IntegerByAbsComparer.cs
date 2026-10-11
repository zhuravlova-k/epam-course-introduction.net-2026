using System;
using System.Collections.Generic;

namespace Comparators;

public class IntegerByAbsComparer : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return Math.Abs((long)x).CompareTo(Math.Abs((long)y));
    }
}
