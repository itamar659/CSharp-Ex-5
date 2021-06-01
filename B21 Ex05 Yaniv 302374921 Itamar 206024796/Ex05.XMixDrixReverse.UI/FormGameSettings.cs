using System.Drawing;
using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    internal class FormGameSettings : Form
    {
        //Row 1
        Label m_LabelPlayers;

        //Row 2
        Label m_LabelPlayer1;
        TextBox m_TextBoxPlayer1;

        //Row 3
        CheckBox m_CheckBoxIsMultiplayer;
        Label m_LabelPlayer2;
        TextBox m_TextBoxPlayer2;

        //Row 4
        Label m_LabelBoardSize;
        
        //Row 5
        Label m_LabelRows;
        NumericUpDown m_NumericUpDownRows;
        Label m_LabelCols;
        NumericUpDown m_NumericUpDownCols;

        //Row 6
        Button m_ButtonStart;


        public FormGameSettings()
        {
            initializeComponents();
        }

        private void initializeComponents()
        {
            //Row 1
            m_LabelPlayers = new Label();
            m_LabelPlayers.AutoSize = true;
            m_LabelPlayers.Text = "Players:";
            m_LabelPlayers.Left = 16;
            m_LabelPlayers.Top = 16;
            this.Controls.Add(m_LabelPlayers);

            //Row 2
            m_LabelPlayer1 = new Label();
            m_LabelPlayer1.AutoSize = true;
            m_LabelPlayer1.Text = "Player 1:";
            m_LabelPlayer1.Left = m_LabelPlayers.Left + 8;
            m_LabelPlayer1.Top = m_LabelPlayers.Top + 32;
            this.Controls.Add(m_LabelPlayer1);

            m_TextBoxPlayer1 = new TextBox();
            m_TextBoxPlayer1.AutoSize = true;
            m_TextBoxPlayer1.Left = m_LabelPlayer1.Left + 75;
            m_TextBoxPlayer1.Top = m_LabelPlayer1.Top - 2;
            this.Controls.Add(m_TextBoxPlayer1);

            //Row 3
            m_CheckBoxIsMultiplayer = new CheckBox();
            m_CheckBoxIsMultiplayer.AutoSize = true;
            m_CheckBoxIsMultiplayer.Left = m_LabelPlayer1.Left;
            m_CheckBoxIsMultiplayer.Top = m_TextBoxPlayer1.Bottom + 8;
            this.Controls.Add(m_CheckBoxIsMultiplayer);

            m_LabelPlayer2 = new Label();
            m_LabelPlayer2.AutoSize = true;
            m_LabelPlayer2.Text = "Player 2:";
            m_LabelPlayer2.Left = m_CheckBoxIsMultiplayer.Left + 20;
            m_LabelPlayer2.Top = m_CheckBoxIsMultiplayer.Top;
            this.Controls.Add(m_LabelPlayer2);

            m_TextBoxPlayer2 = new TextBox();
            m_TextBoxPlayer2.Text = "[Computer]";
            m_TextBoxPlayer2.Enabled = false;
            m_TextBoxPlayer2.AutoSize = true;
            m_TextBoxPlayer2.Left = m_TextBoxPlayer1.Left;
            m_TextBoxPlayer2.Top = m_LabelPlayer2.Top - 3;
            this.Controls.Add(m_TextBoxPlayer2);

            //Row 4
            m_LabelBoardSize = new Label();
            m_LabelBoardSize.AutoSize = true;
            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Left = 16;
            m_LabelBoardSize.Top = m_TextBoxPlayer2.Top + 40;
            this.Controls.Add(m_LabelBoardSize);

            //Row 5
            m_LabelRows = new Label();
            m_LabelRows.AutoSize = true;
            m_LabelRows.Text = "Rows:";
            m_LabelRows.Left = 16;
            m_LabelRows.Top = m_LabelBoardSize.Top + 30;
            this.Controls.Add(m_LabelRows);

            m_NumericUpDownRows = new NumericUpDown();
            m_NumericUpDownRows.AutoSize = true;
            m_NumericUpDownRows.Width = 10;
            m_NumericUpDownRows.Left = m_LabelRows.Left + 50;
            m_NumericUpDownRows.Top = m_LabelRows.Top;
            this.Controls.Add(m_NumericUpDownRows);

            m_LabelCols = new Label();
            m_LabelCols.AutoSize = true;
            m_LabelCols.Text = "Cols:";
            m_LabelCols.Left = m_NumericUpDownRows.Left + 60;
            m_LabelCols.Top = m_LabelRows.Top;
            this.Controls.Add(m_LabelCols);

            m_NumericUpDownCols = new NumericUpDown();
            m_NumericUpDownCols.AutoSize = true;
            m_NumericUpDownCols.Width = 10;
            m_NumericUpDownCols.Left = m_LabelCols.Left + 50;
            m_NumericUpDownCols.Top = m_LabelRows.Top;
            this.Controls.Add(m_NumericUpDownCols);

            //Row 6
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.AutoSize = true;
            m_ButtonStart.Left = 85;
            m_ButtonStart.Top = m_NumericUpDownCols.Top + 35;
            this.Controls.Add(m_ButtonStart);

            this.Text = "Game Settings";
            this.ClientSize = new Size(240, m_ButtonStart.Bottom + 20);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }
    }
}
