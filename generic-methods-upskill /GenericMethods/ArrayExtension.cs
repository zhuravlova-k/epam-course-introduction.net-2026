using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GenericMethods.Interfaces;

[assembly: InternalsVisibleTo("GenericMethods.Tests")]

namespace GenericMethods
{
    public static class ArrayExtension
    {
        public static TSource[] Filter<TSource>(this TSource[] source, IPredicate<TSource> predicate)
        {
            if (source is not null)
            {
                ArgumentNullException.ThrowIfNull(predicate);

                if (source.Length == 0)
                {
                    throw new ArgumentException("Array cannot be empty.", nameof(source));
                }

                bool[] matchResults = new bool[source.Length];
                int count = 0;

                for (int i = 0; i < source.Length; i++)
                {
                    matchResults[i] = predicate.IsMatch(source[i]);

                    if (matchResults[i])
                    {
                        count++;
                    }
                }

                TSource[] result = new TSource[count];
                int index = 0;

                for (int i = 0; i < source.Length; i++)
                {
                    if (matchResults[i])
                    {
                        result[index++] = source[i];
                    }
                }

                return result;
            }

            throw new ArgumentNullException(nameof(source));
        }

        public static TResult[] Transform<TSource, TResult>(this TSource[] source, ITransformer<TSource, TResult> transformer)
        {
            ArgumentNullException.ThrowIfNull(source);
            ArgumentNullException.ThrowIfNull(transformer);
            if (source.Length != 0)
            {
                TResult[] result = new TResult[source.Length];
                for (int i = 0; i < source.Length; i++)
                {
                    result[i] = transformer.Transform(source[i]);
                }

                return result;
            }

            throw new ArgumentException("Array cannot be empty.", nameof(source));
        }

        public static TSource[] SortBy<TSource>(this TSource[] source, IComparer<TSource> comparer)
        {
            if (source is not null)
            {
                if (source.Length == 0)
                {
                    throw new ArgumentException("Array cannot be empty.", nameof(source));
                }

                if (comparer is null)
                {
                    for (int i = 0; i < source.Length; i++)
                    {
                        if (source[i] is not IComparable<TSource> && source[i] is not IComparable)
                        {
                            throw new ArgumentNullException(nameof(comparer));
                        }
                    }

                    comparer = Comparer<TSource>.Default;
                }

                TSource[] result = new TSource[source.Length];
                for (int i = 0; i < source.Length; i++)
                {
                    result[i] = source[i];
                }

                for (int i = 0; i < result.Length - 1; i++)
                {
                    for (int j = 0; j < result.Length - i - 1; j++)
                    {
                        if (comparer.Compare(result[j], result[j + 1]) > 0)
                        {
                            Swap(ref result[j], ref result[j + 1]);
                        }
                    }
                }

                return result;
            }

            throw new ArgumentNullException(nameof(source));
        }

        public static TResult[] TypeOf<TResult>(this object[] source)
        {
            ArgumentNullException.ThrowIfNull(source);

            if (source.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.", nameof(source));
            }

            int count = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] is TResult)
                {
                    count++;
                }
            }

            TResult[] result = new TResult[count];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                if (source[i] is TResult item)
                {
                    result[index++] = item;
                }
            }

            return result;
        }

        public static TSource[] Reverse<TSource>(this TSource[] source)
        {
            if (source is not null)
            {
                if (source.Length == 0)
                {
                    throw new ArgumentException("Array cannot be empty.", nameof(source));
                }

                TSource[] result = new TSource[source.Length];
                for (int i = 0; i < source.Length; i++)
                {
                    result[i] = source[i];
                }

                for (int i = 0; i < result.Length / 2; i++)
                {
                    Swap(ref result[i], ref result[result.Length - 1 - i]);
                }

                return result;
            }

            throw new ArgumentNullException(nameof(source));
        }

        internal static void Swap<T>(ref T left, ref T right)
        {
            T temp = left;
            left = right;
            right = temp;
        }
    }
}
