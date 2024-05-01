using System;
namespace MathEvaluation
{
	public class InFixToPreFix
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

		public static string ReverseExpression(string expression)
		{
			string? result = "";
			for(int i = expression.Length - 1;  i >= 0; i--)
			{
				if (expression[i] == '(')
					result += ')';
				else if (expression[i] == ')')
					result += '(';
				else result += expression[i];
			}
			return result;
		}

        /// <summary>
        /// Method to convert Infix notation to Prefix notation
        /// </summary>
        /// <param name="InFix"></param>
        /// <returns>A list of Prefix notation</returns>
        public static  List<string> InFixPreFix(List<string> InFix)
		{
			List<string> PreFix = new();

			try
			{
				// Create a new Stack to store each value in the expression
				Stack<char> operatorStack = new();
				Stack<char> tempOperand = new();

				// For each expression in InFix List
				InFix.ForEach(infix => {
					string? prefix = "";
					string reversedExpression = ReverseExpression(infix);

					// Run a loop based on reversed expression length
					for (int i = 0; i < reversedExpression.Length; i++)
					{
						// Check if the value is operand, then add to temporary Operand stack
						if (isDigit(reversedExpression[i]))
							prefix += reversedExpression[i];

						// If it is left parenthese, push to the Expression stack
						else if (reversedExpression[i] == '(')
							operatorStack.Push('(');

						// If it is right parenthese, pop the top of the stack to prefix expression
						// until meeting left parenthese
						else if (reversedExpression[i] == ')')
						{
							while (operatorStack.Peek() != '(')
								prefix += operatorStack.Pop();
									
							// Remove left parenthese
							operatorStack.Pop();
						}

						// If it is operator
						else
						{
							// Check what if the tempExpression is empty
							if (operatorStack.Count != 0)
							{
								// Check if the last value in tempExpression is an operator
								if (isOperator(operatorStack.Peek()))
								{
									// if the priority of current operator is lower or equal
									while (operatorStack.Count() > 0 && getPriority(reversedExpression[i]) < getPriority(operatorStack.Peek()))
										prefix += operatorStack.Pop();

                                    // Push the operator to the stack
                                    operatorStack.Push(reversedExpression[i]);
								}
							}
							else operatorStack.Push(reversedExpression[i]);
						}
                    }
                    // Pop all remaining operator to prefix expression
                    while (operatorStack.Count != 0)
                        prefix += operatorStack.Pop();

					PreFix.Add(ReverseExpression(prefix));
                });
			}
			catch(IndexOutOfRangeException i)
			{
				Console.WriteLine(i.Message);
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			return PreFix;
		}
	}
}

