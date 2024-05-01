using System;
using System.Collections;

namespace MathEvaluation
{
	public class CompareExpressions : IComparer
	{
        /// <summary>
        /// Override the compare method to compare two results of postfix and prefix expression
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object? x, object? y)
        {
            if (x!.Equals(y)) return 1;
            else return 0;
        }
    }
}

