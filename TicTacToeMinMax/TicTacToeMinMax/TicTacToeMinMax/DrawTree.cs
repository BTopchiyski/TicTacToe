using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TicTacToeMinMax
{
    class DrawTree
    {
        //DrawTheTree first determines how the Panel will be devided. Width is devided depending on the ammount of missing spots in node.Board
        //Each devided Width sector will be redevided in Heigth depending on the ammount of Children
        //The max ammount of Children the nodes have in a sector will determine our Board.Size(); For eg. mainNode.Children.Count = 4; each of the 4Children.Count = 3 => 12 devisions. 12xBoard = PanelHeigth
        // Adds node.Children to a list. List[i] determines which layer the child is.
        // ListMaxCount will determine our figure size by finding the maximum ammount of elements in a X sector.
        public void DrawTheTree(
            Node node,
            int PanelWidth,
            int PanelHeight,
            Graphics graphics,
            string TreeMethod)
        {
            // X or Width devisions \\
            int xDevisions = 1; // We start at 1, because we must display the initial node!
            for (int i = 0; i < node.Board.GetLength(0); i++)
            {
                for (int k = 0; k < node.Board.GetLength(1); k++)
                {
                    if (node.Board[i, k] == 0)
                        xDevisions++;
                }
            }

            LinkedList<List<Node>> LevelInfo = new LinkedList<List<Node>>(); // Every list represents a layer in itself. In this way we know in which sector to draw.
            List<Node> node0 = new List<Node>();
            node0.Add(node); // Adds initial Node
            LevelInfo.AddLast(node0);

            int Layer = 1;
            GetLevelInformation(LevelInfo, node0, node.Children.Count + 1, Layer); // Adds the other nodes into the List. Now we can draw them.

            // Getting figure size, initiazing pens\\
            int elementsInSector = ListMaxCount(LevelInfo); // Max elements in a sector
            int figureSize = PanelHeight / elementsInSector;



            //Drawing\\
            Pen MainNodePen = new Pen(Color.FromArgb(66, 135, 245), 1); //Blue
            Pen LostPen = new Pen(Color.FromArgb(255, 0, 81), 1); //RedPen
            Pen WinPen = new Pen(Color.FromArgb(3, 252, 107), 1); //GreenPen
            Pen RegularPen = new Pen(Color.Black, 1); // Black
            List<Pen> Pens = new List<Pen>();
            Pens.Add(MainNodePen);
            Pens.Add(LostPen);
            Pens.Add(WinPen);
            Pens.Add(RegularPen);


            for (int c = 0; c < LevelInfo.Count; c++) // Goes trough every list of elements
            {
                List<Node> currentNodes = LevelInfo.ElementAt(c);

                int yDevisions = currentNodes.Count;
                int xMiddleOfSector = (c * PanelWidth / xDevisions) + ((PanelWidth / xDevisions - figureSize) / 2); // For example - first sector is from 0pixels to panelWidth / sectors.

                for(int i = 0; i < yDevisions; i ++)
                {
                    int yLocationSector = (i * PanelHeight / yDevisions) + ((PanelHeight / yDevisions - figureSize) / 2 );
                    Point topLeftCorner = new Point(xMiddleOfSector, yLocationSector);

                    if (c == 0) // First node is painted in blue
                    {
                        DrawFigure(graphics, Pens, topLeftCorner, currentNodes[i], figureSize - 6, 0, TreeMethod); // Draws the Node.Board to a location;
                    }
                    else
                    { 
                         DrawFigure(graphics, Pens, topLeftCorner, currentNodes[i], figureSize - 6, 1, TreeMethod);          
                    }

                }

            }

            //The figures and their elements have been drawn. Now we have the information needed to build the arrows;
            BuildArrows(LevelInfo, graphics, Pens[3]);

            
            MainNodePen.Dispose();
            LostPen.Dispose();
            WinPen.Dispose();
            RegularPen.Dispose();
        }
        public void GetLevelInformation( // List of lists for drawing and max elements
            LinkedList<List<Node>> nodeInfo,
            List<Node> node,
            int ChildrenCount,
            int layer)
        {
            for (int i = layer; i < ChildrenCount; i++)
            {
                List<Node> currentChildren = new List<Node>(); //Current layer's list.

                for (int k = 0; k < node.Count; k++) // Goes trough every child in our layer
                {
                    for (int j = 0; j < node[k].Children.Count; j++)
                    {
                        currentChildren.Add(node[k].Children[j]); // Fills current list
                    }
                }
                nodeInfo.AddLast(currentChildren); // Adds next list to our LinkedList

                if (layer <= ChildrenCount) //Creates desired ammount of lists for layering
                {
                    GetLevelInformation(nodeInfo, currentChildren, ChildrenCount, layer + 1);

                    i = ChildrenCount; // Recursion has ended;
                }

            }
        }
        public int ListMaxCount(LinkedList<List<Node>> nodeInfo)
        {
            int maxElements = 0;
            for(int i = 0; i < nodeInfo.Count; i++)
            {
                List<Node> currentMax = nodeInfo.ElementAt(i);
                if(maxElements < currentMax.Count)
                {
                    maxElements = currentMax.Count;
                }
            }

            return maxElements;
        }
        //Turns the node's board into a drawing in a specific spot. Adds the drawn node's location
        public void DrawFigure(
            Graphics graphics,
            List<Pen> Pens,
            Point point,
            Node node,
            int figureSize,
            int FirstNode,
            string TreeMethod)
        {
            //DrawGrid\\
            int oneThird = figureSize / 3;
            int WhichPen = 0;

            if (FirstNode == 0)
            {
                WhichPen = 0;
            }
            else
            {
                if (node.Value == 0 && node.Children.Count > 0 || node.Value != 0 && node.Children.Count != 0) // Node with children, not an end node.
                {
                    WhichPen = 3;
                }
                if (node.Value == 1 && node.Children.Count == 0) // End node, Win
                {
                    WhichPen = 2;
                }
                if (node.Value == -1 && node.Children.Count == 0) // End Node, Lost
                {
                    WhichPen = 1;
                }
                if(node.Value == 0 && node.Children.Count == 0)
                {
                    WhichPen = 3;
                }
            }

            //DrawGrid\\
            if (TreeMethod == "MinMaxGrid")
            {
                graphics.DrawLine(Pens[WhichPen], point.X + oneThird, point.Y, point.X + oneThird, point.Y + figureSize);
                graphics.DrawLine(Pens[WhichPen], point.X + oneThird * 2, point.Y, point.X + oneThird * 2, point.Y + figureSize);

                graphics.DrawLine(Pens[WhichPen], point.X, point.Y + oneThird, point.X + figureSize, point.Y + oneThird);
                graphics.DrawLine(Pens[WhichPen], point.X, point.Y + oneThird * 2, point.X + figureSize, point.Y + oneThird * 2);
            }
            else if( TreeMethod == "MinMaxValue")
            {
                graphics.DrawEllipse(Pens[WhichPen], point.X, point.Y, figureSize, figureSize);
            }





            //DrawElements\\
            if (TreeMethod == "MinMaxGrid")
            {
                for (int i = 0; i < node.Board.GetLength(0); i++) //Y
                {
                    for (int k = 0; k < node.Board.GetLength(1); k++)//X
                    {

                        if (node.Board[i, k] == 1)
                        {
                            //drawX
                            int topLeftCornerX = point.X + oneThird * k + oneThird / 10;
                            int topLeftCornerY = point.Y + oneThird * i + oneThird / 10;

                            int Length = oneThird - oneThird / 10 * 2;

                            int bottomRightCornerX = topLeftCornerX + Length;
                            int bottomRightCornerY = topLeftCornerY + Length;

                            graphics.DrawLine(Pens[WhichPen], topLeftCornerX, topLeftCornerY, bottomRightCornerX, bottomRightCornerY);
                            graphics.DrawLine(Pens[WhichPen], topLeftCornerX + Length, topLeftCornerY, topLeftCornerX, bottomRightCornerY);

                        }
                        else if (node.Board[i, k] == 2)
                        {
                            //drawO
                            int topLeftCornerX = point.X + oneThird * k + oneThird / 15;
                            int topLeftCornerY = point.Y + oneThird * i + oneThird / 15;
                            int bottomLeftCornerX = oneThird - oneThird / 15 * 2;
                            int bottomLeftCornerY = oneThird - oneThird / 15 * 2;
                            graphics.DrawEllipse(Pens[WhichPen], topLeftCornerX, topLeftCornerY, bottomLeftCornerX, bottomLeftCornerY); //Determins x and y proportionally.

                        }
                        else { }

                        //Will add starting and ending point for an arrow. A new function will be called after all the figures have been drawn in order for the information to be aquired;
                        if (i == 1 && k == 0)
                        {
                            Point End = new Point();

                            End.X = point.X + figureSize;
                            End.Y = point.Y + figureSize / 2;

                            node.DrawnLocationEnd = End;
                        }
                        if (i == 1 && k == 2)
                        {
                            Point Beginning = new Point();

                            Beginning.X = point.X;
                            Beginning.Y = point.Y + figureSize / 2;

                            node.DrawnLocationBeginning = Beginning;
                        }
                    }
                }
            }
            else if (TreeMethod == "MinMaxValue")
            {
                string Val = node.Value.ToString();
                Font myFont = new Font("Calibri", figureSize/5);

                Point TextLocation = new Point(
                    point.X + figureSize/2 - figureSize/5,
                    point.Y + figureSize/2 - figureSize/5);

                SolidBrush WhichBrush = new SolidBrush(Color.White);
                WhichBrush.Color = Pens[WhichPen].Color;

                graphics.DrawString(Val, myFont, WhichBrush, TextLocation);

            }
        }

        public void BuildArrows(
            LinkedList<List<Node>> LevelInfo,
            Graphics graphics,
            Pen pen)
        {
            AdjustableArrowCap CustomArrow = new AdjustableArrowCap(4, 4);
            pen.CustomEndCap = CustomArrow;

            for (int i = 0; i < LevelInfo.Count; i++)
            {
                List<Node> BranchBeginning = LevelInfo.ElementAt(i); //Gets father nodes
                List<Node> BranchEnding = new List<Node>();

                if (i + 1 < LevelInfo.Count)
                {
                    BranchEnding = LevelInfo.ElementAt(i + 1); //Gets child nodes
                }
                else
                {
                    break;
                }

                for(int j = 0; j < BranchBeginning.Count; j++) // If there is a father - draws line
                {
                    for(int z = 0; z < BranchEnding.Count; z++)
                    {
                        if(BranchBeginning.ElementAt(j).Children.Contains(BranchEnding.ElementAt(z))) // If the father has a son
                        {
                            graphics.DrawLine(pen, BranchBeginning.ElementAt(j).DrawnLocationEnd, BranchEnding.ElementAt(z).DrawnLocationBeginning);
                        }
                    }
                }
            }

        }
    }
}
