// Stack and Heap
// 1. The stack is a region of memory that stores temporary variables created by each method call,
//    like local variables and references. E.g. local variables in a method are stored on the stack
//    and are removed when the method exits. It operates sequentially, in a last-in, first-out (LIFO) manner,
//    meaning the last item added is the first one to be removed. That is a region of memory used
//    for dynamic memory allocation, where objects are created and destroyed at runtime. On the heap eveything is
//    accessible at once through pointers by the handles references. As long as objects on the heap have a reference
//    they are active and can remain in memory. When they don't have a reference anymore they are put in
//    garbage collection queue to be cleaned up later by the garbage collector and can not be accessed anymore.
//    The stack is used for static memory allocation, where the size of the data is known at compile time.
//    Variables stored on the stack are automatically deallocated when they go out of scope. 
//
// 2. Value types are types from System.ValueType and are normally stored directly on the stack.
//    They can also be stored on the heap when it is a part of a reference-type object.
//    Reference types are types that inherit from System.Object (or are System.Object.object)
//    and are stored on the heap.
//
// 3. In the first method the variables x and y are of type int which is a value type.
//    At y = x, the value of x is copied to y, while they are still independent values. 
//    In the second method, y and x are created as separate references to objects of type MyInt.
//    At y = x in this method, the x reference is copied to y and then both y and x is pointing to
//    the same object. So when we change the value of y, it also changes the value of x. 

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice\n"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    Console.Write("\nInput here: ");
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<string> theList = new List<string>();

            Console.WriteLine("=========================================");
            Console.WriteLine("Examine a List");
            Console.WriteLine("=========================================\n\n");
            Console.WriteLine("Add and remove strings to the list.\n" +
                "Prefix the value you want to add to the list with +, or prefix with - to remove it. " +
                 "Start your input with q if you want to quit to main menu.\n");

            while (true)
            {
                Console.Write("Input here: ");

                string input = Console.ReadLine() ?? string.Empty;
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case 'q':
                        return;
                    case '+':
                        theList.Add(value);
                        Console.WriteLine($"\nList count: {theList.Count()}");
                        Console.WriteLine($"List capacity: {theList.Capacity}");
                        Console.WriteLine($"Current list content: {string.Join(", ", theList)}\n");
                        break;
                    case '-':
                        bool isSuccess = theList.Remove(value);
                        Console.WriteLine(isSuccess ?
                           $"Removed '{value}'." :
                           $"'{value}' not found in list.");
                        Console.WriteLine($"\nList count: {theList.Count()}");
                        Console.WriteLine($"List capacity: {theList.Capacity}");
                        Console.WriteLine($"Current list content: {string.Join(", ", theList)}\n");
                        break;
                    default:
                        Console.WriteLine("\nStart your input with either + or -, or q if you want to quit to main menu.\n");
                        break;
                }
            }
        }

        // Task 1
        //
        // 1. See above.
        //
        // 2. The capacity of the list (the size of the underlying array) increases when the
        // number of items exceeds the current capacity.
        //
        // 3. When the capacity increases, it doubles in size.
        //
        // 4. When the capacity increases the array get copied into a bigger array.
        // That is an expensive operation and is balanced by instead only copy when the list
        // outgrows its capacity.
        //
        // 5. No, the capacity does not decrease as the items in the list get removed, even when
        // the capacity is increased since before. It is because decreasing it requires as expensive
        // operation as increasing it. Then it is better performance-wise to keep the list current
        // capacity because it might increase to that again. It is possible to shrink the capacity
        // by using TrimExcess if really needed.
        //
        // 6. It is advantageous to use arrays over lists when the exact size is known beforehand
        // and it never changes (like days of the week). Arrays are faster and use less memory than
        // lists. Use lists when there is a need to add/remove, because it is easier to work with
        // on lists and that is often worth the tiny extra performance cost. It is possible set the
        // starting capacity to a list to avoid resizing.

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        /// 


        static void ExamineQueue()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Queue<string> theQueue = new Queue<string>();

            Console.WriteLine("=========================================");
            Console.WriteLine("Examine a Queue");
            Console.WriteLine("=========================================\n\n");
            Console.WriteLine("An interactive queue simulation!\n" +
                "To add a person to the queue, input + and follow with the name of the person.\n" +
                 "Input - to make the first person get expedited, satisfied and leave the queue\n" +
                 "Exit to main menu by inputting q.");


            while (true)
            {
                Console.Write("Input here: ");

                string input = Console.ReadLine() ?? string.Empty;
                char nav = input[0];
                string value = input[1..];

                switch (nav)
                {
                    case 'q':
                        return;
                    case '+':
                        theQueue.Enqueue(value);
                        Console.WriteLine($"\nQueue count: {theQueue.Count()}");
                        Console.WriteLine($"Current queue content: {string.Join(", ", theQueue)}\n");
                        break;
                    case '-':
                        theQueue.Dequeue();
                        Console.WriteLine($"\nQueue count: {theQueue.Count()}");
                        Console.WriteLine($"Current queue content: {string.Join(", ", theQueue)}\n");
                        break;
                    default:
                        Console.WriteLine("\nStart your input with either + or -, or q if you want to quit to main menu.\n");
                        break;
                }
            }
        }

        // Task 2
        //
        // 1.
        //
        //    a. Starts with an empty cashier queue.
        //       CashierQueue[]
        //
        //    b. Kalle enters the queue.
        //       Enqueue(Kalle)
        //       CashierQueue[Kalle]
        //
        //    c. Greta enters the queue.
        //       Enqueue(Greta)
        //       CashierQueue[Kalle, Greta]
        //
        //    d. Kalle get expedited and leaves the queue.
        //       Dequeue()
        //       CashierQueue[Greta]
        //
        //    e. Stina enters the queue.
        //       Enqueue(Stina)
        //       CashierQueue[Greta, Stina]
        //
        //    f. Greta get expedited and leaves the queue.
        //       Dequeue()
        //       CashierQueue[Stina]
        //
        //    g. Olle enters the queue.
        //       Enqueue(Olle)
        //       CashierQueue[Stina, Olle]
        //
        //    h. Sonny enters the queue.
        //       Enqueue(Sonny)
        //       CashierQueue[Stina, Olle, Sonny]
        //
        //    i. Stina get expedited and leaves the queue.
        //       Dequeue()
        //       CashierQueue[Olle, Sonny]
        //    ...
        //
        // 2. See code implementation above.


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        //static void ExamineStack()
        //{
        //    /*
        //     * Loop this method until the user inputs something to exit to main menue.
        //     * Create a switch with cases to push or pop items
        //     * Make sure to look at the stack after pushing and and poping to see how it behaves
        //    */

        //    Console.Clear();
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    Stack<string> theStack = new Stack<string>();
        //    bool isEditStack = true;

        //    Console.WriteLine("=========================================");
        //    Console.WriteLine("Examine a Stack");
        //    Console.WriteLine("=========================================\n\n");
        //    Console.WriteLine("An interactive stack simulation!\n" +
        //        "To add a person to the stack, input + and follow with the name of the person.\n" +
        //         "Input - to make the first person get expedited, satisfied and leave the stack\n" +
        //         "Exit to main menu by inputting q.");


        //    while (true)
        //    {
        //        Console.Write("Input here: ");

        //        string input = Console.ReadLine() ?? string.Empty;
        //        char nav = input[0];
        //        string value = input[1..];

        //        switch (nav)
        //        {
        //            case 'q':
        //                return;
        //            case '+':
        //                theStack.Push(value);
        //                Console.WriteLine($"\nQueue count: {theStack.Count()}");
        //                Console.WriteLine($"Current queue content: {string.Join(", ", theStack)}\n");
        //                break;
        //            case '-':
        //                theStack.Pop();
        //                Console.WriteLine($"\nQueue count: {theStack.Count()}");
        //                Console.WriteLine($"Current queue content: {string.Join(", ", theStack)}\n");
        //                break;
        //            default:
        //                Console.WriteLine("\nStart your input with either + or -, or q if you want to quit to main menu.\n");
        //                break;
        //        }
        //    }
        //}

        static void ExamineStack()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("=========================================");
            Console.WriteLine("Examine a Stack");
            Console.WriteLine("=========================================\n\n");
            Console.WriteLine("An interactive stack simulation!\n" +
                "To reverse a text, input r followed by the text you want to reverse and press Enter.\n" +
                 "Exit to main menu by inputting q and pressing Enter.");


            while (true)
            {
                Console.Write("\nInput here: ");
                string input = Console.ReadLine() ?? string.Empty;
                char nav = input[0];
                string value = input[1..];

                switch (nav)
                {
                    case 'q':
                        return;
                    case 'r':
                        Console.WriteLine($"\nReversed text:\n{ReverseText(value)}\n");
                        break;
                    default:
                        Console.WriteLine("\nInput r followed by a text to reverse, or q if you want to quit to main menu.\n");
                        break;
                }

            }

        }

        static string ReverseText(string text)
        {
            Stack<char> theCharStack = new Stack<char>();

            foreach (char c in text)
            {
                theCharStack.Push(c);
            }

            //StringBuilder sb = new StringBuilder();
            //while (theCharStack.Count > 0)
            //{
            //    sb.Append(theCharStack.Pop());
            //}
            //return sb.ToString();

            return new string(theCharStack.ToArray());
        }

        // Task 3
        //
        // 1.
        //
        //    a. Starts with an empty cashier queue.
        //       CashierQueue[]
        //
        //    b. Kalle enters the queue.
        //       Push(Kalle)
        //       CashierQueue[Kalle]
        //
        //    c. Greta enters the queue.
        //       Push(Greta)
        //       CashierQueue[Greta, Kalle]
        //
        //    d. Greta get expedited and leaves the queue.
        //       Pop()
        //       CashierQueue[Kalle]
        //
        //    e. Stina enters the queue.
        //       Push(Stina)
        //       CashierQueue[Stina, Kalle]
        //
        //    f. Stina get expedited and leaves the queue.
        //       Pop()
        //       CashierQueue[Kalle]
        //
        //    g. Olle enters the queue.
        //       Push(Olle)
        //       CashierQueue[Olle, Kalle]
        //
        //    h. Sonny enters the queue.
        //       Push(Sonny)
        //       CashierQueue[Sonny, Olle, Kalle]
        //
        //    i. Sonny get expedited and leaves the queue.
        //       Pop()
        //       CashierQueue[Olle, Kalle]
        //    ...
        //
        //    Using Stack for a queue is a bad idea because then the first person entering the queue is the one
        //    that gets expedited last. Which goes against the cashier queue rules where the first person entering
        //    the queue should get help first.
        //
        // 2. See code implementation above.

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            var stack = new Stack<char>();
            var pairs = new Dictionary<char, char> { { ')', '(' }, { '}', '{' }, { ']', '[' } };
            bool isValid = true;

            Console.WriteLine("=========================================");
            Console.WriteLine("CheckParanthesis");
            Console.WriteLine("=========================================\n\n");
            Console.WriteLine("Input a string and press enter to check if the parentheses in the string are well-formed");
            Console.WriteLine("Exit to main menu by inputting q and pressing Enter.");

            while (true)
            {
                Console.Write("Input here: ");
                string input = Console.ReadLine() ?? string.Empty;

                if (input.Trim() == "q")
                    return;
                else
                    foreach (char c in input)
                    {
                        if (c == '(' || c == '{' || c == '[')
                        {
                            stack.Push(c);
                        }
                        else if (pairs.ContainsKey(c))
                        {
                            if (stack.Count == 0 || stack.Pop() != pairs[c])
                            {
                                isValid = false;
                                break;
                            }
                        }
                    }

                isValid = isValid && stack.Count == 0;

                Console.WriteLine($"\nResult: " +
                    $"{(isValid ? "Success" : "Fail")}. " +
                    $"The string '{input}' has its parentheses " +
                    $"{(isValid ? "well-formed." : "is not well-formed, make sure to edit it!")}\n");
            }
        }

        // Task 4
        //
        // 1. The method CheckParanthesis will check the string character by character. When there is an opening bracket it
        // will register it in a data structure. When a closing bracket appears, it check with the last entry in the registry
        // to see if that is an equivalent match. If they match well, it passes on to check characters in the same way through
        // the string. If the brackets does not match, it does not pass and break the check. Then tells the user that the
        // string is not well-formed. If it reaches through the string with all brackets matching well and no leftovers, then
        // it tells the user that the string is well-formed. Because I need to check with the last entry in the registred
        // brackets, Stack is the most convenient datastructure to use with its First-In-Last-Out (FILO) principle.
        //
        // 2. See code implementation above.
    }
}

