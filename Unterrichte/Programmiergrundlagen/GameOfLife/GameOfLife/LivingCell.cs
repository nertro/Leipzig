using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class LivingCell : Cell
    {
        public LivingCell(int x, int y)
            : base(x, y)
        { }

        public LivingCell(Vector2 pos)
            : base(pos)
        { }

        public override void SimulateLife(Cell[,] currentMap, Cell[,] nextMap)
        {
            base.SimulateLife(currentMap, nextMap);

            if (livingNeighbors < 2 || livingNeighbors > 3)
            {
                nextMap[this.position.X, this.position.Y] = new DeadCell(this.position);
            }
        }

        public override void DrawCell()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            base.DrawCell();
        }
    }
}
