using System;
using System.Linq;

namespace Stack_ProblemThree
{
    class Program
    {
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();

            string commandInput = Console.ReadLine();

            while (commandInput != "END")
            {
                string[] commandData = commandInput.Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries);
                string command = commandData[0];

                switch (commandData[0])
                {
                    case "Push":
                        for (int i = 1; i < commandData.Length; i++)
                        {
                            stack.Push(int.Parse(commandData[i]));
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }

                        break;
                    default:
                        break;
                }

                commandInput = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
