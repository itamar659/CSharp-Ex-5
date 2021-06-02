using System;
using System.Collections.Generic;

namespace Ex05.XMixDrixReverse.Logic
{
    public class XMixDrixReverseEngine
    {
        public event EventHandler GameFinished;

        private bool m_IsGameRunning;
        private int m_CurrentTurn;
        private Board m_Board;
        private readonly int r_MaxNumberOfPlayers;
        private readonly List<BasePlayer> r_PlayersInGame;
        private BasePlayer m_CurrentPlayerTurn;
        private ePlayMode m_PlayMode;
        private eGameState m_GameState;

        #region Public Properties

        public Board Board
        {
            get { return m_Board; }
            private set
            {
                if (!m_IsGameRunning)
                {
                    m_Board = value;
                }
            }
        }

        public BasePlayer CurrentPlayerTurn
        {
            get { return m_CurrentPlayerTurn; }
            private set { m_CurrentPlayerTurn = value; }
        }

        public int MaxNumberOfPlayers
        {
            get { return r_MaxNumberOfPlayers; }
        }

        public List<BasePlayer> PlayersInGame
        {
            get { return r_PlayersInGame; }
        }

        public ePlayMode PlayMode
        {
            get { return m_PlayMode; }
            private set
            {
                if (!m_IsGameRunning)
                {
                    m_PlayMode = value;
                }
            }
        }

        public eGameState GameState
        {
            get { return m_GameState; }
            private set { m_GameState = value; }
        }

        public bool IsGameRunning
        {
            get { return m_IsGameRunning; }
            private set { m_IsGameRunning = value; }
        }

        public int CurrentTurn
        {
            get { return m_CurrentTurn; }
            private set { m_CurrentTurn = value; }
        }

        #endregion

        public XMixDrixReverseEngine(int i_MaxPlayers)
        {
            r_MaxNumberOfPlayers = i_MaxPlayers;
            r_PlayersInGame = new List<BasePlayer>(MaxNumberOfPlayers);
        }

        public void SetBoardSize(int i_Width, int i_Height)
        {
            Board = new Board(i_Width, i_Height);
        }

        public void SetPlayMode(bool i_IsMultiplayerMode)
        {
            if (i_IsMultiplayerMode)
            {
                PlayMode = ePlayMode.MultiPlayer;
            }
            else
            {
                PlayMode = ePlayMode.SinglePlayer;
            }
        }

        public void CreatePlayers(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            addPlayer(new Player(eSymbol.X, i_FirstPlayerName));

            if (PlayMode == ePlayMode.SinglePlayer)
            {
                if (Board == null)
                {
                    throw new ArgumentException("The board has to be initialized before assigning it to the NPC");
                }

                addPlayer(new NPC(eSymbol.O, i_SecondPlayerName, Board));
            }
            else
            {
                addPlayer(new Player(eSymbol.O, i_SecondPlayerName));
            }
        }

        public void StartNewGame()
        {
            if (PlayersInGame.Count != 0)
            {
                Board.Clear();
                m_IsGameRunning = true;
                m_CurrentTurn = 0;
                m_CurrentPlayerTurn = r_PlayersInGame[0];
                m_GameState = eGameState.InProgress;
            }
        }

        public bool PlayTurn(int i_X, int i_Y)
        {
            bool isValidInput = false;

            if (isValidPosition(i_X, i_Y))
            {
                isValidInput = true;
            }

            if (isValidInput)
            {
                playMove(new Point(i_X, i_Y));

                if (CurrentPlayerTurn is NPC npcTurn)
                {
                    playMove(npcTurn.RandomNextMove());
                }
            }

            return isValidInput;
        }

        public bool IsValidBoardSize(int i_Width, int i_Height)
        {
            return (i_Width == i_Height);
        }

        protected virtual void OnGameFinished()
        {
            GameFinished?.Invoke(this, EventArgs.Empty);
        }

        #region Helpers

        private void playMove(Point i_Position)
        {
            changeBoardSymbol(i_Position);
            changeTurn();
            handleGameState();
        }

        private void changeBoardSymbol(Point i_Position)
        {
            Board.SetItem(CurrentPlayerTurn.Symbol, i_Position.X, i_Position.Y);
            bool hasWon = BoardUtils.HasCompleteSymbolSequence(Board, CurrentPlayerTurn.Symbol, i_Position);

            if (hasWon)
            {
                GameState = eGameState.Win;
            }
            else if (BoardUtils.IsFull(m_Board))
            {
                GameState = eGameState.Tie;
            }
        }

        private void addPlayer(BasePlayer i_Player)
        {
            if (IsGameRunning)
            {
                throw new ArgumentException("Can't add new player while in game.");
            }

            if (PlayersInGame.Count < MaxNumberOfPlayers)
            {
                PlayersInGame.Add(i_Player);
            }
            else
            {
                throw new ArgumentException("Maximum number reached.");
            }
        }

        private void changeTurn()
        {
            CurrentTurn++;
            int playerTurn = CurrentTurn % PlayersInGame.Count;

            CurrentPlayerTurn = PlayersInGame[playerTurn];
        }

        private void handleGameState()
        {
            if (GameState != eGameState.InProgress)
            {
                if (GameState == eGameState.Win)
                {
                    CurrentPlayerTurn.Score++;
                }

                OnGameFinished();

                CurrentTurn = 0;
                CurrentPlayerTurn = PlayersInGame[0];
                IsGameRunning = false;
            }
        }

        private bool isValidPosition(int i_X, int i_Y)
        {
            return ((0 <= i_X && i_X < Board.Width) &&
                (0 <= i_Y && i_Y < Board.Height) &&
                !Board.IsOccupied(i_X, i_Y));
        }

        #endregion
    }
}
