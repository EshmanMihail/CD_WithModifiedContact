using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CD_WithModifiedContact.Helpers
{
    public class TextBoxValidator
    {
        public static bool HasValidationErrors(ErrorProvider errorProvider, Control panel)
        {
            try
            {
                foreach (Control control in panel.Controls)
                {
                    if (!string.IsNullOrEmpty(errorProvider.GetError(control)))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (NullReferenceException e)
            {
                throw new Exception("окак, чё та не передал или объект не поддерживает такое свойство.");
            }
        }

        public static void CheckTextBoxesFilledAndSetErrors(ErrorProvider errorProvider, Control panel)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrWhiteSpace(textBox.Text))
                    {
                        errorProvider.SetError(textBox, "Поле не должно быть пустым!");
                    }
                    else errorProvider.SetError(textBox, string.Empty);
                }
            }
        }
    }
}
