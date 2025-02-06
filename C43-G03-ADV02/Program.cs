using System.Collections;

namespace C43_G03_ADV02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //goto j;

            #region Question 1
            //1. Given an array consists of numbers with size N and number of
            //   queries, in each query you will be given an integer X, and you should
            //   print how many numbers in array that is greater than X.
            {
                Console.Write("Enter Size of Array: ");
                int arrSize = int.Parse(Console.ReadLine()!);
                int[] randomInts = Helper.GenerateRandomArray(arrSize, 1, 20);

                LineBreak();

                Console.WriteLine("Random Array Generated:");
                Console.Write("  ");
                randomInts.PrintList();

                LineBreak();

                Console.WriteLine("Enter Number of Queries: ");
                int queryNumbers = int.Parse(Console.ReadLine()!);
                int queryResult;
                int count;

                for (int i = 0; i < queryNumbers; i++)
                {
                    Console.Write($"Input Query #{i + 1} Result: ");
                    queryResult = int.Parse(Console.ReadLine()!);
                    count = 0;

                    for (int j = 0; j < arrSize; j++)
                    {
                        if (randomInts[j] > queryResult)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"Count of Numbers greater than {queryResult}: {count} time{(count > 1 ? "s" : "")}");
                    LineBreak();
                }
            }
            #endregion

            LineBreak(3);

            #region Question 2
            //2. Given a number N and an array of N numbers. Determine if it's palindrome or not.
            {
                Console.Write("Enter Array Size: ");
                int arrSize = int.Parse(Console.ReadLine()!);

                LineBreak();

                Console.WriteLine($"Random Array Generated ({(arrSize % 2 == 0 ? "even" : "odd")}): ");
                int[] numbers = Helper.GeneratePalindromArray(arrSize);
                numbers.PrintList();
                Console.WriteLine($"Is Generated Array Palindrome: {(Helper.IsPalindrome(numbers) ? "Yes" : "No")}");

                LineBreak();

                Console.WriteLine($"Random Array Generated ({(++arrSize % 2 == 0 ? "even" : "odd")}): ");
                numbers = Helper.GeneratePalindromArray(arrSize);
                numbers.PrintList();
                Console.WriteLine($"Is Generated Array Palindrome: {(Helper.IsPalindrome(numbers) ? "Yes" : "No")}");

                LineBreak();

                Console.WriteLine("Random Array Generated: ");
                int[] numbers2 = Helper.GenerateRandomArray(arrSize, 1, 20);
                numbers2.PrintList();
                Console.WriteLine($"Is Generated Array Palindrome: {(Helper.IsPalindrome(numbers2) ? "Yes" : "No" )}");

            }
            #endregion

            LineBreak(3);

            #region Question 3
            //3. Given a Queue, implement a function to reverse the elements of a queue using a stack.
            {
                Console.Write("Enter Queue Length: ");
                int size = int.Parse(Console.ReadLine()!);

                Queue<int> queue = new Queue<int>();
                Stack<int> stack = new Stack<int>();

                for (int i = 1; i <= size; i++)
                {
                    queue.Enqueue(Helper.GenerateRandomNumber(1,size * 2));
                }

                Console.WriteLine("Queue Elements: ");
                queue.PrintList();

                while (queue.Count > 0)
                {
                    stack.Push(queue.Dequeue());
                }

                while (stack.Count > 0)
                {
                    queue.Enqueue(stack.Pop());
                }

                LineBreak();

                Console.WriteLine("Queue Elements After Reversing: ");
                queue.PrintList();
            }
            #endregion

            LineBreak(3);

            #region Question 4
            //4. Given a Stack, implement a function to check if a string of parentheses is balanced using a stack.
            {
                Console.Write("Enter a String of Parentheses: ");
                string input = Console.ReadLine()!;
                Console.WriteLine($"{(Helper.IsParanthesisBalanced(input) ? "Balanced" : "Not balanced")}");
            }
            #endregion

            LineBreak(3);

            #region Question 5
            //5.Given an array, implement a function to remove duplicate elements from an array.
            {
                int[] numbersWithDuplicates = [5, 1, 1, 2, 3, 4, 2, 6, 3, 7, 8, 3, 9, 10];

                Console.WriteLine("Array with Duplicates: ");
                numbersWithDuplicates.PrintList();

                HashSet<int> hashSet = new HashSet<int>();
                List<int> numbersWithoutDuplicates = new List<int>();
                foreach (int number in numbersWithDuplicates)
                {
                    if (hashSet.Add(number))
                    {
                        numbersWithoutDuplicates.Add(number);
                    }
                }

                LineBreak();

                Console.WriteLine("Array without Duplicates: ");
                numbersWithoutDuplicates.PrintList();

            }
            #endregion

            LineBreak(3);

            #region Question 6
            //6. Given an array list , implement a function to remove all odd numbers from it.
            {
                List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                Console.WriteLine("Array List with Odd Numbers:");
                numbers.PrintList();

                numbers.RemoveAll(n => n % 2 != 0);
                
                LineBreak();

                Console.WriteLine("Array List without Odd Numbers:");
                numbers.PrintList();

            }
            #endregion

            LineBreak(3);
            
            #region Question 7
            //7. Implement a queue that can hold different data types.
            //   And insert the following data:
            //     queue.Enqueue(1)
            //     queue.Enqueue("Apple")
            //     queue.Enqueue(5.28)
            {
                Queue<object> queue = new Queue<object>();
                queue.Enqueue(1);
                queue.Enqueue("Apple");
                queue.Enqueue(5.28);

                Console.WriteLine("Queue Elements: ");
                queue.PrintList("\n - ", prefix: " - ", suffix: "");
            }
            #endregion

            LineBreak(3);
            
            #region Question 8
            //8. Create a function that pushes a series of integers onto a stack. Then,
            //   search for a target integer in the stack. If the target is found, print a
            //   message indicating that the target was found, how many elements were
            //   checked before finding the target (ex: "Target was found successfully and
            //   the count = 5"). If the target is not found, print a message indicating that
            //   the target was not found(ex: "Target was not found").
            //
            //   Note : take the target as input from the user
            {
                Console.Write("Enter Target Number (1 to 10): ");
                int target = int.Parse(Console.ReadLine()!);

                LineBreak();

                Stack<int> stack = new Stack<int>();
                for (int i = 1; i <= 10; i++)
                {
                    stack.Push(i);
                }

                Console.WriteLine("Stack Elements: ");
                stack.PrintList();

                LineBreak();

                int count = 0;
                foreach (int number in stack)
                {
                    count++;
                    if (number == target)
                    {
                        Console.WriteLine($"Target was found successfully and the count = {count}");
                        break;
                    }
                }
                if (count == stack.Count)
                {
                    Console.WriteLine("Target was not found");
                }

            }
            #endregion

            LineBreak(3);
        
            #region Question 9
            //9. Given two arrays, find their intersection. Each element in the result should appear as many times as it shows in both arrays.
            //  Ex :
            //  Input :
            //      5 , 3
            //      [1,2,3,4,4] , [10,4,4]
            //  Output :
            //      [4,4]
            {
                int[] arr1 = [1, 2, 2, 3, 5, 5, 6, 7];
                int[] arr2 = [2, 2, 3, 5, 7, 7];
                List<int> result = new List<int>();

                for (int i = 0; i < arr1.Length; i++)
                {
                    for (int j = 0; j < arr2.Length; j++)
                    {
                        if (arr1[i] == arr2[j])
                        {
                            result.Add(arr1[i]);
                            break;

                        }
                    }
                }

                LineBreak();

                Console.WriteLine("Intersection of Two Arrays: ");
                result.PrintList();
            }
            #endregion

            LineBreak(3);

            #region Question 10
            //10. Given an ArrayList of integers and a target sum, find if there is a contiguous sub list that sums up to the target.
            //Ex :
            //Input:
            //  [1, 2, 3, 7, 5]
            //  12
            //Output:
            //  [2, 3, 7]
            {

                ArrayList numbers = new ArrayList { 1, 2, 3, 7, 5 };

                Console.WriteLine("Elements: ");
                numbers.ToArray().PrintList();

                int target = 12;
                int sum = 0;
                bool matchFound = false;

                List<int> result = new List<int>();

                //forward iteration
                //   0  1  2  3  4 length = 5
                //  [1, 2, 3, 7, 5]
                //  [_, 2, 3, 7, 5]
                //  [_, _, 3, 7, 5]
                //  [_, _, _, 7, 5]
                //  [_, _, _, _, 5]
                for (int i = 0; i < numbers.Count; i++)
                {
                    sum = (int)numbers[i]!;
                    result.Clear();
                    result.Add((int)numbers[i]!);

                    for (int j = i + 1; j < numbers.Count; j++)
                    {
                        sum += (int)numbers[j]!;
                        result.Add((int)numbers[j]!);

                        if (sum == target)
                        {
                            matchFound = true;
                            break;
                        }
                    }

                    if (sum == target)
                    {
                        matchFound = true;
                        break;
                    }
                }

                //reverse iteration
                //   0  1  2  3  4 length = 5
                //  [1, 2, 3, 7, 5]
                //  [1, 2, 3, 7, _]
                //  [1, 2, 3, _, _]
                //  [1, 2, _, _, _]
                //  [1, _, _, _, _]
                //but first iteration is repeated in the forward iteration
                //then start from the second last element
                if (!matchFound)
                {
                    for (int i = numbers.Count - 2; i >= 0; i--)
                    {
                        sum = (int)numbers[i]!;
                        result.Clear();
                        result.Add((int)numbers[i]!);

                        for (int j = i - 1; j >= 0; j--)
                        {
                            sum += (int)numbers[j]!;
                            result.Add((int)numbers[j]!);

                            if (sum == target)
                            {
                                matchFound = true;
                                break;
                            }
                        }
                        if (sum == target)
                        {
                            matchFound = true;
                            break;
                        }
                    }
                }

                if (matchFound)
                {
                    Console.WriteLine("Sub List Found: ");
                    result.PrintList();
                }
                else
                {
                    Console.WriteLine("Sub List Not Found");
                }

            }
            #endregion

            LineBreak(3);

            #region Question 11
            //11. Given a queue reverse first K elements of a queue, keeping the remaining elements in the same order
            {
                Queue<int> queue = new Queue<int>();
                for (int i = 1; i <= 10; i++)
                {
                    queue.Enqueue(i);
                }

                Console.WriteLine("Queue Elements: ");
                queue.PrintList();

                LineBreak();

                int k = 5;
                Stack<int> stack = new Stack<int>();

                for (int i = 0; i < k; i++)
                {
                    stack.Push(queue.Dequeue());
                }

                while (stack.Count > 0)
                {
                    queue.Enqueue(stack.Pop());
                }

                for (int i = 0; i < queue.Count - k; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }

                Console.WriteLine("Queue Elements After Reversing First 5 Elements: ");
                queue.PrintList();
            }
            #endregion
        }

        public static void LineBreak(int count = 1) => Console.Write(new string('\n', count));
    }
}