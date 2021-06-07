using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Controles
{
    
    public class ClsEtiquetasDAO
    {
        private static string retorno;
        public DataSet GetProdutos()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataSet ds = new DataSet();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select ID_PRODUTO, GTIN, PRODUTO, VALOR_VENDA, VALOR_ATACADO from PRODUTOS order by PRODUTO";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(ds);
                    return ds;
                }

            }
            catch (Exception)
            {
                retorno = "Erro ao obter os dados.";
            }
            finally
            {
                cnn.desconect();

            }
            return null;

        }
    }
}
