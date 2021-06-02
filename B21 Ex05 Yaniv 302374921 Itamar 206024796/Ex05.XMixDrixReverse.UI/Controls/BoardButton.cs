using Ex05.XMixDrixReverse.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    internal class BoardButton : Button
    {
        public Point Position { get; set; }

        public BoardButton(int i_X, int i_Y)
        {
            Position = new Point(i_X, i_Y);
        }

        public void ChangeText(object sender, EventArgs e)
        {
            Text = (sender as Board.BoardItem).Symbol.ToString() ?? string.Empty;

            if ((sender as Board.BoardItem).Symbol != null)
            {
                Enabled = false;
            }
            else
            {
                Enabled = true;
            }
        }
    }
}
