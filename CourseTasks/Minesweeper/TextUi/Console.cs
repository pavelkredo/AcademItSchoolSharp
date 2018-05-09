using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Logic;

namespace Minesweeper.TextUi
{
    class Console
    {
        public static void Main(string[] args)
        {
            Model field = new Model(10, 10, 10);

            field.Field();
        }
    }
}
