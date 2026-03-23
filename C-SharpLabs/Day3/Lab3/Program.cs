using System.Collections.Generic;

namespace Lab3
{
    internal class Program
    {
        #region task 1
        // 1
        private static void Reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        private static void RotateArray(int[] nums, int k)
        {
            k=k % nums.Length;
            Reverse(nums, 0, nums.Length - 1);
            Reverse(nums, 0, k - 1);
            Reverse(nums, k, nums.Length - 1);
        }

        #endregion

        #region task 2
        // 2
        private static int[,] Spiral(int n)
        {
            int top = 0, bottom = n - 1, left = 0, right = n - 1, cnt = 1;
            int[,] arr = new int[n, n];

            while (cnt <= n * n)
            {
                for (int i = left; i <= right; i++)
                {
                    arr[top, i] = cnt++;
                }
                top++;
                for (int i = top; i <= bottom; i++)
                {
                    arr[i, right] = cnt++;
                }
                right--;
                for (int i = right; i >= left; i--)
                {
                    arr[bottom, i] = cnt++;
                }
                bottom--;
                for (int i = bottom; i >= top; i--)
                {
                    arr[i, left] = cnt++;
                }
                left++;
            }
            return arr;
        }
        #endregion

        #region task 3
        // 3
        private static void Triangle(int n)
        {
            int[][] arr = new int[n][];
            for (int i = 0; i < n; i++)
            {
                arr[i] = new int[i + 1];
                arr[i][0] = 1;
                arr[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    arr[i][j] = arr[i - 1][j - 1] + arr[i - 1][j];
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region task 4
        // 4
        private static void BubbleSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        int temp = nums[j];
                        nums[j] = nums[j + 1];
                        nums[j + 1] = temp;
                    }
                }
            }
        }

        private static void SelectionSort(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (nums[j] < nums[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int temp = nums[i];
                nums[i] = nums[minIndex];
                nums[minIndex] = temp;
            }
        }
        #endregion

        #region task 5
        // 5
        private static void VarKeywordLimitations()
        {
            // var x; // error:  must be initialized
            // var y = null; // error: cannot assign null
            // var z = 10; z = 11; // error: cannot assign more than one at a time

            // class MyClass{
            // var a = 10;  // error: cannot use var to declare a class member
            // }

            // var n=n+1; // error: cannot use var in own initialization

            // static var MyMethod() // error: cannot use var as return type
        } 
        #endregion

        #region task 8
        // 8
        private static Dictionary<string, int> Frequency(string s)
        {
            var words = s.ToLower().Split(' ');
            var frequency = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (frequency.ContainsKey(word))
                {
                    frequency[word]++;
                }
                else
                {
                    frequency[word] = 1;
                }
            }
            return frequency;
        } 
        #endregion

        private static void Main(string[] args)
        {
            #region task 1
            //int[] nums;
            //int k;
            //nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //k=int.Parse(Console.ReadLine());
            //RotateArray(nums, k); 

            //foreach (var item in nums)
            //{
            //    Console.Write(item + " ");
            //}
            #endregion

            #region task 2
            //int n = int.Parse(Console.ReadLine());

            //int[,] result = Spiral(n);
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < n; j++)
            //    {
            //        Console.Write(result[i, j] + " ");
            //    }
            //    Console.WriteLine();
            //} 
            #endregion

            #region task 3
            //int n = int.Parse(Console.ReadLine());
            //Triangle(n); 
            #endregion

            #region task 4
            //int[] nums;
            //nums = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            //BubbleSort(nums);
            //foreach (var item in nums)
            //{
            //    Console.Write(item + " ");
            //}

            //SelectionSort(nums);
            //foreach (var item in nums)
            //{
            //    Console.Write(item + " ");
            //} 
            #endregion

            #region task 6
            //BankAccount acc1 = new BankAccount(1, "Ahmed", 5000);
            //BankAccount acc2 = new BankAccount(2, "Sara", 3000);

            //acc1.Deposit(1000);
            //acc1.DisplayInfo(acc1);

            //acc1.Withdraw(500);
            //acc1.DisplayInfo(acc1);

            //acc1.Transfer(acc2, 2000);

            //acc1.DisplayInfo(acc1);
            //acc2.DisplayInfo(acc2); 
            #endregion

            #region task 7
            //ArrayUtility.Reverse(new int[] { 1, 2, 3, 4, 5 });
            //ArrayUtility.FindMax(new int[] { 1, 2, 3, 4, 5 });
            //ArrayUtility.FindMin(new int[] { 1, 2, 3, 4, 5 });
            //Console.WriteLine(ArrayUtility.IsSorted(new int[] { 1, 2, 3, 4, 5 }));
            //Console.WriteLine(ArrayUtility.CountOccurrences(new int[] { 1, 2, 3, 4, 5, 3, 3 }, 3));
            //ArrayUtility.Merge(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }); 
            #endregion

            #region task 8
            string s = Console.ReadLine();
            var freq = Frequency(s).OrderByDescending(x => x.Value);
            foreach (var word in freq)
            {
                Console.WriteLine(word);
            } 
            #endregion
        }
    }
}