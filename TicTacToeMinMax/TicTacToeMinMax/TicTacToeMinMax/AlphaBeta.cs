using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeMinMax
{
    public class AlphaBeta
    {
        public bool willBeDrawn { get; set; }

        public bool isEndNode { get; set; }

        public int yPosition { get; set; }

        public int? totalChildrenAtLayer { get; set; }
    }
}
