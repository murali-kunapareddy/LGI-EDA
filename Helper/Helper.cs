using System.Text;

namespace Analyzer.Helper
{
    /// <summary>
    /// Helper class for various utility functions.
    /// </summary>
    public class Helper
    {
    }

    /// <summary>
    /// Attribute to specify a string value for a member.
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Gets the string value associated with the attribute.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttribute"/> class with the specified string value.
        /// </summary>
        /// <param name="value">The string value to associate with the attribute.</param>
        public StringValueAttribute(string value)
        {
            Value = value;
        }
    }

    public class CSV2HTML
    {
        /// <summary>
        /// Converts a CSV file to an HTML table.
        /// </summary>
        /// <param name="csvFilePath">The path to the CSV file.</param>
        /// <returns>The HTML string representing the table.</returns>
        public static string ConvertGCAnalysisToHtml(string csvPath, string pngPath)
        {
            var html = new StringBuilder();
            html.Append("<table border='1'>");
            using (var reader = new StreamReader(csvPath))
            {
                string[] headers = reader.ReadLine()!.Split(',');
                html.Append("<tr>");
                foreach (var header in headers)
                {
                    html.Append($"<th>{header}</th>");
                }
                html.Append("</tr>");
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line!.Split(',');
                    html.Append("<tr>");
                    foreach (var value in values)
                    {
                        html.Append($"<td>{value}</td>");
                    }
                    html.Append("</tr>");
                }
            }
            html.Append("</table>");
            return html.ToString();
        }
    }
}
