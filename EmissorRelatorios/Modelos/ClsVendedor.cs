using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Modelos
{
    class ClsVendedor
    {
        private int idVendedor;
        private string vendedor;

        public void setIdVendedor(int idVendedor) {
            this.idVendedor = idVendedor;
        }

        public int getIdVendedor() {
            return this.idVendedor;
        }

        public void setVendedor(string Vendedor) {
            this.vendedor = Vendedor;
        }

        public string getVendedor() {
            return this.vendedor;
        }
    }
}
