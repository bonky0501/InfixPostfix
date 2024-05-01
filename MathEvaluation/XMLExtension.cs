using System;
using System.IO;
using System.Text;
namespace MathEvaluation
{
	public static class XMLExtension
	{
        /// <summary>
        /// Write the start of XML Document
        /// </summary>
        /// <param name="writer"></param>
		public static void  WriteStartDocument(this StreamWriter writer)
		{
		    writer.WriteLine( "<?xml version=\"1.0\" encoding=\"UTF-8\"?>"); 
		}

        /// <summary>
        /// Write the start root of the XML document
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="root"></param>
		public static void WriteStartRootElement(this StreamWriter writer, string root = "root")
		{
            writer.WriteLine($"<{root}>");
		}

        /// <summary>
        /// Write the end root of the XML document
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="root"></param>
        public static void WriteEndRootElement(this StreamWriter writer, string root = "root")
        {
            writer.WriteLine($"</{root}>");
        }

        /// <summary>
        /// Write the start element of the XML document
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="element"></param>
        public static void WriteStartElement(this StreamWriter writer, string element = "element")
        {
            writer.WriteLine($"\t<{element}>");
        }

        /// <summary>
        /// Write the end element of the XML document
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="element"></param>
        public static void WriteEndElement(this StreamWriter writer, string element = "element")
        {
            writer.WriteLine($"\t</{element}>");
        }

        /// <summary>
        /// Write the attribute and value to the XML Document
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="attr"></param>
        /// <param name="value"></param>
        public static void WriteAttribute(this StreamWriter writer, string attr, string value)
        {
            writer.WriteLine($"\t\t<{attr}>{value}</{attr}>");
        }


    }
}

