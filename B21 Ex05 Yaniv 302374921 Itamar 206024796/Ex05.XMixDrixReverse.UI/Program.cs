using System.Windows.Forms;

namespace Ex05.XMixDrixReverse.UI
{
    internal class Program
    {
        static void Main()
        {
            FormXMixDrixReverse formXMixDrixReverse = new FormXMixDrixReverse();
            formXMixDrixReverse.StartPosition = FormStartPosition.CenterScreen;
            formXMixDrixReverse.FormBorderStyle = FormBorderStyle.FixedDialog;
            formXMixDrixReverse.ShowDialog();
        }
    }
}