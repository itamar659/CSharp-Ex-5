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

        public FormXMixDrixReverse()
        {
            const int k_MaxPlayers = 2;

            m_FormGameSettings = new FormGameSettings();
            m_Engine = new XMixDrixReverseEngine(k_MaxPlayers);
        }

        protected override void OnShown(EventArgs e)
        {
            m_FormGameSettings.ShowDialog();

            m_Engine.SetPlayModeByIdx(2);
            m_Engine.Create2Players("player 1", "player 2");
            m_Engine.SetBoardSize(5, 5);
            m_Engine.StartNewGame();

            initializeComponents();

            base.OnShown(e);
        }

        private void initializeComponents()
        {
            // TODO: Form title, etc...

            m_Buttons = new BoardButtonCollection();
            m_Buttons.CreateCollection(m_Engine.Board.Width, m_Engine.Board.Height);
            m_Buttons.Top = m_Buttons.ButtonOffset.Height;
            m_Buttons.Left = m_Buttons.ButtonOffset.Width;
            m_Buttons.ClickSingleButton += button_Click;
            Controls.Add(m_Buttons);
        }

        private void button_Click(object sender, BoardButtonArgs e)
        {
            e.Button.Text = m_Engine.CurrentPlayerTurn.Symbol.ToString();
            m_Engine.PlayTurn(e.Button.Position.X, e.Button.Position.Y);
        }
    }
}
