using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTransposition
{
    class Program
    {
        private static readonly TableDimension dim = new(3,5);

        static void Main()
        {
            Encode("0123456789");//Hello World! I love you so much, let's stay in touch.");
        }

        private static void Encode(in string message)
        {
            if (message.Length > dim.x * dim.y)
                throw new ArgumentOutOfRangeException($"The string is too long. Maxmum allowed length = {dim.x * dim.y}, but the string length = {message.Length}");
            
            StringBuilder sb = new();

            for (int i = 0; i != dim.x * dim.y; i++)
            {
                var y = i % dim.y;
                var x = i / dim.y;
                int idx = x * dim.y + y + 1;
                //if(y == 2 && x == 1) // 1 * 5 + 2 + 1 
                // 9 = 5 * 1 + 3 + 1
                Console.WriteLine($"{i} => ({y}, {x}) => {idx}");

                if (idx < message.Length)
                    sb.Append(message[idx]);
            }

            //Console.WriteLine(sb.ToString());

            //var ar = new char[dim.x, dim.y];

            //for (int y = 0; y != dim.y; y++)
            //    for (int x = 0; x != dim.x; x++)
            //    {
            //        int idx = y + x + y * (dim.x - 1);
            //        Console.WriteLine($"({y}, {x}) = {idx}");
            //        if (idx == message.Length)
            //            return;
            //        ar[x, y] = message[idx];
            //    }

            //        return sb.ToString();

            //return sb.ToString();
        }

        private struct TableDimension
        {
            public readonly int x;
            public readonly int y;
            public TableDimension(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }
    }
}
