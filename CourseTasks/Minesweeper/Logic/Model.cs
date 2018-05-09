using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Logic
{
    class Model
    {
        public int XSize { get; set; }
        public int YSize { get; set; }
        public int BombCount { get; set; }

        public Model(int xSize, int ySize, int bombCount)
        {
            XSize = xSize;
            YSize = ySize;
            BombCount = bombCount;
        }

        public void Field()
        {
            Random random = new Random();

            List<int[]> bombs = new List<int[]>();

            for (int i = 0; i < BombCount; i++)
            {
                bombs.Add(new int[] { random.Next(0, XSize), random.Next(0, YSize) });
            }
        }
    }
}
