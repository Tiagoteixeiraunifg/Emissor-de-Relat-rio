using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Modelos
{
    public class ClsProduto
    {
        private int idProduto;
        private string gtin;
        private string produto;
        private decimal valor_venda;
        private decimal valor_atacado;
        private int quantidade;


        public void setQuantidade(int valor) {
            this.quantidade = valor;
        }

        public int getQuantidade() {
            return quantidade;
        }
        public void setGtin(string Barras) {
            this.gtin = Barras;
        }

        public string getGtin() {
            return gtin;
        }

        public void setValorVenda(decimal VlrVenda) {
            this.valor_venda = VlrVenda;
        }

        public decimal getValorVenda() {
            return valor_venda;
        }

        public void setValorAtacado(decimal VlrAtacado) {
            this.valor_atacado = VlrAtacado;
        }

        public decimal getValorAtacado() {
            return valor_atacado;
        }
        public void setIdProduto(int IdProduto) {
            this.idProduto = IdProduto;
        }

        public int GetIdProduto() {
            return this.idProduto;
        }

        public void setProduto(string NomeProduto) {
            this.produto = NomeProduto;
        }

        public string getProduto() {
            return this.produto;
        }
    }
}
