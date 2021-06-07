using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Modelos
{
    public class ClsUsuario 
    {
        private int idUsuario;
        private string usuario;

        private void setIdUsuario(int idUsuario) {
            this.idUsuario = idUsuario;
        }

        private int getIdUsuario() {
            return this.idUsuario;
        }

        public void setUsuario(string usuarioNome) {
            this.usuario = usuarioNome;
        }

        public string getUsuario() {
            return this.usuario;
        }
    }
}
