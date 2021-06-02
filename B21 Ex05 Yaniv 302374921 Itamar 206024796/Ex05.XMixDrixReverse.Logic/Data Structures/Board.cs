using System;

namespace Ex05.XMixDrixReverse.Logic
{
    public class Board
    {
        public class BoardItem
        {
            public event EventHandler SymbolChanged;

            protected virtual void OnSymbolChanged()
            {
                SymbolChanged?.Invoke(this, EventArgs.Empty);
            }

            private eSymbol? m_Symbol;

            public eSymbol? Symbol
            {
                get { return m_Symbol; }
                set
                {
                    m_Symbol = value;
                    OnSymbolChanged();
                }
            }
        }

        public readonly BoardItem[,] Items;
        private readonly int r_Width;
        private readonly int r_Height;

        public int Width
        {
            get { return r_Width; }

        }

        public int Height
        {
            get { return r_Height; }
        }

        public Board(int i_Height, int i_Width)
        {
            r_Width = i_Width;
            r_Height = i_Height;
            Items = new BoardItem[i_Width, i_Height];

            for (int x = 0; x < i_Width; x++)
            {
                for (int y = 0; y < i_Height; y++)
                {
                    Items[x, y] = new BoardItem();
                }
            }
        }

        public void SetItem(eSymbol i_Symbol, int i_X, int i_Y)
        {
            Items[i_X, i_Y].Symbol = i_Symbol;
        }

        public eSymbol GetItem(int i_X, int i_Y)
        {
            return Items[i_X, i_Y].Symbol ?? eSymbol.O;
        }

        public void Delete(int i_X, int i_Y)
        {
            Items[i_X, i_Y].Symbol = null;
        }

        public void Clear()
        {
            for (int x = 0; x < r_Width; x++)
            {
                for (int y = 0; y < r_Height; y++)
                {
                    Delete(x, y);
                }
            }
        }

        public bool IsOccupied(int i_X, int i_Y)
        {
            return Items[i_X, i_Y].Symbol != null;
        }
    }
}
