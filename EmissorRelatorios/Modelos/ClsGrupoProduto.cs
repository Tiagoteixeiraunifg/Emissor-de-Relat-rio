using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Modelos
{
    class ClsGrupoProduto
    {
        private int idGrupo;
        private string grupo;

        public void setIdGrupo(int idGrupo) {
            this.idGrupo = idGrupo;
        }

        public int getIdGrupo() {
            return this.idGrupo;
        }

        public void setGrupo(string grupo) {
            this.grupo = grupo;
        }

        public string getGrupo() {
            return this.grupo;
        }
    }
}
