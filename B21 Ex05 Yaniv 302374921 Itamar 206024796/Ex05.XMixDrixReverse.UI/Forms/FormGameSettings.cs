using System;
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


        public string Player1Name
        {
            get { return m_TextBoxPlayer1.Text; }
        }

        public bool IsMultiplayer
        {
            get { return m_CheckBoxIsMultiplayer.Checked; }
        }

        public string Player2Name
        {
            get
            {
                string name = m_TextBoxPlayer2.Text;

                if (!m_CheckBoxIsMultiplayer.Checked)
                {
                    name = m_TextBoxPlayer2.Text.Substring(1, m_TextBoxPlayer2.Text.Length - 2);
                }

                return name;
            }
        }

        public int NumRows
        {
            get { return int.Parse(m_NumericUpDownRows.Text); }
        }

        public int NumCols
        {
            get { return int.Parse(m_NumericUpDownCols.Text); }
        }

        public bool ClosedByStart { get; private set; }

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
            Controls.Add(m_LabelPlayers);

            //Row 2
            m_LabelPlayer1 = new Label();
            m_LabelPlayer1.AutoSize = true;
            m_LabelPlayer1.Text = "Player 1:";
            m_LabelPlayer1.Left = m_LabelPlayers.Left + 8;
            m_LabelPlayer1.Top = m_LabelPlayers.Top + 32;
            Controls.Add(m_LabelPlayer1);

            m_TextBoxPlayer1 = new TextBox();
            m_TextBoxPlayer1.AutoSize = true;
            m_TextBoxPlayer1.Left = m_LabelPlayer1.Left + 75;
            m_TextBoxPlayer1.Top = m_LabelPlayer1.Top - 2;
            Controls.Add(m_TextBoxPlayer1);

            //Row 3
            m_CheckBoxIsMultiplayer = new CheckBox();
            m_CheckBoxIsMultiplayer.AutoSize = true;
            m_CheckBoxIsMultiplayer.Click += new EventHandler(checkBoxIsMultiplayer_click);
            m_CheckBoxIsMultiplayer.Left = m_LabelPlayer1.Left;
            m_CheckBoxIsMultiplayer.Top = m_TextBoxPlayer1.Bottom + 8;
            Controls.Add(m_CheckBoxIsMultiplayer);

            m_LabelPlayer2 = new Label();
            m_LabelPlayer2.AutoSize = true;
            m_LabelPlayer2.Text = "Player 2:";
            m_LabelPlayer2.Left = m_CheckBoxIsMultiplayer.Left + 20;
            m_LabelPlayer2.Top = m_CheckBoxIsMultiplayer.Top;
            Controls.Add(m_LabelPlayer2);

            m_TextBoxPlayer2 = new TextBox();
            m_TextBoxPlayer2.Text = "[Computer]";
            m_TextBoxPlayer2.Enabled = false;
            m_TextBoxPlayer2.AutoSize = true;
            m_TextBoxPlayer2.Left = m_TextBoxPlayer1.Left;
            m_TextBoxPlayer2.Top = m_LabelPlayer2.Top - 3;
            Controls.Add(m_TextBoxPlayer2);

            //Row 4
            m_LabelBoardSize = new Label();
            m_LabelBoardSize.AutoSize = true;
            m_LabelBoardSize.Text = "Board Size:";
            m_LabelBoardSize.Left = 16;
            m_LabelBoardSize.Top = m_TextBoxPlayer2.Top + 40;
            Controls.Add(m_LabelBoardSize);

            //Row 5
            m_LabelRows = new Label();
            m_LabelRows.AutoSize = true;
            m_LabelRows.Text = "Rows:";
            m_LabelRows.Left = 16;
            m_LabelRows.Top = m_LabelBoardSize.Top + 30;
            Controls.Add(m_LabelRows);

            m_NumericUpDownRows = new NumericUpDown();
            m_NumericUpDownRows.AutoSize = true;
            m_NumericUpDownRows.Minimum = 4;
            m_NumericUpDownRows.Maximum = 10;
            m_NumericUpDownRows.Width = 10;
            m_NumericUpDownRows.Left = m_LabelRows.Left + 50;
            m_NumericUpDownRows.Top = m_LabelRows.Top;
            Controls.Add(m_NumericUpDownRows);

            m_LabelCols = new Label();
            m_LabelCols.AutoSize = true;
            m_LabelCols.Text = "Cols:";
            m_LabelCols.Left = m_NumericUpDownRows.Left + 60;
            m_LabelCols.Top = m_LabelRows.Top;
            Controls.Add(m_LabelCols);

            m_NumericUpDownCols = new NumericUpDown();
            m_NumericUpDownCols.AutoSize = true;
            m_NumericUpDownCols.Minimum = 4;
            m_NumericUpDownCols.Maximum = 10;
            m_NumericUpDownCols.Width = 10;
            m_NumericUpDownCols.Left = m_LabelCols.Left + 50;
            m_NumericUpDownCols.Top = m_LabelRows.Top;
            Controls.Add(m_NumericUpDownCols);

            //Row 6
            m_ButtonStart = new Button();
            m_ButtonStart.Text = "Start";
            m_ButtonStart.Click += new EventHandler(buttonStart_click);
            m_ButtonStart.AutoSize = true;
            m_ButtonStart.Left = 85;
            m_ButtonStart.Top = m_NumericUpDownCols.Top + 35;
            Controls.Add(m_ButtonStart);

            Text = "Game Settings";
            ClientSize = new Size(240, m_ButtonStart.Bottom + 20);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void checkBoxIsMultiplayer_click(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if(checkBox.Checked)
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.Text = string.Empty;
            }
            else
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.Text = "[Computer]";
            }
        }

        private void buttonStart_click(object sender, EventArgs e)
        {
            ClosedByStart = sender == m_ButtonStart;
            Close();
        }
    }
}
