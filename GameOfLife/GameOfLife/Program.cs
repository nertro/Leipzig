using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            float timer = 0;
            float delay = 90000;
            Map map = new Map(10);
            List<Vector2> startPos = new List<Vector2>();
            startPos.Add(new Vector2(1, 1));
            startPos.Add(new Vector2(1, 2));
            startPos.Add(new Vector2(2, 1));
            startPos.Add(new Vector2(4, 3));
            startPos.Add(new Vector2(3, 4));
            startPos.Add(new Vector2(4, 4));

            map.Init(startPos);
            map.DrawMap();

            Console.WriteLine();

            while (true)
            {
                timer += 0.004f;
                if (timer > delay)
                {
                    timer = 0;
                    Console.Clear();
                    map.Simmulate();
                    map.DrawMap();
                }
            }


            Console.Read();
        }
    }
}
