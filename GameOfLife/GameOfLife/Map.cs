using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Map
    {
        int size;
        public Cell[,] currentMap, nextMap;

        public Map(int size)
        {
            this.size = size;
            currentMap = new Cell[size, size];
        }

        public void Init(List<Vector2> livingPositions)
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    currentMap[x, y] = new DeadCell(x, y);
                }
            }

            if (livingPositions.Count < currentMap.Length && livingPositions.Count > 0)
            {
                foreach (var vector in livingPositions)
                {
                    currentMap[vector.X, vector.Y] = new LivingCell(vector);
                }
            }

            //SimmulateFirstGen();

            nextMap = (Cell[,])currentMap.Clone();
        }

        void SimmulateFirstGen()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    currentMap[x, y].SimulateLife(currentMap, currentMap);
                }
            }
        }

        public void Simmulate()
        {
            nextMap = (Cell[,])currentMap.Clone();

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    currentMap[x, y].SimulateLife(currentMap, nextMap);
                }
            }
        }

        public void DrawMap()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    nextMap[x, y].DrawCell();
                }

                Console.WriteLine();
            }

            currentMap = (Cell[,])nextMap.Clone();
        }
    }
}
