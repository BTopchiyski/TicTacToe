using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TicTacToeMinMax
{
	public partial class GameField : Form
	{
		static List<Sector> sectors = new List<Sector>(); // Can be accessed without an instance of the form; - static

		DrawBoard drawBoard = new DrawBoard(0, 0, sectors);

		static Node currentNode = new Node(); //Used to transfer information from GameField to TreeField;

		FrezeGame frezeGame = new FrezeGame(); //Used to freeze an AI's turn;
		public static Node GetCurrentNode() // Usefull in TreeField.cs
        {
			return currentNode;
        }

		int Turn = 1;
		bool EndOfGame = false;
		bool IsGameStarted = false;

		public GameField()
		{
            InitializeComponent();

			Playerbox.SelectedIndex = 0; //Default player : X;

			drawBoard.BoardLocation = GamePanel.Location; // determins Canvas
			drawBoard.BoardHeight = GamePanel.Height;
			drawBoard.BoardWidth = GamePanel.Width;

			CreateSectors(); //Loads sectors

		}
		public void CreateSectors() 
		{
			int oneThird = Math.Min(GamePanel.Height, GamePanel.Width) / 3;
			int numeration = 0;
			for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
					Sector s = new Sector("sector" + numeration, k * oneThird, i * oneThird, oneThird, false);
					sectors.Add(s);
					numeration++;
				}
            }
		}
		private void ClearButton_Click(object sender, EventArgs e)
		{
			GamePanel.Invalidate(); // Clears Panel
			sectors.Clear(); // Clears sectors

			Turns.Text = "1";
			Turn = 1;
			EndOfGame = false;

			IsGameStarted = false;
			Playerbox.Enabled = true;

			currentNode = new Node();

			frezeGame.Active = false;
			frezeGame.nextPlayer = "";
			frezeGame.hasPlayed = false;

			CreateSectors();

		}

        private void GamePanel_MouseDown(object sender, MouseEventArgs e)
        {
			IsGameStarted = true;
			if (!EndOfGame)
			{

				string EndResult = "";
				Point e1 = new Point(e.X, e.Y);

				if (PvPButton.Checked)
				{
					int playerIndex = Playerbox.SelectedIndex + 1;

					Graphics graphics = GamePanel.CreateGraphics();

					Node node = new Node();
					int[,] nodeBoard = new int[3,3];

					if (Turn % 2 != 0)
					{
						drawBoard.DrawFigure(graphics, e1, playerIndex, ref Turn);

						nodeBoard = Mechanics.BuildBoard(sectors); // Turns the sectors into a board
						node.Board = nodeBoard;

						EndOfGame = Mechanics.CheckGameStatusPvAI_PvP(node, Turn, playerIndex, ref EndResult, PvPButton.Checked); // Checks if the node has a value. If it does - there is a winner
					}
					else
					{
						int notPlayer = playerIndex == 1 ? 2 : 1;

						drawBoard.DrawFigure(graphics, e1, notPlayer, ref Turn);

						nodeBoard = Mechanics.BuildBoard(sectors);
						node.Board = nodeBoard;

						EndOfGame = Mechanics.CheckGameStatusPvAI_PvP(node, Turn, notPlayer, ref EndResult, PvPButton.Checked); 
					}

					node.Value = Mechanics.Winner(nodeBoard); //Looks for a winner

					Turns.Text = Turn.ToString(); // Increases turns

					currentNode = node;
					graphics.Dispose();
				}
				else // PvAIButton.Checked
				{

						int playerIndex = Playerbox.SelectedIndex + 1; // Gets player's index X/O
						Graphics graphics = GamePanel.CreateGraphics();

						int SectorEdit = 0;

						if (frezeGame.Active && frezeGame.nextPlayer == "Player" || !frezeGame.Active)
						SectorEdit = drawBoard.DrawFigure(graphics, e1, playerIndex, ref Turn);

						int[,] nodeBoard = Mechanics.BuildBoard(sectors);

						if (SectorEdit != -1 || frezeGame.nextPlayer == "AI") //AI clicks in a fake spot
						{
							

							Node node = new Node();
							node.Board = nodeBoard;
							node.LastEditedSector = SectorEdit;
								
							if(!frezeGame.Active)
							{
							Mechanics.GrowTree(node, playerIndex, playerIndex);
							currentNode = node;
							EndOfGame = Mechanics.CheckGameStatusPvAI_PvP(node, Turn, playerIndex, ref EndResult, PvPButton.Checked); // Checks game for a winner
							}
							else if (frezeGame.Active && frezeGame.nextPlayer == "Player") // If we have a turn left and it is our turn
							{
							Mechanics.GrowTree(node, playerIndex, playerIndex);
							currentNode = node;
							EndOfGame = Mechanics.CheckGameStatusPvAI_PvP(node, Turn, playerIndex, ref EndResult, PvPButton.Checked);

							frezeGame.nextPlayer = "NotThePlayer"; // Will make clicking the board by the player impossible untill the AI has been unFrozen;
							frezeGame.hasPlayed = true; // Avoids crashing the code by clicking the button without having played

							}

							if (!EndOfGame && !frezeGame.Active || // Won't continue if game has ended
							!EndOfGame && frezeGame.nextPlayer == "AI") 
							{
							// AI's turn \\
								Node minNode = new Node();

								if (frezeGame.Active)
                                   {
									minNode = currentNode.Children[0];
								}
                                else
								{
								minNode = node.Children[0];
								}

								for (int i = 1; i < node.Children.Count; i++)
								{
									if (minNode.Value > node.Children[i].Value)
										minNode = node.Children[i];

								}

								Point e2 = new Point();
								e2.X = sectors[minNode.LastEditedSector].X;
								e2.Y = sectors[minNode.LastEditedSector].Y; // Gets sector location for painting

								drawBoard.DrawFigure(graphics, e2, playerIndex == 1 ? 2 : 1, ref Turn); // Draws AI's choice.

								EndOfGame = Mechanics.CheckGameStatusPvAI_PvP(minNode, Turn, playerIndex, ref EndResult, PvPButton.Checked);

								currentNode = minNode;
									
							}
							
						
						}

						graphics.Dispose();

				}

				// After the game has been played, if a result has ben aquired - draws it.
				if(EndOfGame && Turn != 10)
                {
					Graphics graphics = GamePanel.CreateGraphics();

					drawBoard.DrawEndResult(graphics, EndResult, sectors);  //function string-draw

					graphics.Dispose();
				}


			}
			else
			{
				MessageBox.Show("Game has ended. Please clear the field.");
			}				

		}

        private void GamePanel_Paint(object sender, PaintEventArgs e)
        {
			//Load Board
			Graphics graphics = GamePanel.CreateGraphics();
			drawBoard.BoardLocation = GamePanel.Location; // Get top corner

			drawBoard.DrawInitialBoard(graphics); // Draw initial Grid
			graphics.Dispose();
			//

		}

        private void Playerbox_Click(object sender, EventArgs e)
        {
			if (IsGameStarted)
			{
				Playerbox.Enabled = false; // Cannot edit which player you are during a game.
			}
		}

        private void OpenTreeForm_Click(object sender, EventArgs e)
        {
			if (PvPButton.Checked)
			{
				MessageBox.Show("Function is disabled against another player.\nPlease select PvAI to use.");
			}
			else
			{
				if (currentNode.Children.Count == 0)
				{
					MessageBox.Show("No game field to grow from :(");
				}
				else if (currentNode.Children.Count >= 5)
				{
					MessageBox.Show("Too many branches, I will break :(");
				}
				else if (currentNode.Children.Count <= 1)
				{
					MessageBox.Show("Only 1 branch left. Too obvious :D");
				}
				else
				{
					Form TreeField = new TreeField();
					TreeField.ShowDialog();

                }
			}
		}

        private void PvAIButton_CheckedChanged(object sender, EventArgs e) // Clears the board when we switch from PvP to PvAI and vice versa.
        {
			ClearButton_Click(sender, e);
		}

        private void FreezeButton_Click(object sender, EventArgs e)
        {
			if (PvAIButton.Checked)
			{


				if (frezeGame.Active == false) //Freezes next turn
				{
					frezeGame.Active = true;
					frezeGame.nextPlayer = "Player";
				}
				else //Unfreezes game
				{
					if (frezeGame.hasPlayed)
					{
						frezeGame.nextPlayer = "AI";
						MouseEventArgs click = new MouseEventArgs(MouseButtons.Left, 1, -1, -1, 0);
						GamePanel_MouseDown(sender, click);

						frezeGame.Active = false;
						frezeGame.nextPlayer = "";
					}
                    else
                    {
						frezeGame.nextPlayer = "";
						frezeGame.Active = false;
					}
				}
            }
			else
			{
				MessageBox.Show("Only in availiable in PvAI");
			}
        }
    }
}
