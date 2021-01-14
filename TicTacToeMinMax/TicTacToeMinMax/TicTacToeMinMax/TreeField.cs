using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeMinMax
{
    public partial class TreeField : Form
    {
        public TreeField()
        {
            InitializeComponent();
            TreeBox.SelectedIndex = 0;
        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TreePanel_Paint(object sender, PaintEventArgs e)
        {

            Node node = GameField.GetCurrentNode(); // Get the node which will grow the tree
            int PanelWidth = TreePanel.Width; // Will be used to devide the panel in sectors
            int PanelHeight = TreePanel.Height;
            //Draw Function
            DrawTree Draw = new DrawTree();
            Draw.DrawTheTree(node, PanelWidth, PanelHeight, e.Graphics, TreeBox.SelectedItem.ToString());
        }

        private void TreeBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            TreePanel.Invalidate();
            TreePanel.Update();

        }
    }
}
