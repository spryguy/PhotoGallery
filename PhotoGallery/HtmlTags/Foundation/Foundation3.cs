using System.Collections.Generic;

namespace HtmlTags.Foundation
{
    public class Foundation3
    {
        private static readonly Dictionary<int, string> Numbers = new Dictionary<int, string>
            {
                {1, "one"},
                {2, "two"},
                {3, "three"},
                {4, "four"},
                {5, "five"},
                {6, "six"},
                {7, "seven"},
                {8, "eight"},
                {9, "nine"},
                {10, "ten"},
                {11, "eleven"},
                {12, "twelve"}
            };

        public struct Attributes
        {
            public static readonly string Clearing = "clearing";
        }

        public struct Classes
        {
            public static readonly string Row = "row";
            public static readonly string Columns = "columns";
            public static readonly string Centered = "centered";
            public static readonly string BlockGrid = "block-grid";
        }

        public static string GetColumnsCss(int numColumns, bool centered = false)
        {
            return string.Format("{0} {1} {2}", Numbers[numColumns], Classes.Columns, centered ? Classes.Centered : "");
        }

        public static string GetBlockGridColumnsCss(int numColumns, int numMobile = 0)
        {
            return string.Format("{0} {1}-up mobile-{2}-up", Classes.BlockGrid, Numbers[numColumns], Numbers[numColumns]);
        }
    }
}