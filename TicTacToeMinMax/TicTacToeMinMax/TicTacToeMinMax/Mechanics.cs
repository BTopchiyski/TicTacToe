using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMinMax
{
	class Mechanics
	{
		public const int Player1 = 1; // X
		public const int Player2 = 2; // O
		public static Int32 Winner(Int32[,] board)
		{
			//Check if there is a win
			//colum check
			var c1 = board[0, 0] & board[1, 0] & board[2, 0];
			var c2 = board[0, 1] & board[1, 1] & board[2, 1];
			var c3 = board[0, 2] & board[1, 2] & board[2, 2];
			//row check
			var r1 = board[0, 0] & board[0, 1] & board[0, 2];
			var r2 = board[1, 0] & board[1, 1] & board[1, 2];
			var r3 = board[2, 0] & board[2, 1] & board[2, 2];
			//diagonal check
			var d1 = board[0, 0] & board[1, 1] & board[2, 2];
			var d2 = board[0, 2] & board[1, 1] & board[2, 0];


			return
				c1 == 1 ||
				c2 == 1 ||
				c3 == 1 ||
				r1 == 1 ||
				r2 == 1 ||
				r3 == 1 ||
				d1 == 1 ||
				d2 == 1 ? 1 : //If any on the conditions for 1 is met, returns 1;
				c1 == 2 ||    //else checks conditions for 2;
				c2 == 2 ||    //returns 0 if none are met;
				c3 == 2 ||
				r1 == 2 ||
				r2 == 2 ||
				r3 == 2 ||
				d1 == 2 ||
				d2 == 2 ? 2 :
				0;
		}

		public static void GrowTree(
		   Node node,
		   int player, // Who is the player (maximizator or minimizator)
		   int maximizer)
		{
			var checkGameStatus = Winner(node.Board); // Checking if we have a end result;
			if (checkGameStatus != 0)
			{
				node.Value = checkGameStatus == maximizer // If the maximizer wins, then the value is 1, -1 if he lost.
					? 1
					: -1;

				return;
			}

			// Growing the tree and creating new nodes for what is left 0

			for (int i = 0; i < node.Board.GetLength(0); i++)
			{
				for (int k = 0; k < node.Board.GetLength(1); k++)
				{
					if (node.Board[i, k] == 0)
					{
						var newChildNode = new Node();

						Array.Copy(node.Board, newChildNode.Board, node.Board.Length); //copying board info to child
						newChildNode.Board[i, k] = player == 1 ? 2 : 1; // marking new move


						newChildNode.LastEditedSector = i * 3 + k; // which sector is it?
						node.Children.Add(newChildNode);

						//continue TreeGrowth
						GrowTree(
							newChildNode,
							player == Player1 // Switching players
							? Player2
							: Player1,
							maximizer);

						if (node.Value == null
							|| (player == maximizer && node.Value < newChildNode.Value) //checking if we need the new value
							|| (player != maximizer && node.Value > newChildNode.Value)) // depending on which player it is for
						{
							node.Value = newChildNode.Value;

						}
					}
				}
			}

			if (node.Value == null) // No one wins. It is an end node with no value
			{
				node.Value = 0;
			}
		}

		public static int[,] BuildBoard(
			List<Sector> sectors
			)
		{
			int[,] Board = new int[3, 3];
			int CountSector = 0;

			for (int i = 0; i < Board.GetLength(0); i++)
			{
				for (int k = 0; k < Board.GetLength(1); k++)
				{
					if (sectors[CountSector].notEmpty == true)
					{
						Board[i, k] = (int)sectors[CountSector].Player;

					}
					else
					{
						Board[i, k] = 0;
					}
					CountSector++;
				}
			}
			return Board;

		}
		public static bool CheckGameStatusPvP(
			Node node,
			int turns)
		{
			if (node.Value == 1 || node.Value == 2) // Displays status of the game
			{
				if (node.Value == 1)
					MessageBox.Show("X wins!");
				else
					MessageBox.Show("O wins!");

				return true;
			}
			else if (turns == 10)
			{
				MessageBox.Show("Draw!");
				return true;

			}
			else
			{
				return false;
			}
		}
		public static bool CheckGameStatusPvAI_PvP(
			Node node,
			int Turns,
			int playerIndex,
			ref string EndResult,
			bool GameMode)
		{

			Int32[,] board = node.Board;
			int notPlayer = playerIndex == 1 ? 2 : 1;

			if (Turns < 10)
			{
				//Check if there is a win
				//colum check
				var s1 = board[0, 0] & board[1, 0] & board[2, 0];
				var s2 = board[0, 1] & board[1, 1] & board[2, 1];
				var s3 = board[0, 2] & board[1, 2] & board[2, 2];
				//row check
				var s4 = board[0, 0] & board[0, 1] & board[0, 2];
				var s5 = board[1, 0] & board[1, 1] & board[1, 2];
				var s6 = board[2, 0] & board[2, 1] & board[2, 2];
				//diagonal check
				var s7 = board[0, 0] & board[1, 1] & board[2, 2];
				var s8 = board[0, 2] & board[1, 1] & board[2, 0];

				List<int> s = new List<int> { s1, s2, s3, s4, s5, s6, s7, s8 };

				if (s1 == playerIndex ||
				s2 == playerIndex ||
				s3 == playerIndex ||
				s4 == playerIndex ||
				s5 == playerIndex ||
				s6 == playerIndex ||
				s7 == playerIndex ||
				s8 == playerIndex)
				{

                    for (int i = 0; i < 8; i++)
                    {
						if(s[i] == playerIndex)
                        {
							EndResult = "g,s" + (i+1) + "," + playerIndex;
						}
                    }

					if(GameMode)
                    {
						if (playerIndex == 1)
							MessageBox.Show("X wins!");
						else
						{ // O will always be RED color in a PvP situation, where as in PvAI, the AI is Red.
							for (int i = 0; i < 8; i++)
							{
								if (s[i] == playerIndex)
								{
									EndResult = "r,s" + (i + 1) + "," + playerIndex;
								}
							}
							MessageBox.Show("O wins!");
						}

					}
                    else
                    {
						MessageBox.Show("You win!");
					}
					return true;
				}
				if (
				s1 == notPlayer ||
				s2 == notPlayer ||
				s3 == notPlayer ||
				s4 == notPlayer ||
				s5 == notPlayer ||
				s6 == notPlayer ||
				s7 == notPlayer ||
				s8 == notPlayer)
				{

					for (int i = 0; i < 8; i++)
					{
						if (s[i] == notPlayer)
						{
							EndResult = "r,s" + (i + 1) + "," + notPlayer;
						}
					}

						MessageBox.Show("You lost!");

					return true;
				}

			}
			else
			{
				MessageBox.Show("Draw!");
				return true;
			}
			return false;

		}
	}
}
