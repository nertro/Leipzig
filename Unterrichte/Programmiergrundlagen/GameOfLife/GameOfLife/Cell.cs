using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Cell
    {
        protected Vector2 position;
        protected List<Cell> neighbors;
        protected int livingNeighbors;

        public Cell(int x, int y)
        {
            this.position = new Vector2(x, y);
            neighbors = new List<Cell>();
            livingNeighbors = 0;
        }

        public Cell(Vector2 pos) :
            this(pos.X, pos.Y)
        {
        }

        protected void GetNeighbors(Cell[,] currentMap)
        {
            neighbors.Clear();
            neighbors = new List<Cell>();
            Vector2 pos;

            for (int y = this.position.Y - 1; y < this.position.Y + 2; y++)
            {
                for (int x = this.position.X - 1; x < this.position.X + 2; x++)
                {
                    pos = new Vector2(x, y);
                    if (x >= currentMap.GetLength(0))
                    {
                        pos.X = 0;
                    }
                    else if (x < 0)
                    {
                        pos.X = currentMap.GetLength(0) - 1;
                    }

                    if (y >= currentMap.GetLength(1))
                    {
                        pos.Y = 0;
                    }
                    else if (y < 0)
                    {
                        pos.Y = currentMap.GetLength(1) - 1;
                    }
                    if (currentMap[pos.X, pos.Y] != this)
                    {
                        neighbors.Add(currentMap[pos.X, pos.Y]);
                    }
                }
            }
        }

        void CheckNeighbors()
        {
            livingNeighbors = 0;
            foreach (var item in neighbors)
            {
                if (item.GetType() == typeof(LivingCell))
                {
                    livingNeighbors++;
                }
            }
        }

        public virtual void SimulateLife(Cell[,] currentMap, Cell[,] nextMap)
        {
            GetNeighbors(currentMap);
            CheckNeighbors();
        }

        public virtual void DrawCell()
        {
            Console.Write('#');
        }
    }
}
