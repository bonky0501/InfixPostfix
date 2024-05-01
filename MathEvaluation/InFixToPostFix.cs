using System;
namespace MathEvaluation
{
	public class InFixToPostFix
	{
        /// <summary>
        /// Helper method checking if a char in the expression is a digit
        /// </summary>
        /// <param name="ch"></param>
        /// <returns>True of char is a digit, False if it is not</returns>
        public static bool isDigit(char ch)
        {
            if (ch >= '0' && ch <= '9') return true;
            return false;
        }

        /// <summary>
        /// Helper method checking if a char is an operator
        /// </summary>
        /// <param name="ch"></param>
        /// <returns>True of char is an operator, False if it is not</returns>
        public static bool isOperator(char ch)
        {
            return (!isDigit(ch));
        }

        /// <summary>
		/// Helper method to get the priority of the operator
		/// </summary>
		/// <param name="ch"></param>
		/// <returns>An integer detemine the priority of the operator</returns>
        public static int getPriority(char ch)
        {
            if (ch == '-' || ch == '+')
                return 1;
            else if (ch == '*' || ch == '/')
                return 2;
            else if (ch == '^')
                return 3;

            return 0;
        }

        /// <summary>
        /// Method to convert Infix notation to Postfix notation
        /// </summary>
        /// <param name="InFix"></param>
        /// <returns>A list of Postfix notation</returns>
        public static List<string> InFixPostFix(List<string> InFix)
        {
            List<string> PostFix = new();
            try
            {
                // Create a new Stack to store each value in the expression
                Stack<char> operatorStack = new();

                // For each expression in InFix List
                InFix.ForEach(infix =>
                {
                    string? postfix = "";

                    // Run a loop for each expression based in its length
                    for (int i = 0; i < infix.Length; i++)
                    {
                        // If the value at index i is an operand, add to the new prefix output
                        if (isDigit(infix[i]))
                            postfix += infix[i];

                        // If it is left parenthese, push to the stack
                        else if (infix[i] == '(')
                            operatorStack.Push('(');

                        // If it is right parenthese, pop the top of the stack to prefix expression
                        // until meeting left parenthese
                        else if (infix[i] == ')')
                        {
                            while (operatorStack.Peek() != '(')
                                postfix += operatorStack.Pop();

                            // Remove left parenthese
                            operatorStack.Pop();
                        }

                        // If it is Operator found
                        else
                        {
                            // Check what if the tempExpression is empty
                            if (operatorStack.Count != 0)
                            {
                                // Check if the last value in tempExpression is an operator
                                if (isOperator(operatorStack.Peek()))
                                {
                                    // if the priority of current operator is lower or equal
                                    while (operatorStack.Count() > 0 &&  getPriority(infix[i]) <= getPriority(operatorStack.Peek()))
                                        postfix += operatorStack.Pop();

                                    // Push the operator to the stack
                                    operatorStack.Push(infix[i]);
                                }
                            }
                            else operatorStack.Push(infix[i]); // Push the operator to the stack
                        }
                    }
                    // Pop all remaining operator in tempExpression to postfix expression
                    while (operatorStack.Count != 0)
                            postfix += operatorStack.Pop();

                    PostFix.Add(postfix);
                });
            }
            catch (IndexOutOfRangeException i)
            {
                Console.WriteLine(i.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return PostFix;
        }
    }
}

