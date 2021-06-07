using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Modelos
{
    public class ClsCliente
    {
        private int idcliente;
        private string razaoSocial;


        public void setIdCliente(int idCli) {
            this.idcliente = idCli;
        }
        public int getIdCliente() {
            return this.idcliente;
        }

        public void setRazaoSocial(string RazSocial) {
            this.razaoSocial = RazSocial;
        }

        public string getRazaoSocial() {
            return this.razaoSocial;
        }


    }
}
