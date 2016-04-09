using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class DeadCell : Cell
    {
        public DeadCell(int x, int y)
            : base(x, y)
        { }

        public DeadCell(Vector2 pos)
            : base(pos)
        { }

        public override void SimulateLife(Cell[,] currentMap, Cell[,] nextMap)
        {
            base.SimulateLife(currentMap, nextMap);

            if (livingNeighbors == 3)
            {
                nextMap[this.position.X, this.position.Y] = new LivingCell(this.position);
            }
        }

        public override void DrawCell()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            base.DrawCell();
        }
    }
}
