using System;
using System.Drawing;
using System.Windows.Forms;
using Ex05.XMixDrixReverse.Logic;

namespace Ex05.XMixDrixReverse.UI
{
    internal class FormXMixDrixReverse : Form
    {
        private FormGameSettings m_FormGameSettings;
        private XMixDrixReverseEngine m_Engine;
        private BoardButtonCollection m_Buttons;
        private ScoreLabels m_ScoreLabels;

        public FormXMixDrixReverse()
        {
            const int k_MaxPlayers = 2;

            m_FormGameSettings = new FormGameSettings();
            m_Engine = new XMixDrixReverseEngine(k_MaxPlayers);
        }

        protected override void OnLoad(EventArgs e)
        {
            InitializeSettings();
            base.OnLoad(e);
        }

        public void InitializeSettings()
        {
            m_FormGameSettings.ShowDialog();

            if (!m_FormGameSettings.ClosedByStart)
            {
                Close();
            }

            if (!m_Engine.IsValidBoardSize(m_FormGameSettings.NumCols, m_FormGameSettings.NumRows))
            {
                MessageBox.Show("The number of columns and rows should be the same", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InitializeSettings();
            }
            else
            {
                m_Engine.SetPlayMode(m_FormGameSettings.IsMultiplayer);
                m_Engine.SetBoardSize(m_FormGameSettings.NumCols, m_FormGameSettings.NumRows);
                m_Engine.CreatePlayers(m_FormGameSettings.Player1Name, m_FormGameSettings.Player2Name);

                m_Engine.StartNewGame();
                m_Engine.GameFinished += m_Engine_GameFinished;

                initializeComponents();
            }
        }

        private void m_Engine_GameFinished(object sender, EventArgs e)
        {
            string title;
            string message;

            writeEndGameMessage(out title, out message);

            if (MessageBox.Show(message, title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                m_Engine.StartNewGame();
            }
            else
            {
                Close();
            }
        }

        private void writeEndGameMessage(out string i_Title, out string i_Message)
        {
            if (m_Engine.GameState == eGameState.Tie)
            {
                i_Title = "A Tie!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                i_Message = string.Format("Tie!{0}Would you like to play another round?", Environment.NewLine);
            }
            else
            {
                i_Title = "A Win!";
                i_Message = string.Format("The winner is {0}!{1}Would you like to play another round?", m_Engine.CurrentPlayerTurn.Name, Environment.NewLine);
            }
        }

        private void initializeComponents()
        {
            // Create all the buttons around the board
            m_Buttons = new BoardButtonCollection(m_Engine.Board);
            m_Buttons.CreateCollection(m_Engine.Board.Width, m_Engine.Board.Height);
            m_Buttons.Top = m_Buttons.ButtonOffset.Height;
            m_Buttons.Left = m_Buttons.ButtonOffset.Width;
            m_Buttons.ClickSingleButton += button_Click;
            Controls.Add(m_Buttons);

            // Create the labels at the end
            m_ScoreLabels = new ScoreLabels(m_FormGameSettings.Player1Name, m_FormGameSettings.Player2Name);
            m_ScoreLabels.Top = m_Buttons.Bottom + 10;
            m_ScoreLabels.Left = ClientSize.Width / 2 - m_ScoreLabels.Width / 2;
            Controls.Add(m_ScoreLabels);

            foreach (var player in m_Engine.PlayersInGame)
            {
                player.ScoreChanged += m_ScoreLabels.ChangeScore;
            }

            // Change the form settings
            BackColor = Color.FromArgb(200, 220, 240);
            AutoSize = true;
            Size += m_Buttons.ButtonOffset;
            Text = "TicTacToeMisere";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button_Click(object sender, BoardButtonArgs e)
        {
            m_Engine.PlayTurn(e.Button.Position.X, e.Button.Position.Y);
        }
    }
}
