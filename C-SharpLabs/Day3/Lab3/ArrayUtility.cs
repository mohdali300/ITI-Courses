using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public static class ArrayUtility
    {
        public static void Reverse(int[] nums)
        {
            int start = 0, end = nums.Length - 1;
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
            Console.WriteLine(string.Join(" ", nums));
        }

        public static void FindMax(int[] nums)
        {
            int max = nums[0];
            foreach (var num in nums)
            {
                if (num > max)
                    max = num;
            }
            Console.WriteLine("Max: " + max);
        }

        public static void FindMin(int[] nums)
        {
            int min = nums[0];
            foreach (var num in nums)
            {
                if (num < min)
                    min = num;
            }
            Console.WriteLine("Min: " + min);
        }

        public static bool IsSorted(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                if (nums[i] > nums[i + 1])
                    return false;
            }
            return true;
        }

        public static int CountOccurrences(int[] nums, int value)
        {
            int count = 0;
            foreach (var num in nums)
            {
                if (num == value)
                    count++;
            }
            return count;
        }

        public static void Merge(int[] arr1, int[] arr2)
        {
            int[] merged = new int[arr1.Length + arr2.Length];
            Array.Copy(arr1, 0, merged, 0, arr1.Length);
            Array.Copy(arr2, 0, merged, arr1.Length, arr2.Length);
            Console.WriteLine(string.Join(" ", merged));
        }
    }
}
