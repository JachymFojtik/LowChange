using System;
using System.Collections.Generic;

namespace LowChange
{

    class Program
    {
        public static Dictionary<int,int> coinCount = new Dictionary<int, int> { {50,0}, { 20, 0 }, { 10, 0 }, { 5, 0 }, { 2, 0 }, { 1, 0 } };
        public static void LowestChange(int x, int y)
        {
            foreach (var item in coinCount) item.Value = 0;
            int back = x - y;
            int high = 50;

            if (back>=1)
            {
                foreach (var item in coinCount)
                {
                    if (back >= item.Key)
                    {
                        high = item.Key;
                        coinCount[item.Key] = back / item.Key;
                        break;
                    }
                }
                LowestChange(x - (back / high)*high, y );
            }
            else
            {
                foreach (var item in coinCount)
                {
                    if (item.Value != 0)
                    {
                        Console.WriteLine($"{item.Value} x {item.Key},-Kč");
                    }
                }
            }

        }
        static void Main(string[] args)
        {
            LowestChange(600,422);
            Console.ReadKey();
        }
    }
}
