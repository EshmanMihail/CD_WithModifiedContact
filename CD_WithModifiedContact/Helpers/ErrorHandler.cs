using System.Windows.Forms;

namespace CD_WithModifiedContact.Helpers
{
    public class ErrorHandler
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
