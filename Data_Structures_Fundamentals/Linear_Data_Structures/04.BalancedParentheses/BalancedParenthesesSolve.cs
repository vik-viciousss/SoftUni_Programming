namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < parentheses.Length; i++)
            {
                if (parentheses[i] == '{' || parentheses[i] == '[' || parentheses[i] == '(')
                {
                    stack.Push(parentheses[i]);
                }
                else if (parentheses[i] == '}' || parentheses[i] == ']' || parentheses[i] == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    if (parentheses[i] == '}')
                    {
                        if (stack.Peek() != '{')
                        {
                            return false;
                        }
                        stack.Pop();
                    }
                    else if (parentheses[i] == ']')
                    {
                        if (stack.Peek() != '[')
                        {
                            return false;
                        }
                        stack.Pop();
                    }
                    else if (parentheses[i] == ')')
                    {
                        if (stack.Peek() != '(')
                        {
                            return false;
                        }
                        stack.Pop();
                    }
                }
            }
            
            return stack.Count == 0;
        }
    }
}
