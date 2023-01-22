namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {

            if (parentheses.Length % 2 != 0)
                return false;

            var openParenthes = new Stack<Char>();

            for (int i = 0; i <= parentheses.Length - 1; i++)
            {
                if (IsOpenParenthes(parentheses[i]))
                {
                    openParenthes.Push(parentheses[i]);
                    continue;
                }

                var reversedparenthes = turnAraund(parentheses[i]);

                if (reversedparenthes.Equals(openParenthes.Peek()))
                {
                    openParenthes.Pop();
                }
                else
                {
                    return false;
                }
                    
            }

            return true;
        }

        private char turnAraund(char v)
        {
            switch (v)
            {
                case ')':
                    return '(';
                case '}':
                    return '{';
                case ']':
                    return '[';
                default:
                    return v;
            }
        }

        private bool IsOpenParenthes(char v)
        {
            switch (v)
            {
                case '(':
                case '{':
                case '[':
                    return true;
                default:
                    return false;
            }
        }
    }
}
