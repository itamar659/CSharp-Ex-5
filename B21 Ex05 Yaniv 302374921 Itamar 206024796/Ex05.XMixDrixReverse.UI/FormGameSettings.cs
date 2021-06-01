using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    class FormGameSettings : Form
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
            m_LabelPlayers.Text = "Players";
            m_LabelPlayers.Left = 16;
            m_LabelPlayers.Top = 16;
            this.Controls.Add(m_LabelPlayers);

            //Row 2
            m_LabelPlayer1 = new Label();
            m_LabelPlayer1.Text = "Player 1";
            m_LabelPlayer1.Left = 16;
            m_LabelPlayer1.Top = 16;
            this.Controls.Add(m_LabelPlayer1);

            m_TextBoxPlayer1 = new TextBox();
            m_TextBoxPlayer1.Left = 16;
            m_TextBoxPlayer1.Top = 16;
            this.Controls.Add(m_TextBoxPlayer1);

            ////Row 3
            //m_CheckBoxIsMultiplayer = ;
            //m_LabelPlayer2;
            //m_TextBoxPlayer2;
            //
            ////Row 4
            //m_LabelBoardSize;
            //
            ////Row 5
            //m_LabelRows;
            //m_NumericUpDownRows;
            //m_LabelCols;
            //m_NumericUpDownCols;
            //
            ////Row 6
            //m_ButtonStart;
        }
    }
}
