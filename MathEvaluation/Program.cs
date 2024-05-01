
namespace MathEvaluation;

using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        const string FILE_NAME = "../../../Data/Project 2_INFO_5101.csv";
        const string XML_FILE_NAME = "../../../Data/Project2_INFO_5101_Result.xml";

        List<string> infix = new();
        List<string> postfix = new();
        List<string> postfixResults = new();

        List<string> prefix = new();
        List<string> prefixResults = new();

        CompareExpressions c = new CompareExpressions();
        List<string> compareResults = new();

        try
        { 
            infix = CSVFile.CSVDeserialize(FILE_NAME);               // Get the infix List 
            postfix = InFixToPostFix.InFixPostFix(infix);                    //Get postfix List
            prefix = InFixToPreFix.InFixPreFix(infix);                         // Get prefix List 

            //Calculate postfix value
            postfix.ForEach(e =>

                postfixResults.Add(ExpressionEvaluation.PostFixEvaluation(e))
            );

            //Calculate prefix value
            prefix.ForEach(e =>
            
                prefixResults.Add(ExpressionEvaluation.PrefixEvaluation(e))
            );

            // Compare prefix results and postfix results
            for(int i = 0; i<infix.Count(); i++)
            {
                if (c.Compare(prefixResults.ElementAt(i), postfixResults.ElementAt(i)) == 1)
                    compareResults.Add("True");
                else compareResults.Add("False");
            }

            // Create Summary Report
            Title("Summary Report");
            Headers();
            SummaryReport(infix, prefix, postfix, prefixResults, postfixResults, compareResults);
            Line();

            using (StreamWriter writer = new StreamWriter(XML_FILE_NAME))
            {
                writer.WriteStartDocument();                    // Write the start of the document
                writer.WriteStartRootElement();
                for(int i = 0; i < infix.Count(); i++)
                {
                    writer.WriteStartElement();
                    writer.WriteAttribute("sno", (i + 1).ToString());
                    writer.WriteAttribute("infix", infix[i]);
                    writer.WriteAttribute("prefix", prefix[i]);
                    writer.WriteAttribute("postfix", postfix[i]);
                    writer.WriteAttribute("evaluation", postfixResults[i]);
                    writer.WriteAttribute("comparision", compareResults[i]);
                    writer.WriteEndElement();
                }
                writer.WriteEndRootElement();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File was not found");
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// Print out the formatted body of the report
    /// </summary>
    /// <param name="infix"></param>
    /// <param name="prefix"></param>
    /// <param name="postfix"></param>
    /// <param name="preResults"></param>
    /// <param name="postResults"></param>
    /// <param name="compareResults"></param>
    public static void SummaryReport(List<string> infix, List<string> prefix, List<string> postfix, List<string> preResults, List<string> postResults, List<string> compareResults)
    {
        StringBuilder sb = new StringBuilder(100);
        for(int i = 0; i<infix.Count(); i++)
        {
            sb.Append('|');
            sb.AppendFormat("{0,5}|", i + 1);
            sb.AppendFormat("{0, 20}|", infix[i]);
            sb.AppendFormat("{0, 17}|", postfix[i]);
            sb.AppendFormat("{0, 17}|", prefix[i]);
            sb.AppendFormat("{0, 13}|", preResults[i]);
            sb.AppendFormat("{0, 13}|", postResults[i]);
            sb.AppendFormat("{0, 7}|", compareResults[i]);
            Console.WriteLine(sb);
            sb.Clear();
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Print the headers for each column of the report
    /// </summary>
    public static void Headers()
    {
        StringBuilder sb = new StringBuilder(100);
        sb.Append('|');
        sb.AppendFormat("{0,5}|", "Sno");
        sb.AppendFormat("{0, 20}|", "Infix");
        sb.AppendFormat("{0, 17}|", "Postfix");
        sb.AppendFormat("{0, 17}|", "Prefix");
        sb.AppendFormat("{0, 13}|", "Prefix Res");
        sb.AppendFormat("{0, 13}|", "Postfix Res");
        sb.AppendFormat("{0, 7}|", "Match");
        Console.WriteLine(sb);
        Line();
    }

    /// <summary>
    /// Print the title of the report
    /// </summary>
    /// <param name="title"></param>
    public static void Title(string title)
    {
        Line();
        StringBuilder sb = new StringBuilder(100);
        sb.Append('*');
        sb.Append(' ', (100 - 14) / 2 - 1);
        sb.Append(title);
        sb.Append(' ', 100 - 1 - sb.Length);
        sb.Append('*');
        Console.WriteLine(sb);
        Line();
        Console.WriteLine();

    }

    /// <summary>
    /// Print a seperating line
    /// </summary>
    public static void Line()
    {
        StringBuilder sb = new StringBuilder(100);
        sb.Append('=', 100);
        Console.WriteLine(sb);
    }









}

