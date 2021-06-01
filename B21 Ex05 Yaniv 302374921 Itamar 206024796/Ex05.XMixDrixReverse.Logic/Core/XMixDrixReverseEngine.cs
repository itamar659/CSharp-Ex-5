using System;
using System.Collections.Generic;

namespace Ex05.XMixDrixReverse.Logic
{
    public class XMixDrixReverseEngine
    {
        private bool m_IsGameRunning;
        private int m_CurrentTurn;
        private Board m_Board;
        private readonly int r_MaxNumberOfPlayers;
        private readonly List<BasePlayer> r_PlayersInGame;
        private BasePlayer m_CurrentPlayerTurn;
        private ePlayMode m_PlayMode;
        private eGameState m_GameState;

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

        public XMixDrixReverseEngine(int i_MaxPlayers)
        {
            r_MaxNumberOfPlayers = i_MaxPlayers;
            r_PlayersInGame = new List<BasePlayer>(MaxNumberOfPlayers);
        }

        public void SetBoardSize(int i_NumberOfRows, int i_NumberOfCols)
        {
            Board = new Board(i_NumberOfRows, i_NumberOfCols);
        }

        public void SetPlayModeByIdx(int i_PlayMode)
        {
            if (i_PlayMode == 1)
            {
                PlayMode = ePlayMode.SinglePlayer;
            }
            else if (i_PlayMode == 2)
            {
                PlayMode = ePlayMode.MultiPlayer;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Index modes are 1 for single playerm 2 for multiplayer.");
            }
        }

        public void Create2Players(string i_FirstPlayerName, string i_SecondPlayerName)
        {
            addPlayer(new Player(eSymbol.X, i_FirstPlayerName));

            if (PlayMode == ePlayMode.SinglePlayer)
            {
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

        public bool PlayTurn(int i_Row, int i_Column)
        {
            bool isValidInput = false;

            if (!isValidPosition(i_Row, i_Column))
            {
                isValidInput = true;
            }

            if (isValidInput)
            {
                nextActionOnPlayerInput(i_Row, i_Column);

                if (CurrentPlayerTurn is NPC npcTurn)
                {
                    playMove(npcTurn.RandomNextMove());
                    changeTurn();
                    handleGameState();
                }
            }

            return isValidInput;
        }

        public void Quit()
        {
            m_GameState = eGameState.Quit;
        }

        private void nextActionOnPlayerInput(int i_Row, int i_Column)
        {
            if (m_GameState != eGameState.Quit)
            {
                playMove(new Position(i_Row, i_Column));
            }

            changeTurn();
            handleGameState();
        }

        private void playMove(Position i_Position)
        {
            Board.SetItem(CurrentPlayerTurn.Symbol, i_Position.Row, i_Position.Column);
            bool hasWon = BoardUtils.HasCompleteSymbolSequence(Board, CurrentPlayerTurn.Symbol, i_Position);

            if (hasWon)
            {
                GameState = eGameState.Win;
            }
            else if (BoardUtils.IsFull(m_Board))
            {
                GameState = eGameState.Draw;
            }
        }

        private void addPlayer(BasePlayer i_Player) // TODO: Create a builder for computer or players
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
                if (GameState == eGameState.Win || GameState == eGameState.Quit)
                {
                    CurrentPlayerTurn.Score++;
                }

                CurrentTurn = 0;
                CurrentPlayerTurn = PlayersInGame[0];
                IsGameRunning = false;
            }
        }

        private bool isValidPosition(int i_Row, int i_Col)
        {
            return ((0 <= i_Row && i_Row < Board.Height) &&
                (0 <= i_Col && i_Col < Board.Width) &&
                !Board.IsOccupied(i_Row, i_Col));
        }

        public bool IsValidBoardChoice(int i_Size)
        {
            return (3 <= i_Size && i_Size <= 9);
        }

        public bool IsValidPlayModeChoice(int i_Mode)
        {
            return (i_Mode == 1 || i_Mode == 2);
        }
    }
}
