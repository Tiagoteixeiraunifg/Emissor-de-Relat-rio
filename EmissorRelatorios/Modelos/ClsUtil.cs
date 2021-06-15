using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace EmissorRelatorios.Modelos
{
   public class ClsUtil
    {

        public  void MsgBox(string mensagem, MessageBoxIcon icone)
        {
            
            string mensagem2 = "";
            MessageBoxButtons botoes = MessageBoxButtons.OK;
            DialogResult resultado;
            // Displays the MessageBox.
            resultado = MessageBox.Show(mensagem, mensagem2, botoes, icone);
            
        }

        public  int MsgBox_Full(string mensagem , string mensagem2)
        {
           
            MessageBoxButtons botoes = MessageBoxButtons.YesNoCancel;
            MessageBoxIcon icone = MessageBoxIcon.Warning;
            DialogResult resultado;

            // Displays the MessageBox.
            resultado = MessageBox.Show(mensagem, mensagem2, botoes, icone);
            if (resultado == System.Windows.Forms.DialogResult.Yes)
            {
                return 1;
            }
            else if (resultado == System.Windows.Forms.DialogResult.No)
            {
                return 0;
            }
            else if (resultado == System.Windows.Forms.DialogResult.Cancel)
            {
                return 0;
            }

            return 3;
        }

        public  void LimpaFormulario(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is NumericUpDown) { ((NumericUpDown)(ctrl)).Value = ((NumericUpDown)(ctrl)).Minimum; }
                //if (ctrl is TextBox) { ((TextBox)(ctrl)).Clear(); }
                if (ctrl is TextBox) { ((TextBox)(ctrl)).Enabled = false; }
                if (ctrl is ComboBox) { ((ComboBox)(ctrl)).SelectedIndex = -1; }
                if (ctrl is RichTextBox) { ((RichTextBox)(ctrl)).Enabled = false; }
                if (ctrl is ComboBox) { ((ComboBox)(ctrl)).Enabled = false; }
                if (ctrl is DateTimePicker) { ((DateTimePicker)(ctrl)).Value = DateTime.Now; }
                if (ctrl is DateTimePicker) { ((DateTimePicker)(ctrl)).Enabled = false; }
                if (ctrl is MaskedTextBox) { ((MaskedTextBox)(ctrl)).Clear(); }
                if (ctrl is MaskedTextBox) { ((MaskedTextBox)(ctrl)).Mask = ""; }
                if (ctrl is Button) { ((Button)(ctrl)).Enabled = false; }
                if (ctrl is RadioButton) { ((RadioButton)(ctrl)).Enabled = false; }
                LimpaFormulario(ctrl.Controls);
            }
        }
        public  void HabilitaFormulario(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is TextBox) { ((TextBox)(ctrl)).Enabled = true; }
                if (ctrl is TextBox) { ((TextBox)(ctrl)).ReadOnly = false; }
                if (ctrl is MaskedTextBox) { ((MaskedTextBox)(ctrl)).Enabled = true; }
                if (ctrl is MaskedTextBox) { ((MaskedTextBox)(ctrl)).ReadOnly = false; }
                if (ctrl is ComboBox) { ((ComboBox)(ctrl)).Enabled = true; }
                if (ctrl is DateTimePicker) { ((DateTimePicker)(ctrl)).Enabled = true; }
                if (ctrl is RichTextBox) { ((RichTextBox)(ctrl)).Enabled = true; }
                if (ctrl is Button) { ((Button)(ctrl)).Enabled = true; }
                if (ctrl is RadioButton) { ((RadioButton)(ctrl)).Enabled = true; }
                HabilitaFormulario(ctrl.Controls);
            }
        }
    }
}
