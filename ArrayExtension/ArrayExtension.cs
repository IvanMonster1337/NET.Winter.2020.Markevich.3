﻿namespace ArrayExtension
{
    using System;

    /// <summary>
    /// An application entry point.
    /// </summary>
    public static class ArrayExtension
    {
        /// <summary>Finds the index of the "balance" element.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Returns index of element if it exists or null.</returns>
        /// <exception cref="System.ArgumentNullException">Argument is null.</exception>
        /// <exception cref="System.ArgumentException">Array is empty.</exception>
        public static int? FindBalanceIndex(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            if (arr.Length < 3)
            {
                return null;
            }

            long sumBeforeElement;
            long sumAfterElement;
            for (int i = 1; i < arr.Length - 1; i++)
            {
                sumBeforeElement = 0;
                for (int j = 0; j <= i - 1; j++)
                {
                    sumBeforeElement += arr[j];
                }

                sumAfterElement = 0;
                for (int j = i + 1; j <= arr.Length - 1; j++)
                {
                    sumAfterElement += arr[j];
                }

                if (sumBeforeElement == sumAfterElement)
                {
                    return i;
                }
            }

            return null;
        }

        public static int[] FilterArrayByKey(int[] arr, int key)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (key < 0 && key > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Key is out of range");
            }

            if (arr == Array.Empty<int>())
            {
                throw new ArgumentException("Array is empty");
            }

            int buf;
            int[] outArray = Array.Empty<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                do
                {
                    if (Math.Abs(buf % 10) == key)
                    {
                        Array.Resize(ref outArray, outArray.Length + 1);
                        outArray[outArray.Length - 1] = arr[i];
                    }

                    buf /= 10;
                }
                while (buf != 0);
            }

            return outArray;
        }

        /// <summary>Finds the maximum element of an array.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Maximum element of the array.</returns>
        /// <exception cref="ArgumentNullException">Argument is null.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int FindMaximumElement(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Argument is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }

            return MaximumInRange(arr, 0, arr.Length - 1);
        }

        private static int MaximumInRange(int[] arr, int leftNumber, int rightNumber)
        {
            if (leftNumber == rightNumber)
            {
                return arr[rightNumber];
            }
            else
            {
                int leftBuff = MaximumInRange(arr, leftNumber, (leftNumber + rightNumber) / 2);
                int rightBuff = MaximumInRange(arr, ((leftNumber + rightNumber) / 2) + 1, rightNumber);

                return Math.Max(leftBuff, rightBuff);
            }
        }
    }
}
