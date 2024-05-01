using System;
namespace MathEvaluation
{
	public class ExpressionEvaluation
	{
        /// <summary>
        /// Calculate prefix expression 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>The result of the prefix expression</returns>
		public static string PrefixEvaluation(string prefix)
		{
			Stack<string> evaluationStack = new();
			//Console.WriteLine("Expression: " + prefix);
			// For loop backward from the end
			for (int i = prefix.Length -1; i >= 0; i--)
			{
				if (char.IsDigit(prefix[i])) evaluationStack.Push(prefix[i].ToString());
				else
				{
					var a = Convert.ToDouble(evaluationStack.Pop());
					var b = Convert.ToDouble(evaluationStack.Pop());

                    evaluationStack.Push(Evaluation(a, b, prefix[i]));
                }
			}
			return evaluationStack.Pop();
		}

        /// <summary>
        /// Calculate postfix expression 
        /// </summary>
        /// <param name="postfix"></param>
        /// <returns>The result of the postfix expression</returns>
		public static string PostFixEvaluation(string postfix)
		{
            Stack<string> evaluationStack = new();
            // For loop forward from the beggining
            for (int i = 0; i < postfix.Length; i++)
            {
                if (char.IsDigit(postfix[i])) evaluationStack.Push(postfix[i].ToString());
                else
                {
                    var b = Convert.ToDouble(evaluationStack.Pop());
                    var a = Convert.ToDouble(evaluationStack.Pop());

                    evaluationStack.Push(Evaluation(a, b, postfix[i]));
                   
                }
            }
            return evaluationStack.Pop();
        }

        /// <summary>
        /// Helper method to check the operation and calculate the expresison
        /// Epression tree
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="operation"></param>
        /// <returns>The result of the expression</returns>
        public static string Evaluation ( double a, double b, char operation)
        {
            switch (operation)
            {
                case '+':
                    return (a + b).ToString();
                case '-':
                    return (a - b).ToString() ;
                case '*':
                    return (a * b).ToString();
                case '/':
                    return (a / b).ToString();
                default:
                    return "";
            }
        }
	}
}

