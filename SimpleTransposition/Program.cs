using System;
using System.Text;

namespace SimpleTransposition
{
    class Program
    {
        private static string theString = "Hello World! I love you so much, let's stay in touch.";

        private static char aVerySpecialCharachter = '~';
        static void Main()
        {
            Console.WriteLine($"->{theString}<-");
            TableDimension dim = new(11, 5);
            var encodedString = Encode(theString, dim);
            Console.WriteLine($"->{encodedString}<-");
            // раскодирую завтра.
            // надеюсь....
        }

        private static string Encode(in string message,in TableDimension dim)
        {
            if (message.Length > dim.size)
                throw new ArgumentOutOfRangeException($"The string is too long. Maxmum allowed length = {dim.size}, but the string's length = {message.Length}");
            
            StringBuilder sb = new();

            for (int i = 0; i != dim.size; i++)
            {
                int idx = dim.y * (i % dim.x) + i / dim.x;

                char v = idx < message.Length ? message[idx]: aVerySpecialCharachter;
                sb.Append(v);
                    
            }

            return sb.ToString();
        }

        // Можно было бы использовать KeyValuePair но свойства Key и Value a little bit confusing in this context
        private struct TableDimension
        {
            public readonly int x;
            public readonly int y;
            public readonly int size;
            public TableDimension(int x, int y)
            {
                this.x = x;
                this.y = y;
                size = x * y;
            }
        }
    }
}
