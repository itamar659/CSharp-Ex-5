using Ex05.XMixDrixReverse.Logic;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    class ScoreLabels : Control
    {
        private Label m_LabelFirstPlayerName;
        private Label m_LabelFirstPlayerScore;
        private Label m_LabelSecondPlayerName;
        private Label m_LabelSecondPlayerScore;

        public int FirstPlayerScore
        {
            get { return int.Parse(m_LabelFirstPlayerScore.Text); }
            set { m_LabelFirstPlayerScore.Text = value.ToString(); }
        }
        public int SecondPlayerScore
        {
            get { return int.Parse(m_LabelSecondPlayerScore.Text); }
            set { m_LabelSecondPlayerScore.Text = value.ToString(); }
        }
        public string FirstPlayerName { get; private set; }
        public string SecondPlayerName { get; private set; }

        public ScoreLabels(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            FirstPlayerName = i_FirstPlayerName;
            SecondPlayerName = i_SecondPlayerName;

            initializeComponents();

            FirstPlayerScore = 0;
            SecondPlayerScore = 0;

            Size = new Size(m_LabelSecondPlayerScore.Right, m_LabelSecondPlayerScore.Bottom);
        }

        private void initializeComponents()
        {
            m_LabelFirstPlayerName = new Label();
            m_LabelFirstPlayerName.Text = FirstPlayerName + ":";
            m_LabelFirstPlayerName.AutoSize = true;
            Controls.Add(m_LabelFirstPlayerName);

            m_LabelFirstPlayerScore = new Label();
            m_LabelFirstPlayerScore.Left = m_LabelFirstPlayerName.Right;
            m_LabelFirstPlayerScore.AutoSize = true;
            Controls.Add(m_LabelFirstPlayerScore);

            m_LabelSecondPlayerName = new Label();
            m_LabelSecondPlayerName.Text = SecondPlayerName + ":";
            m_LabelSecondPlayerName.Left = m_LabelFirstPlayerScore.Right + 20;
            m_LabelSecondPlayerName.AutoSize = true;
            Controls.Add(m_LabelSecondPlayerName);

            m_LabelSecondPlayerScore = new Label();
            m_LabelSecondPlayerScore.Left = m_LabelSecondPlayerName.Right;
            m_LabelSecondPlayerScore.AutoSize = true;
            Controls.Add(m_LabelSecondPlayerScore);
        }

        public void ChangeScore(object sender, EventArgs e)
        {
            BasePlayer theSender = sender as BasePlayer;

            if (theSender.Name  + ":" == m_LabelFirstPlayerName.Text)
            {
                FirstPlayerScore++;
            }
            else
            {
                SecondPlayerScore++;
            }
        }
    }
}
