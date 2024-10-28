
namespace AWF.Presentation.Utilidades
{
    public static class CustomTextBox
    {
        public static void ValidarNumero(this TextBox textbox)
        {
            textbox.KeyPress += (sender, e) => 
            {
                if(char.IsDigit(e.KeyChar)){
                    e.Handled = false;
                } else {
                    if(char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                        e.Handled = false;
                    else 
                        e.Handled = true;
                }
            };
        }
    }
}