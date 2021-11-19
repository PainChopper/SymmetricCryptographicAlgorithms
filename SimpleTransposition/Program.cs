using System;
using System.Text;

namespace SimpleTransposition
{
    class Program
    {
        private static char aVerySpecialCharachter = '\0';
        static void Main()
        {
            const string theMessage = "Hello World! I love you so much, let's stay in touch.";

            TableDimension dim = new(11, 5);
            if (theMessage.Length > dim.size)
                throw new ArgumentOutOfRangeException(
                    $"The string is too long. Maxmum allowed length = {dim.size}, but the string's length = {theMessage.Length}");

            Console.WriteLine($"->{theMessage}<-");

            var encodedMessage = Code(theMessage, dim, 
                (i, height, width) => height * (i % width) + i / width); 
            Console.WriteLine($"->{encodedMessage}<-");

            var decodedMessage = Code(encodedMessage, dim, 
                (i, width, height) => height * (i % width) + i / width);
            Console.WriteLine($"->{decodedMessage}<-");
        }

        private static string Code(in string message, in TableDimension dim, Func<int, int, int, int> formula)
        {
            StringBuilder sb = new();

            for (int i = 0; i != dim.size; i++)
            {
                int idx = formula(i, dim.y, dim.x);

                char v = idx < message.Length ? message[idx] : aVerySpecialCharachter;
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
