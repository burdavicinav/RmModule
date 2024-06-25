using System.Windows.Forms;

namespace RmUI.Classes
{
    /// <summary>
    /// Пользовательское сообщение.
    /// </summary>
    public static class UserMessage
    {
        public static void RequireRowWarning()
        {
            MessageBox.Show(
                "Необходимо выбрать хотя бы одну строку!",
                "Внимание",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
    }
}
