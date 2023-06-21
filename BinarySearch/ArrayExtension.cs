﻿using System;
using System.Collections.Generic;

namespace BinarySearch
{
    public static class ArrayExtension
    {
        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using
        /// the System.IComparable generic interface implemented by each element of the
        /// System.Array and by the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional, zero-based System.Array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <returns>The index of the specified value in the specified array, if value is found; otherwise, a negative number.</returns>
        /// <exception cref="ArgumentException">Throw when <paramref name="value"/> is of a type that is not compatible with the elements of array.</exception>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="array"/> is null.</exception>
        public static int BinarySearch<T>(this T[]? array, T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array),"The array is null.");
            }

            return BinarySearch(array, value, Comparer<T>.Default);
        }

        /// <summary>
        /// Searches an entire one-dimensional sorted array for a specific element, using
        /// the System.IComparable generic interface implemented by each element of the
        /// System.Array and by the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="array">The sorted one-dimensional, zero-based System.Array to search.</param>
        /// <param name="value">The object to search for.</param>
        /// <param name="comparer">The System.Collections.Generic.IComparer implementation to use when comparing elements.
        /// -or- null to use the Default implementation of each element.</param>
        /// <returns>The index of the specified value in the specified array, if value is found; otherwise, a negative number.</returns>
        /// <exception cref="ArgumentException">Throw when <paramref name="value"/> is of a type that is not compatible with the elements of array.</exception>
        /// <exception cref="ArgumentNullException">Throw when <paramref name="array"/> is null.</exception>
        public static int BinarySearch<T>(this T[]? array, T value, IComparer<T>? comparer)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array),"The array is null.");
            }

            comparer ??= Comparer<T>.Default;
            int low = 0;
            int high = array.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int comparison = comparer.Compare(array[mid], value);

                if (comparison == 0)
                {
                    return mid;
                }

                if (comparison < 0)
                {
                    low = mid + 1;
                }

                else
                {
                    high = mid - 1;
                }
            }

            return -1;
        }
    }
}
