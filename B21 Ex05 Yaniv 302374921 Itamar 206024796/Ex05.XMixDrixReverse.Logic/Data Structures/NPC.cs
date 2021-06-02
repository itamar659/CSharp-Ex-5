using System;

namespace Ex05.XMixDrixReverse.Logic
{
    internal class NPC : BasePlayer
    {
        private readonly Board r_Board;
        private readonly Random r_Random;

        public NPC(eSymbol i_Symbol, string i_Name, Board i_Board)
            : base(i_Symbol, i_Name)
        {
            r_Board = i_Board;
            r_Random = new Random();
        }

        public Point RandomNextMove()
        {
            int x;
            int y;

            do
            {
                x = r_Random.Next(r_Board.Width);
                y = r_Random.Next(r_Board.Height);
            }
            while (r_Board.IsOccupied(x, y));

            return new Point(x, y);
        }
    }
}
