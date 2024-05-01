using System;
using System.Collections.Generic;
using System.IO;

namespace MathEvaluation
{
    public class CSVFile
    {

        /// <summary>
        /// Deserialize the CSV file to get the data
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>A list of infix expressions</returns>
        public static List<string> CSVDeserialize(string filePath)
        {
            List<string> InFix = new List<string>();
            try
            {
                // Use StreamReader to read CSV file
                using (var reader = new StreamReader(filePath))
                {
                    string? line = "";
                    // While still have next line
                    while ((line = reader.ReadLine()) != null)
                    {       
                        string[] values = line.Split(',');  // Split by ','
                        InFix.Add(values[1]);               // Add the expression to InFiz list
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            InFix.RemoveAt(0);                  // Remove InFix header for easy use
            return InFix;
        }
    }
}

