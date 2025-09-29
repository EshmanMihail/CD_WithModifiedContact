using System.Windows.Forms;
using System.Collections.Generic;

namespace CD_WithModifiedContact.Helpers
{
    public class ControlHelper
    {
        private readonly List<Control> initControls;

        public ControlHelper(Control container)
        {
            initControls = new List<Control>();

            foreach (Control el in container.Controls)
            {
                if (el is TextBox || el is ComboBox)
                {
                    initControls.Add(el);
                }
            }
        }

        /// <summary>
        /// Метод для подключения события "разрешить только цифры запятую для ввода"
        /// </summary>
        /// <param name="textBoxCount">количество текстовых полей или норме последнего поля</param>
        public void AllowOnlyDigits(int textBoxCount)
        {
            for (int i = 0; i < textBoxCount && i < initControls.Count; i++)
            {
                if (initControls[i] is TextBox textBox)
                {
                    textBox.KeyPress += TextBoxKeyPress;
                }
            }
        }

        private void TextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' && (textBox.Text.Contains(".") || textBox.Text.Contains(",")))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' && string.IsNullOrEmpty(textBox.Text))
                {
                    e.Handled = true;
                }
            }
        }

        public static void AttachDigitOnlyHandler(TextBox textBox)
        {
            textBox.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }

                if (e.KeyChar == ',' && (textBox.Text.Contains(",") || string.IsNullOrEmpty(textBox.Text)))
                {
                    e.Handled = true;
                }
            };
        }

        public List<Control> GetControls()
        {
            return initControls;
        }
    }
}
