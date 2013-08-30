using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    /// <summary>
    /// Adds several extension methods to the string class.
    /// </summary>
    static class StringExtensions
    {
        /// <summary>
        /// Gets all indexes of a given substring for a string
        /// </summary>
        /// <param name="value">The substring to find</param>
        /// <returns>A list of all indicies for <paramref name="value"/></returns>
        public static List<int> AllIndexesOf(this string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("The string to find must not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        /// <summary>
        /// Gets all indexes of a given substring for a string, ignoring case if ignoreCase.
        /// </summary>
        /// <param name="value">The substring to find</param>
        /// <param name="ignoreCase">If true, ignore case during search</param>
        /// <returns>A list of all indicies for <paramref name="value"/></returns>
        public static List<int> AllIndexesOf(this string str, string value, bool ignoreCase)
        {
            if (!ignoreCase)
            {
                return AllIndexesOf(str, value);
            }
            else
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("The string to find must not be empty", "value");
                List<int> indexes = new List<int>();
                for (int index = 0; ; index += value.Length)
                {
                    index = str.IndexOf(value, index, StringComparison.CurrentCultureIgnoreCase);
                    if (index == -1)
                        return indexes;
                    indexes.Add(index);
                }
            }
        }
    }
}
