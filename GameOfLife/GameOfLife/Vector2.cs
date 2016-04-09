using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Vector2
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(Vector2 pos)
            : this(pos.X, pos.Y)
        { }
    }
}
