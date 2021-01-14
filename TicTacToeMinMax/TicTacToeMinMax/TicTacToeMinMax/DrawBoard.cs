using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TicTacToeMinMax
{
    class DrawBoard
    {
        public Point BoardLocation
        {
            get;
            set;
        }
        public int BoardWidth { get; set; }

        public int BoardHeight { get; set; }

        public int OneThird { get; set; }

        public List<Sector> Sectors;

        public DrawBoard(int boardWidth, int boardHeight, List<Sector> sectors)
        {
            BoardWidth = boardWidth;
            BoardHeight = boardHeight;

            Sectors = sectors;

            OneThird = Math.Min(boardWidth, boardHeight) / 3;
        }

        public void DrawInitialBoard(Graphics graphics)
        {

            using (Pen pen = new Pen(Color.Black, 4)) // to dispose pen afterwards, because it is an Object of Windows
            {
                int oneThird = Math.Min(BoardWidth, BoardHeight) / 3;
                // Draws a bare tic-tac-toe game
                graphics.DrawLine(pen, oneThird, 0, oneThird, BoardHeight);
                graphics.DrawLine(pen, oneThird * 2, 0, oneThird * 2, BoardHeight);

                graphics.DrawLine(pen, 0, oneThird, BoardWidth, oneThird);
                graphics.DrawLine(pen, 0, oneThird * 2, BoardWidth, oneThird * 2);
            }


        }
        public int DrawFigure(
            Graphics graphics,
            Point e,
            int Player,
            ref int Turn)
        {
            int oneThird = Math.Min(BoardWidth, BoardHeight) / 3;
            int canvasSize = oneThird * 8 / 10; // picture size;
            int emptySize = oneThird - canvasSize;


            using (Pen pen = new Pen(Color.Black, 2)) // to dispose pen afterwards, because it is an Object of Windows
            {
                int indexOfSector = DetermineDrawLocation(e, oneThird); // returns top left corner of the sector
                int i = indexOfSector;
                if (Player % 2 != 0 && Sectors[i].notEmpty == false)
                {
                    graphics.DrawLine(pen, Sectors[i].X + emptySize, Sectors[i].Y + emptySize, Sectors[i].X + canvasSize, Sectors[i].Y + canvasSize);
                    graphics.DrawLine(pen, Sectors[i].X + canvasSize, Sectors[i].Y + emptySize, Sectors[i].X + emptySize, Sectors[i].Y + canvasSize);

                    Sectors[i].notEmpty = true;
                    Sectors[i].Player = 1;

                    Turn = Turn + 1;


                }
                else if (Player % 2 == 0 && Sectors[i].notEmpty == false)
                {
                    graphics.DrawEllipse(pen, Sectors[i].X + emptySize / 2, Sectors[i].Y + emptySize / 2, canvasSize, canvasSize);
                    Sectors[i].notEmpty = true;
                    Sectors[i].Player = 2;

                    Turn = Turn + 1;
                }
                else
                {
                    return -1;
                }

                return i;


            }
        }

        public int DetermineDrawLocation(Point e, int oneThird)
        {
            int x = e.X; //this function will determine which sector to draw in, depending on the mouse click location via multiple checks.
            int y = e.Y;

            double sectorX = x / oneThird; // for eg. 180p / 200 = 0,9 => sector 1, sector 2 is >1 & <=2, sector 3 >3, ! int/ int works as Math.Floor!
            double sectorY = y / oneThird; // Then we are interested in the top left corner of a sector

            int index = 0;
            foreach (Sector s in Sectors)                   // Lambda foreach works, but break; cannot be used
            {
                if (s.X == sectorX * oneThird && s.Y == sectorY * oneThird)
                {
                    break;
                }
                else
                {
                    index++;
                }
            }
            return index;


        }

        public void DrawEndResult(
            Graphics graphics,
            string ResultSchypher,
            List<Sector> sectors)
        {
            string[] Information = ResultSchypher.Split(','); // Pen color, Sector , playerIndex

            List<Sector> PaintSectors = new List<Sector>(); // Sector trio
            string SectorCase = Information[1];


            int playerIndex = int.Parse(Information[2]); // Player's shape
            int notPlayerIndex = playerIndex == 1 ? 2 : 1; // AI's shape

            Color backGround = Information[0] == "r" ? Color.FromArgb(255, 0, 81) : Color.FromArgb(3, 252, 107); // Gets background color. Left one is Green, Right one is Red
            Brush backGroundBrush = new SolidBrush(backGround);

            Pen ShapePen = new Pen(Color.Black, 4); // Pen for X and O

            //Which sectors to paint in?
            PaintSectorsSwitch(sectors, PaintSectors, SectorCase); // Switch case that fills PaintSectors with the correct ones to work in.

                foreach(Sector sector in PaintSectors)
            {
                Rectangle rect = new Rectangle(
                    sector.X + sector.Size * 5 / 100,
                    sector.Y + sector.Size * 5 / 100,
                    sector.Size - sector.Size * 10 / 100,
                    sector.Size - sector.Size * 10 / 100);

                graphics.FillRectangle(backGroundBrush, rect);

                sector.notEmpty = false; //Can be reDrawn
                int ReferenceTurn = 0; // Just a counter to fill the function
                DrawFigure(graphics, new Point(rect.X, rect.Y), playerIndex, ref ReferenceTurn);
            }



            backGroundBrush.Dispose();
            ShapePen.Dispose();

        }

        public void PaintSectorsSwitch(List<Sector> sectors, List<Sector> PaintSectors, string SectorCase)
        {
            switch (SectorCase)
            {
                case "s1":
                    PaintSectors.Add(sectors[0]);
                    PaintSectors.Add(sectors[3]);
                    PaintSectors.Add(sectors[6]);
                    break;
                case "s2":
                    PaintSectors.Add(sectors[1]);
                    PaintSectors.Add(sectors[4]);
                    PaintSectors.Add(sectors[7]);
                    break;
                case "s3":
                    PaintSectors.Add(sectors[2]);
                    PaintSectors.Add(sectors[5]);
                    PaintSectors.Add(sectors[8]);
                    break;
                case "s4":
                    PaintSectors.Add(sectors[0]);
                    PaintSectors.Add(sectors[1]);
                    PaintSectors.Add(sectors[2]);
                    break;
                case "s5":
                    PaintSectors.Add(sectors[3]);
                    PaintSectors.Add(sectors[4]);
                    PaintSectors.Add(sectors[5]);
                    break;
                case "s6":
                    PaintSectors.Add(sectors[6]);
                    PaintSectors.Add(sectors[7]);
                    PaintSectors.Add(sectors[8]);
                    break;
                case "s7":
                    PaintSectors.Add(sectors[0]);
                    PaintSectors.Add(sectors[4]);
                    PaintSectors.Add(sectors[8]);
                    break;
                case "s8":
                    PaintSectors.Add(sectors[2]);
                    PaintSectors.Add(sectors[4]);
                    PaintSectors.Add(sectors[6]);
                    break;

                default:
                    MessageBox.Show("Easter Egg Found! Good job!");
                    break;
            }
        }
    }
}
