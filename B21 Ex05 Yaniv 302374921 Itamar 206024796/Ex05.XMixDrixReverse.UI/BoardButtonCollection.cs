using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    internal class BoardButtonCollection : Control
    {
        public event BoardButtonEventHandler ClickSingleButton;

        private BoardButton[,] m_Buttons;

        public Size ButtonOffset { get; set; }
        public Size ButtonSize { get; set; }

        public BoardButtonCollection()
        {
            ButtonOffset = new Size(10, 10);
            ButtonSize = new Size(60, 60);
        }

        protected virtual void OnClickSingleButton(BoardButton i_ClickedButton, BoardButtonArgs e)
        {
            ClickSingleButton?.Invoke(i_ClickedButton, e);
        }

        public void CreateCollection(int i_Width, int i_Height)
        {
            Size buttonMargin = ButtonOffset + ButtonSize;

            m_Buttons = new BoardButton[i_Width, i_Height];

            for (int x = 0; x < i_Width; x++)
            {
                for (int y = 0; y < i_Height; y++)
                {
                    BoardButton button = new BoardButton(x, y);
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = Color.FromArgb(230, 240, 255);
                    button.Size = ButtonSize;
                    button.Left = buttonMargin.Width * x;
                    button.Top = buttonMargin.Height * y;
                    button.Click += buttons_Click;
                    Controls.Add(button);

                    m_Buttons[x, y] = button;
                }
            }

            BackColor = Color.FromArgb(200, 220, 240);
            Size = new Size(i_Width * buttonMargin.Width - ButtonOffset.Width, i_Height * buttonMargin.Height - ButtonOffset.Height);
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            OnClickSingleButton(sender as BoardButton, new BoardButtonArgs(sender as BoardButton));
        }
    }
}
