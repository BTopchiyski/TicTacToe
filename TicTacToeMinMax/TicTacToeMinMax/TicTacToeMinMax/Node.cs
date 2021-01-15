using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToeMinMax
{
	public class Node
	{
		public List<Node> Children { get; set; } = new List<Node>();

		public int[,] Board { get; set; } = new int[3, 3];

		public int? Value { get; set; } //int? can be null

		public int LastEditedSector {get; set;}

		public Point DrawnLocationBeginning { get; set; } // Will be the beginning point of a arrow => the middle right location of a drawn figure.
		public Point DrawnLocationEnd { get; set; }

		public AlphaBeta MethodAB { get; set; }
	}
}
