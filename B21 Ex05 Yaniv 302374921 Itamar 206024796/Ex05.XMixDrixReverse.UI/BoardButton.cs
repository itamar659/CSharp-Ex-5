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
    }
}
