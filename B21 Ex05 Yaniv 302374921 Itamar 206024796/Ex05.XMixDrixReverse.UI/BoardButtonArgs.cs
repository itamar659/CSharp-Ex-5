using System;

namespace Ex05.XMixDrixReverse.UI
{
    internal class BoardButtonArgs : EventArgs
    {
        public BoardButton Button;

        public BoardButtonArgs(BoardButton i_Button)
        {
            Button = i_Button;
        }
    }
}
