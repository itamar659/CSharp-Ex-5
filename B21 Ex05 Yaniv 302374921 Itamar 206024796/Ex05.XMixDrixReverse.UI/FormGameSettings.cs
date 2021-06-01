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
            //m_LabelPlayers = new Label();
            //m_LabelPlayers.Text

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
        }
    }
}
