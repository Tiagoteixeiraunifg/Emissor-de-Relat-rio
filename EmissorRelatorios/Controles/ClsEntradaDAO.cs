using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Controles
{

    public class ClsEntradaDAO
    {

        private static string retorno;
        private static bool sucesso;
        private static string query;
       
        public DataTable GetUsuarios()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select ID, USUARIO from USUARIO order by usuario";
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

        public DataTable GetFornecedores()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select id_fornecedor, raz_social from fornecedor order by fantasia";
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

        public DataTable GetNfeE(string fornecedor, string dataIni, string dataFim)
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select id, nota from nota_compra where ID_FORNECEDOR = '"+ fornecedor +"'and DATA_LANC between '"+dataIni+"' and '"+dataFim+"'";
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

        public DataTable GetGrupo()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select ID, GRUPO  from PRODUTOS_GRUPO order by GRUPO";
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


        public DataSetCompras selectCompras(int funcao, int tipo, string dataIni, string dataFim, string idFornecedor, string idNfeE)
        {
            DataSetCompras compras = new DataSetCompras();
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;

            //tipo se é DAV, NFCE, NFE ou TODOS
            //funcao é o relatório

            switch (tipo)
            {
                case 0: //todos
                    switch (funcao)
                    {
                        case 1:
                            query = " SELECT FR.ID_FORNECEDOR, FR.RAZ_SOCIAL, FR.CNPJ, FR.IE, FR.ENDERECO, FR.MUNICIPIO, FR.UF, FR.CEP, FR.FONE,  NC.ID AS ID_NOTA,NC.NOTA AS NUM_NOTA,NC.SERIE,NC.DATA_EMISSAO, " +
                                " NC.DATA_LANC, NC.DATA_SAIDA, NC.BASE_ICMS AS NC_BASE_ICMS, NC.VALOR_ICMS, NC.BASE_ICMS_SUB, NC.VALOR_ICMS_SUB, NC.VALOR_FRETE, NC.VALOR_SEGURO,NC.OUTRAS_DESPESAS, NC.VALOR_IPI, " +
                                " NC.VALOR_PIS, NC.VALOR_COFINS, NC.VALOR_DESCONTO, NC.VALOR_PRODUTOS, NC.VALOR_TOTAL, NC.NFE_CHAVE, NCI.ITEM AS NUM_ITEM,NCI.ID_PRODUTO, P.PRODUTO,P.NCM AS ITEM_NCM,P.UNIDADE_COMECIAL AS ITEM_UN, " +
                                " NCI.CFOP, NCI.QUANTIDADE, NCI.VALOR_UNITARIO,NCI.DESCONTO AS ITEM_VLR_DESC, NCI.TOTAL_ITEM, NCI.ICMS_BC AS NCI_BASE_ICMS, NCI.ICMS_VALOR, NCI.ICMS_CST, NCI.ICMS_CSOSN,NCI.ICMS_TAXA AS ITEM_ALQ_ICMS, " +
                                " NCI.IPI_BASE, NCI.IPI_VALOR,GR.GRADE, PGI.BARRAS AS BARRA_GRADE, PGI.ESTOQUE AS ESTOQUE_GRADE, FR.NUMERO AS ENDER_NUMERO, NC.MODELO AS NC_MODELO FROM FORNECEDOR FR " +
                                " INNER JOIN NOTA_COMPRA NC ON FR.ID_FORNECEDOR = NC.ID_FORNECEDOR" +
                                " INNER JOIN NOTA_COMPRA_DETALHE NCI ON NC.ID = NCI.ID_NFE " +
                                " INNER JOIN PRODUTOS P ON P.ID_PRODUTO = NCI.ID_PRODUTO " +
                                " LEFT JOIN PRODUTOS_GRADE_ITENS PGI ON PGI.ID_PRODUTO = NCI.ID_PRODUTO " +
                                " LEFT JOIN GRADE GR ON PGI.ID_GRADE = GR.ID " +
                                " WHERE NC.ID = "+idNfeE+" ";
                            break;
                
                    }
                    break;
                default:
                    break;
            }

            
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "SELECT  FANTASIA, RAZ_SOCIAL, ENDER,ENDER_NUMERO,COMPLEMENTO, BAIRRO,CEP,TELEFONE,UF,MUNICIPIO, CNPJ, INSC_EST FROM EMITENTE";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(compras.EMITENTE);

                    con.CommandText = query;
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(compras.COMPRAS);
                    return compras;

                }
            }
            catch (FbException e)
            {
                retorno = "Erro ao obter dados: " + e;
                sucesso = false;
                return null;
            }
            finally
            {
                cnn.desconect();
            }

            

        }

    }
}
