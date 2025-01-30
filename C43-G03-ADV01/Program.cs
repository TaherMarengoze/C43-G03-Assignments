using System.Collections;

namespace C43_G03_ADV01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LineBreak(3);

            #region Question 1
            {
                Console.WriteLine("<< Question 1 >>\n");
                /*
                    1. The Bubble Sort algorithm has a time complexity of O(n^2) in its worst
                    and average cases, which makes it inefficient for large datasets. How we
                    can optimise the Bubble Sort algorithm
                    And implement the code of this optimised bubble sort algorithm

                    By adding a flag to detect if a pass is swapped or not; if a pass and no swap
                    happened then the data is sorted
                 */
                Console.WriteLine("How can the Bubble Sort algorithm be optimised ?");
                Console.WriteLine("By adding a flag for swapping to detect if a pass is swapped or not;\r\nif in a pass and no swap happened then the data is sorted then break out of the loop");

                LineBreak();

                int[] arr = { 64, 34, 25, 12, 22, 11, 90, 77, 87, 54, 29, 1, 16 };
                Console.WriteLine($"Unsorted Array:\n {string.Join(",", arr)}");

                int n = arr.Length;
                bool swapped;

                for (int i = 0; i < n - 1; i++)
                {
                    swapped = false;

                    // Reduce the range of comparisons after each pass
                    for (int j = 0; j < n - 1 - i; j++)
                    {
                        if (arr[j] > arr[j + 1])
                        {
                            // Swap arr[j] and arr[j + 1]
                            int iTemp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j + 1] = iTemp;

                            swapped = true;
                        }
                    }

                    // If no swaps occurred, the array is already sorted
                    if (!swapped)
                    {
                        break;
                    }
                }

                LineBreak();
                Console.WriteLine($"Bubble sorted Array:\n {string.Join(",", arr)}");
                
                LineBreak();
                Console.WriteLine("".PadRight(50, '='));
            }
            #endregion

            LineBreak(3);

            #region Question 2
            Console.WriteLine("<< Question 2 >>\n");
            
            Range<int> intRange = new(1, 5);
            Console.WriteLine($"Is 0 within Range[1~5]: {intRange.IsInRange(0)}");
            Console.WriteLine($"Is 1 within Range[1~5]: {intRange.IsInRange(1)}");
            Console.WriteLine($"Is 3 within Range[1~5]: {intRange.IsInRange(3)}");
            Console.WriteLine($"Is 5 within Range[1~5]: {intRange.IsInRange(5)}");
            Console.WriteLine($"Is 6 within Range[1~5]: {intRange.IsInRange(6)}");
            Console.WriteLine($"Length of Range[1~5]: {intRange.Length()}");
            Console.WriteLine("".PadRight(40, '-'));
            LineBreak();

            Range<double> dblRange = new(1.5, 8.6);
            Console.WriteLine($"Is 4.3 Within Range[1.5 => 8.6]: {dblRange.IsInRange(4.3)}");
            Console.WriteLine($"Length of Range[1.5 => 8.6]: {dblRange.Length()}");

            LineBreak();
            Console.WriteLine("".PadRight(50, '='));
            #endregion

            LineBreak(3);

            #region Question 3
            // 3. You are given an ArrayList containing a sequence of elements. try to
            // reverse the order of elements in the ArrayList in-place(in the same arrayList)
            // without using the built-in Reverse. Implement a function that
            // takes the ArrayList as input and modifies it to have the reversed order of elements.
            Console.WriteLine("<< Question 3 >>\n");

            ArrayList arrayList = [1, "hamada", true, 5.0 , new Order(9, "Flash Memory", 25)];
            Console.WriteLine("ArrayList before reversing:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            object temp;
            int l = arrayList.Count;

            for (int i = 0; i < l / 2; i++)
            {
                temp = arrayList[i]!;
                arrayList[i] = arrayList[l - 1 - i];
                arrayList[l - 1 - i] = temp;
            }

            LineBreak();

            Console.WriteLine("ArrayList after reversing:");
            foreach (var item in arrayList)
            {
                Console.WriteLine(item);
            }

            LineBreak();
            Console.WriteLine("".PadRight(50, '='));
            #endregion

            LineBreak(3);

            #region Question 4
            // 4. You are given a list of integers. Your task is to find and return
            // a new list containing only the even numbers from the given list.
            {
                Console.WriteLine("<< Question 4 >>\n");

                int[] source = [7, 2, 4, 9, 1, 4, 6, 3, 15, 12, 8];
                int[] evens = new int[source.Length];
                int i = 0;

                Console.WriteLine($"Given these number: {string.Join(",", source)}");

                foreach (int number in source)
                {
                    if (number % 2 == 0)
                    {
                        evens[i++] = number;
                    }
                }

                Console.Write("Even numbers: ");
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"{evens[j]} ");
                }
            }

            LineBreak();
            Console.WriteLine("".PadRight(50, '='));
            #endregion

            LineBreak(3);

            #region Question 5
            Console.WriteLine("<< Question 5 >>\n");
            int addedItemIndex = -1;
            FixedSizeList<Order> cart = new(4);
            addedItemIndex = cart.Add(new Order(1, "Wireless Keyboard", 12));
            Console.WriteLine($"Item Added >> {cart.Get(addedItemIndex)}");

            addedItemIndex = cart.Add(new Order(2, "Optical Mouse", 15));
            Console.WriteLine($"Item Added >> {cart.Get(addedItemIndex)}");

            addedItemIndex = cart.Add(new Order(3, "BluTooth Earpods", 35));
            Console.WriteLine($"Item Added >> {cart.Get(addedItemIndex)}");

            addedItemIndex = cart.Add(new Order(4, "4 sockets USB Hub", 20));
            Console.WriteLine($"Item Added >> {cart.Get(addedItemIndex)}");

            try
            {
                cart.Add(new Order(5, "Laptop", 1300));
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Catched a thrown exception with message '{ex.Message}'\n" +
                    "Because an item was added while the cart is full"
                    );
            }

            LineBreak();

            Console.WriteLine("Retrieve item 3 from the cart:");
            Console.WriteLine(cart.Get(2).ToString());
            
            LineBreak();

            Console.WriteLine("Retrieve item 5 from the cart:");
            try
            {
                Console.WriteLine(cart.Get(4).ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Catched a thrown exception with message '{ex.Message}'\n" +
                    "Because the index of the item being retrieved is out of the capacity of the cart"
                    );
            }
            
            LineBreak();

            Console.WriteLine("".PadRight(50, '='));
            #endregion

            LineBreak(3);

            #region Question 6
            Console.WriteLine("<< Question 6 >>\n");
            // 6. Given a string, find the first non-repeated character in it and return its
            // index. If there is no such character, return -1. Hint you can use dictionary

            string word = "abc abc bcd ae"; //should return d
            PrintFirstNonRepeatedChar(word, FindFirstNonRepeatedChar(word));

            LineBreak(2);

            word = "abc abc abc abc"; //should return none
            PrintFirstNonRepeatedChar(word, FindFirstNonRepeatedChar(word));

            LineBreak();
            Console.WriteLine("".PadRight(50, '='));
            #endregion

            LineBreak(3);

            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }

        public static void LineBreak(int count = 1) => Console.Write(new string('\n', count));

        public static int FindFirstNonRepeatedChar(string text)
        {
            Dictionary<char, int> letters = [];

            char key;

            for (int i = 0; i < text.Length; i++)
            {
                key = text[i];

                if (letters.ContainsKey(key))
                {
                    letters[key] = -1;
                }
                else
                {
                    letters[key] = i;
                }
            }

            foreach (var k in letters.Keys)
            {
                if (letters[k] > -1)
                {
                    return letters[k];
                }
            }

            return -1;
        }

        public static void PrintFirstNonRepeatedChar(string text, int loc)
        {
            if (loc > -1)
            {
                Console.Write(text.Substring(0, loc));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(text[loc]);
                Console.ResetColor();
                Console.Write(text.Substring(loc + 1));
                Console.Write(
                    $"\n * First non-repeated letter: {text[loc]}\n * Located at index {loc}");
            }
            else
            {
                Console.WriteLine(
                    $"'{text}'\n * All letters are repeated");
            }
        }
    }
}
