using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMinMax
{
    class Sector
    {
        public string Name;

        public int X; // of top left corner
        public int Y;

        public int Size; //The sector will always be square

        public bool notEmpty { get; set; }
        public int? Player { get; set; } // 1 for X, 2 for 0, initially empty

        public Sector(string name, int x, int y, int size, bool notempty)
        {
            Name = name;
            X = x;
            Y = y;
            Size = size;
            notEmpty = notempty;
        }
    }
}
