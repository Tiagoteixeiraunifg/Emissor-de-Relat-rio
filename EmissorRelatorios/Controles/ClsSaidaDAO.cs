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

    public class ClsSaidaDAO
    {

        private static string retorno;
        public  bool sucesso { get; set; }
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

        public DataTable GetClientes()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select ID_CLIENTE, RAZ_SOCIAL from CLIENTES order by raz_social";
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

        public DataTable GetVendedor()
        {

            ConexaoDAO cnn = new ConexaoDAO();
            DataTable ds = new DataTable();
            FbDataAdapter da = null;
            ds.Clear();
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select ID, DESCRICAO from VENDEDOR order by descricao";
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
                    sucesso = true;
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

        public DataSetVendas selectVendas(int funcao, int tipo, string dataIni, string dataFim, string idProduto, string idVendedor, string idCliente, string Grupo)
        {
            DataSetVendas vendas = new DataSetVendas();
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
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '"+ dataFim + "'   AND NFE.ID_VENDEDOR = "+ idVendedor + " and NFEI.ID_PRODUTO = "+ idProduto + " union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_VENDEDOR = " + idVendedor + " and DVI.ID_PRODUTO = " + idProduto + " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'and NFCE.ID_VENDEDOR = " + idVendedor + " AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCEI.ID_PRODUTO = "+ idProduto + "";
                            break;
                        case 2:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'   AND NFE.ID_VENDEDOR = " + idVendedor + "  union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_VENDEDOR = " + idVendedor + " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCE.ID_VENDEDOR = " + idVendedor + "";
                            break;
                        case 3:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'  and NFEI.ID_PRODUTO = " + idProduto + " union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DVI.ID_PRODUTO= " + idProduto + " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        case 4:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'  and NFEI.ID_PRODUTO = " + idProduto + " and NFE.ID_CLIENTE = "+ idCliente + " union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DVI.ID_PRODUTO= " + idProduto + " AND DAV.ID_CLIENTE = " + idCliente + " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCEI.ID_PRODUTO = " + idProduto + " AND NFCE.ID_CLIENTE = " + idCliente + "";
                            break;
                        case 5:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'   union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_CLIENTE IN (SELECT ID_CLIENTE FROM CLIENTES)  union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCE.ID_CLIENTE IN (SELECT ID_CLIENTE FROM CLIENTES) ";
                            break;
                        case 6:
                            query = "SELECT NFE.ID AS ID_VENDA,'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM,USR.USUARIO,NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, " +
                                " NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE" +
                                " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR" +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND PG.ID = '" + Grupo + "'" +
                                " union" +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO,DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, " +
                                " DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_CLIENTE IN(SELECT ID_CLIENTE FROM CLIENTES) AND PG.ID = '" + Grupo + "'" +
                                " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCE.ID_CLIENTE IN(SELECT ID_CLIENTE FROM CLIENTES) AND PG.ID = '" + Grupo+"'";
                            break;
                        case 10:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'   AND NFE.ID_CLIENTE = " + idCliente + " and NFEI.ID_PRODUTO = " + idProduto + " union " +
                                " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_CLIENTE = " + idCliente + " and DVI.ID_PRODUTO = " + idProduto + " union " +
                                " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'and NFCE.ID_CLIENTE = " + idCliente + " AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        default:
                            break;
                    }
                    break;
                case 1: //dav
                    switch (funcao)
                    {
                        case 1: 
                            query =  " SELECT DAV.ID AS ID_VENDA, DAV.SITUACAO AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO,  " +
                                     " DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM, DVI.ID_PRODUTO, PROD.PRODUTO, " +
                                     " DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, " +
                                     " DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO  FROM DAV_ITENS DVI INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                     " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO INNER JOIN VENDEDOR VDR ON " +
                                     " VDR.ID = DAV.ID_VENDEDOR  INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO WHERE DAV.DATA_VENDA " +
                                     " BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N'  AND DAV.ID_VENDEDOR = " + idVendedor + " AND DVI.ID_PRODUTO " +
                                     " = " + idProduto + " AND DVI.CANCELADO = 'N' order by DVI.ITEM";
                            break;
                        case 2: 
                            query = "SELECT DAV.ID AS ID_VENDA, DAV.SITUACAO AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO,  " +
                                    " DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM, DVI.ID_PRODUTO, PROD.PRODUTO, " +
                                    " DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, " +
                                    " DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO  FROM DAV_ITENS DVI INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                    " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO INNER JOIN VENDEDOR VDR ON " +
                                    " VDR.ID = DAV.ID_VENDEDOR  INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO WHERE DAV.DATA_VENDA " +
                                    " BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N'  AND DAV.ID_VENDEDOR = " + idVendedor + " AND DVI.CANCELADO = 'N' order by DVI.ITEM";
                            break;
                        case 3:
                            query = "SELECT DAV.ID AS ID_VENDA, DAV.SITUACAO AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO,  " +
                                    " DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM, DVI.ID_PRODUTO, PROD.PRODUTO, " +
                                    " DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, " +
                                    " DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO  FROM DAV_ITENS DVI INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                    " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO INNER JOIN VENDEDOR VDR ON " +
                                    " VDR.ID = DAV.ID_VENDEDOR  INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO WHERE DAV.DATA_VENDA " +
                                    " BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DVI.ID_PRODUTO " +
                                    " = " + idProduto + " AND DVI.CANCELADO = 'N' order by DVI.ITEM";
                            break;
                        case 4:
                            query = "SELECT DAV.ID AS ID_VENDA, DAV.SITUACAO AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO,  " +
                                   " DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM, DVI.ID_PRODUTO, PROD.PRODUTO, " +
                                   " DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, " +
                                   " DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO  FROM DAV_ITENS DVI INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                   " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO INNER JOIN VENDEDOR VDR ON " +
                                   " VDR.ID = DAV.ID_VENDEDOR  INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO WHERE DAV.DATA_VENDA " +
                                   " BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DVI.ID_PRODUTO " +
                                   " = " + idProduto + " AND DVI.CANCELADO = 'N' DAV.ID_CLIENTE = " + idCliente + " order by DVI.ITEM";
                            break;
                        case 5:
                            query = "SELECT DAV.ID AS ID_VENDA, DAV.SITUACAO AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO,  " +
                                   " DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM, DVI.ID_PRODUTO, PROD.PRODUTO, " +
                                   " DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, " +
                                   " DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO  FROM DAV_ITENS DVI INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                   " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO INNER JOIN VENDEDOR VDR ON " +
                                   " VDR.ID = DAV.ID_VENDEDOR  INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO WHERE DAV.DATA_VENDA " +
                                   " BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DVI.CANCELADO = 'N' AND DAV.ID_CLIENTE IN (SELECT ID_CLIENTE FROM CLIENTES) order by DVI.ITEM";
                            break;
                        case 6:
                            query = " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO,DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE, DVI.VALOR_TOTAL AS VLRTOTAL, " +
                                " DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_CLIENTE IN(SELECT ID_CLIENTE FROM CLIENTES) AND PG.ID = '" + Grupo + "'";
                            break;
                        case 10:
                            query = " SELECT DAV.ID AS ID_VENDA,'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, DAV.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, DVI.ITEM,DVI.ID_PRODUTO, PROD.PRODUTO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE AS CLIENTE," +
                                " DVI.VALOR_TOTAL AS VLRTOTAL, DVI.QUANTIDADE, DAV.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM DAV_ITENS DVI " +
                                " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                                " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' AND DAV.ID_CLIENTE = " + idCliente + " and DVI.ID_PRODUTO = " + idProduto + "";
                            break;
                        default:
                            break;
                    }
                    break;
                case 2: //nfce
                    switch (funcao)
                    {
                        case 1:
                            query = "SELECT NFCE.ID AS ID_VENDA, NFCE.TIPO_OPERACAO AS TIPO, NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR, " +
                                    " VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE, " +
                                    " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                    " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR LEFT JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                    " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'  and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCEI.CANCELADO = 'N' AND NFCE.ID_VENDEDOR = " + idVendedor + " AND NFCEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        case 2:
                            query = "SELECT NFCE.ID AS ID_VENDA, NFCE.TIPO_OPERACAO AS TIPO, NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR, " +
                                    " VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE, " +
                                    " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                    " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR LEFT JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                    " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCEI.CANCELADO = 'N' AND NFCE.ID_VENDEDOR = " + idVendedor + "";
                            break;
                        case 3:
                            query = "SELECT NFCE.ID AS ID_VENDA, NFCE.TIPO_OPERACAO AS TIPO, NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR, " +
                                    " VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE, " +
                                    " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                    " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR LEFT JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                    " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCEI.CANCELADO = 'N' AND NFCEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        case 4:
                            query = "SELECT NFCE.ID AS ID_VENDA, NFCE.TIPO_OPERACAO AS TIPO, NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR, " +
                                    " VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE, " +
                                    " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                    " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR LEFT JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                    " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCEI.CANCELADO = 'N' AND NFCEI.ID_PRODUTO = " + idProduto + " AND NFCE.ID_CLIENTE = " + idCliente + "";
                            break;
                        case 5:
                            query = "SELECT NFCE.ID AS ID_VENDA, NFCE.TIPO_OPERACAO AS TIPO, NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR, " +
                                    " VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE, " +
                                    " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                    " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR LEFT JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO " +
                                    " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCEI.CANCELADO = 'N' AND NFCE.ID_CLIENTE IN (SELECT ID_CLIENTE FROM CLIENTES) ";
                            break;
                        case 6:
                            query = " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' AND NFCE.ID_CLIENTE IN(SELECT ID_CLIENTE FROM CLIENTES) AND PG.ID = '" + Grupo + "'";
                            break;
                        case 10:
                            query = " SELECT NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO,NFCE.ID AS NROCUPOM, USR.USUARIO, NFCE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFCEI.ITEM, NFCEI.ID_PRODUTO, PROD.PRODUTO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE AS CLIENTE," +
                                " NFCEI.VALOR_TOTAL AS VLRTOTAL, NFCEI.QUANTIDADE, NFCE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'and NFCE.ID_CLIENTE = " + idCliente + " AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV' and NFCEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        default:
                            break;
                    }
                    break;
                case 3: //nfe
                    switch (funcao)
                    {
                        case 1:
                            query = "SELECT NFE.ID AS ID_VENDA,  'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM,  USR.USUARIO, NFE.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, " +
                                " PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '"+ dataFim + "' AND NFE.ID_VENDEDOR = "+ idVendedor + " AND NFEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        case 2:
                            query = "SELECT NFE.ID AS ID_VENDA,  'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM,  USR.USUARIO, NFE.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, " +
                                " PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFE.ID_VENDEDOR = " + idVendedor + "";
                            break;
                        case 3:
                            query = "SELECT NFE.ID AS ID_VENDA,  'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM,  USR.USUARIO, NFE.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, " +
                                " PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFEI.ID_PRODUTO = " + idProduto + "";
                            break;
                        case 4:
                            query = "SELECT NFE.ID AS ID_VENDA,  'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM,  USR.USUARIO, NFE.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, " +
                                " PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFEI.ID_PRODUTO = " + idProduto + "and NFE.ID_CLIENTE = " + idCliente + "";
                            break;
                        case 5:
                            query = "SELECT NFE.ID AS ID_VENDA,  'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM,  USR.USUARIO, NFE.ID_VENDEDOR, VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, " +
                                " PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'  ";
                            break;
                        case 6:
                            query = "SELECT NFE.ID AS ID_VENDA,'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM,USR.USUARIO,NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, " +
                                " NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM,PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO" +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE" +
                                " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE" +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR" +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND PG.ID = '" + Grupo + "'";
                            break;
                        case 10:
                            query = "SELECT NFE.ID AS ID_VENDA, 'NFE' AS TIPO,NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, NFE.ID_VENDEDOR,VDR.DESCRICAO AS VENDEDOR, NFEI.ITEM, NFEI.ID_PRODUTO, PROD.PRODUTO, " +
                                " NFE.ID_CLIENTE, CLI.RAZ_SOCIAL AS CLIENTE, NFEI.TOTAL_ITEM AS VLRTOTAL, NFEI.QUANTIDADE, NFE.DATA_VENDA AS DATACUPOM, PG.GRUPO FROM PRODUTOS PROD " +
                                " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                                " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                                " INNER JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                                " INNER JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                                " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO" +
                                " INNER JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                                " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'   AND NFE.ID_CLIENTE = " + idCliente + " and NFEI.ID_PRODUTO = " + idProduto + " ";
                            break;

                        default:
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
                    con.CommandText = "SELECT  FANTASIA, RAZ_SOCIAL, ENDER,ENDER_NUMERO,COMPLEMENTO, BAIRRO,CEP,TELEFONE,UF,MUNICIPIO, CNPJ, INSC_EST AS IE FROM EMITENTE";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.EMITENTE);

                    con.CommandText = query;
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.VENDAS);
                    return vendas;

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

        public DataSetVendas selectMovimento(string dataIni, string dataFim)
        {
            DataSetVendas vendas = new DataSetVendas();
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "SELECT  FANTASIA, RAZ_SOCIAL, ENDER,ENDER_NUMERO,COMPLEMENTO, BAIRRO,CEP,TELEFONE,UF,MUNICIPIO, CNPJ, INSC_EST AS IE FROM EMITENTE";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.EMITENTE);

                    con.CommandText = " SELECT 'ENTRADA' AS MOVIMENTO, NFE.ID AS ID_VENDA, 'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE,'' AS CLIENTE," +
                        " NFE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO, NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                        " INNER JOIN NFE_TOTAL_TIPO_PGTO NTP ON NTP.ID_NFE = NFE.ID " +
                        " INNER JOIN NFE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " GROUP BY NFE.ID , 'NFE' ,NFE.NFE_NUMERO , USR.USUARIO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL ,  NFE.DATA_VENDA ,FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAV.ID AS ID_VENDA, 'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE, '' AS CLIENTE, DAV.DATA_VENDA AS DATACUPOM, DPG.DESCRICAO AS FORMA_PGTO, " +
                        " DTP.VALOR AS TOTAL_PGTO, DPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM DAV_ITENS DVI " +
                        " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                        " INNER JOIN DAV_TOTAL_TIPO_PGTO DTP ON DTP.ID_VENDA_CABECALHO = DAV.ID " +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DPG ON DPG.ID = DTP.ID_TIPO_PAGAMENTO " +
                        " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' " +
                        " GROUP BY DAV.ID , 'DAV' , DAV.ID , USR.USUARIO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE , DAV.DATA_VENDA , DPG.DESCRICAO ,DTP.VALOR, DPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO, NFCE.ID AS NROCUPOM,  USR.USUARIO,  0 AS ID_CLIENTE,'' AS CLIENTE, NFCE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO," +
                        " NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                        " INNER JOIN NFCE_TOTAL_TIPO_PGTO NTP ON NTP.ID_VENDA_CABECALHO = NFCE.ID" +
                        " INNER JOIN NFCE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO" +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                        " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV'" +
                        " GROUP BY NFCE.ID , 'NFCE' ,NFCE.ID , USR.USUARIO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE , NFCE.DATA_VENDA , FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, RR.ID AS ID_VENDA,'RECEBIMENTO' AS TIPO,RR.ID AS NROCUPOM,USR.USUARIO,RR.ID_CLIENTE,case when CL.RAZ_SOCIAL is null or CL.RAZ_SOCIAL = '' then CL.CLIENTE else CL.RAZ_SOCIAL end AS CLIENTE, RR.DT_BAIXA AS DATACUPOM,DFPG.DESCRICAO AS FORMA_PGTO," +
                        " RR.VLR_BAIXA AS TOTAL_PGTO, DFPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT from RECIBO_RECEBER RR" +
                        " INNER JOIN CLIENTES CL ON CL.ID_CLIENTE = RR.ID_CLIENTE" +
                        " INNER JOIN RECIBO_TOTAL_TIPO_PGTO RTPG ON RTPG.ID_RECIBO = RR.ID" +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DFPG ON DFPG.ID = RTPG.ID_TIPO_PAGAMENTO" +
                        " INNER JOIN USUARIO USR ON USR.ID = RR.ID_OPERADOR" +
                        " where RR.DT_BAIXA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union" +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSG.ID AS ID_VENDA,'SANGRIA' AS TIPO,DAVSG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSG.JUSTIFICATIVA AS CLIENTE,DAVSG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO' AS FORMA_PGTO,-CAST(DAVSG.VALOR AS DECIMAL(18,2)) AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT" +
                        " FROM DAV_SANGRIA DAVSG " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSG.ID_USUARIO" +
                        " WHERE DAVSG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,DAVSP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSP.JUSTIFICATIVA AS CLIENTE,DAVSP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,DAVSP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM DAV_SUPRIMENTO DAVSP" +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSP.ID_USUARIO" +
                        " WHERE DAVSP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESG.ID AS ID_VENDA,'SANGRIA' AS TIPO,NFCESG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESG.JUSTIFICATIVA AS CLIENTE,NFCESG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO, -CAST(NFCESG.VALOR AS DECIMAL(18,2))AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SANGRIA NFCESG " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESG.ID_USUARIO " +
                        " WHERE NFCESG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,NFCESP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESP.JUSTIFICATIVA AS CLIENTE,NFCESP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,NFCESP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SUPRIMENTO NFCESP " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESP.ID_USUARIO " +
                        " WHERE NFCESP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "' ";// +
                        //" UNION " +
                        //" SELECT 'SAIDA' AS MOVIMENTO, CP.ID AS ID_VENDA, 'CONTAS PAGAS' AS TIPO, CP.NRO_NF AS NROCUPOM, USR.USUARIO, FR.ID_FORNECEDOR AS ID_CLIENTE, FR.RAZ_SOCIAL AS CLIENTE, CP.DT_QUITACAO AS DATACUPOM," +
                        //" RPGTOS.DESCRICAO AS FORMA_PGTO, RCPI.VALOR_BAIXADO AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM CONTAS_PAGAR CP " +
                        //" INNER JOIN RECIBO_PAGAR_ITENS RCPI ON RCPI.ID_CONTA = CP.ID" +
                        //" INNER JOIN RECIBO_PAGAR RCP ON RCP.ID = RCPI.ID_RECIBO_BAIXA" +
                        //" INNER JOIN RECIBO_PAGAR_PGTOS RPGTOS ON RPGTOS.ID_RECIBO_BAIXA = RCP.ID" +
                        //" LEFT JOIN USUARIO USR ON USR.ID = CP.ID_OPERADOR " +
                        //" INNER JOIN FORNECEDOR FR ON FR.ID_FORNECEDOR = CP.ID_FORNECEDOR " +
                        //" WHERE CP.DT_QUITACAO BETWEEN '" + dataIni + "' AND '" + dataFim + "'";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(vendas.VENDAS_CAIXA);
                    sucesso = true;
                    return vendas;

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

        public DataSetVendas selectMovimento(string dataIni, string dataFim, int tipo)
        {
            DataSetVendas vendas = new DataSetVendas();
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;
            string sql = "";
            switch (tipo)
            {
                case 0: //todos
                    sql = "SELECT 'ENTRADA' AS MOVIMENTO, NFE.ID AS ID_VENDA, 'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE,'' AS CLIENTE," +
                        " NFE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO, NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                        " INNER JOIN NFE_TOTAL_TIPO_PGTO NTP ON NTP.ID_NFE = NFE.ID " +
                        " INNER JOIN NFE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " GROUP BY NFE.ID , 'NFE' ,NFE.NFE_NUMERO , USR.USUARIO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL ,  NFE.DATA_VENDA ,FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAV.ID AS ID_VENDA, 'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE, '' AS CLIENTE, DAV.DATA_VENDA AS DATACUPOM, DPG.DESCRICAO AS FORMA_PGTO, " +
                        " DTP.VALOR AS TOTAL_PGTO, DPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM DAV_ITENS DVI " +
                        " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                        " INNER JOIN DAV_TOTAL_TIPO_PGTO DTP ON DTP.ID_VENDA_CABECALHO = DAV.ID " +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DPG ON DPG.ID = DTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' " +
                        " GROUP BY DAV.ID , 'DAV' , DAV.ID , USR.USUARIO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE , DAV.DATA_VENDA , DPG.DESCRICAO ,DTP.VALOR, DPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO, NFCE.ID AS NROCUPOM,  USR.USUARIO,  0 AS ID_CLIENTE,'' AS CLIENTE, NFCE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO," +
                        " NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                        " INNER JOIN NFCE_TOTAL_TIPO_PGTO NTP ON NTP.ID_VENDA_CABECALHO = NFCE.ID" +
                        " INNER JOIN NFCE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO" +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                        " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV'" +
                        " GROUP BY NFCE.ID , 'NFCE' ,NFCE.ID , USR.USUARIO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE , NFCE.DATA_VENDA , FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSG.ID AS ID_VENDA,'SANGRIA' AS TIPO,DAVSG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSG.JUSTIFICATIVA AS CLIENTE,DAVSG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO' AS FORMA_PGTO,-CAST(DAVSG.VALOR AS DECIMAL(18,2)) AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT" +
                        " FROM DAV_SANGRIA DAVSG " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSG.ID_USUARIO" +
                        " WHERE DAVSG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,DAVSP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSP.JUSTIFICATIVA AS CLIENTE,DAVSP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,DAVSP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM DAV_SUPRIMENTO DAVSP" +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSP.ID_USUARIO" +
                        " WHERE DAVSP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESG.ID AS ID_VENDA,'SANGRIA' AS TIPO,NFCESG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESG.JUSTIFICATIVA AS CLIENTE,NFCESG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO, -CAST(NFCESG.VALOR AS DECIMAL(18,2))AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SANGRIA NFCESG " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESG.ID_USUARIO " +
                        " WHERE NFCESG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,NFCESP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESP.JUSTIFICATIVA AS CLIENTE,NFCESP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,NFCESP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SUPRIMENTO NFCESP " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESP.ID_USUARIO " +
                        " WHERE NFCESP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "' " ;
                    break;
                case 1: //DAV
                    sql = " SELECT 'ENTRADA' AS MOVIMENTO, DAV.ID AS ID_VENDA, 'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE, '' AS CLIENTE, DAV.DATA_VENDA AS DATACUPOM, DPG.DESCRICAO AS FORMA_PGTO, " +
                        " DTP.VALOR AS TOTAL_PGTO, DPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM DAV_ITENS DVI " +
                        " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                        " INNER JOIN DAV_TOTAL_TIPO_PGTO DTP ON DTP.ID_VENDA_CABECALHO = DAV.ID " +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DPG ON DPG.ID = DTP.ID_TIPO_PAGAMENTO " +
                        " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DAV.CUPOM_CANCELADO = 'N' " +
                        " GROUP BY DAV.ID , 'DAV' , DAV.ID , USR.USUARIO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE , DAV.DATA_VENDA , DPG.DESCRICAO ,DTP.VALOR, DPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSG.ID AS ID_VENDA,'SANGRIA' AS TIPO,DAVSG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSG.JUSTIFICATIVA AS CLIENTE,DAVSG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO' AS FORMA_PGTO,-CAST(DAVSG.VALOR AS DECIMAL(18,2)) AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT" +
                        " FROM DAV_SANGRIA DAVSG " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSG.ID_USUARIO" +
                        " WHERE DAVSG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,DAVSP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSP.JUSTIFICATIVA AS CLIENTE,DAVSP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,DAVSP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM DAV_SUPRIMENTO DAVSP" +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSP.ID_USUARIO" +
                        " WHERE DAVSP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "'" ;
                    break;
                case 2: //NFCE
                    sql = " SELECT 'ENTRADA' AS MOVIMENTO, NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO, NFCE.ID AS NROCUPOM,  USR.USUARIO,  0 AS ID_CLIENTE,'' AS CLIENTE, NFCE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO," +
                        " NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                        " INNER JOIN NFCE_TOTAL_TIPO_PGTO NTP ON NTP.ID_VENDA_CABECALHO = NFCE.ID" +
                        " INNER JOIN NFCE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO" +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                        " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV'" +
                        " GROUP BY NFCE.ID , 'NFCE' ,NFCE.ID , USR.USUARIO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE , NFCE.DATA_VENDA , FPG.DESCRICAO ,NTP.VALOR,  FPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESG.ID AS ID_VENDA,'SANGRIA' AS TIPO,NFCESG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESG.JUSTIFICATIVA AS CLIENTE,NFCESG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO, -CAST(NFCESG.VALOR AS DECIMAL(18,2))AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SANGRIA NFCESG " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESG.ID_USUARIO " +
                        " WHERE NFCESG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,NFCESP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESP.JUSTIFICATIVA AS CLIENTE,NFCESP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,NFCESP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SUPRIMENTO NFCESP " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESP.ID_USUARIO " +
                        " WHERE NFCESP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "' " ;
                    break;
                case 3: //NFE
                    sql = "SELECT 'ENTRADA' AS MOVIMENTO, NFE.ID AS ID_VENDA, 'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE,'' AS CLIENTE," +
                        " NFE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO, NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                        " INNER JOIN NFE_TOTAL_TIPO_PGTO NTP ON NTP.ID_NFE = NFE.ID " +
                        " INNER JOIN NFE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " GROUP BY NFE.ID , 'NFE' ,NFE.NFE_NUMERO , USR.USUARIO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL ,  NFE.DATA_VENDA ,FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO ";                 
                    break;
                default:
                    break;
            }

            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "SELECT  FANTASIA, RAZ_SOCIAL, ENDER,ENDER_NUMERO,COMPLEMENTO, BAIRRO,CEP,TELEFONE,UF,MUNICIPIO, CNPJ, INSC_EST AS IE FROM EMITENTE";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.EMITENTE);

                    con.CommandText = sql;
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.VENDAS_CAIXA);
                    return vendas;

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

        public DataSetVendas selectMovimentoFormaPgto(string dataIni, string dataFim, int tipo, string FormasPgto)
        {
            DataSetVendas vendas = new DataSetVendas();
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;
            string sql = "";
            string filtro = FormasPgto.Substring(1);
            switch (tipo)
            {
                case 0: //todos
                    sql = "SELECT 'ENTRADA' AS MOVIMENTO, NFE.ID AS ID_VENDA, 'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE,'' AS CLIENTE," +
                        " NFE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO, NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                        " INNER JOIN NFE_TOTAL_TIPO_PGTO NTP ON NTP.ID_NFE = NFE.ID " +
                        " INNER JOIN NFE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND FPG.TIPO_PAGAMENTO IN ("+filtro+") " +
                        " GROUP BY NFE.ID , 'NFE' ,NFE.NFE_NUMERO , USR.USUARIO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL ,  NFE.DATA_VENDA ,FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAV.ID AS ID_VENDA, 'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE, '' AS CLIENTE, DAV.DATA_VENDA AS DATACUPOM, DPG.DESCRICAO AS FORMA_PGTO, " +
                        " DTP.VALOR AS TOTAL_PGTO, DPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM DAV_ITENS DVI " +
                        " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                        " INNER JOIN DAV_TOTAL_TIPO_PGTO DTP ON DTP.ID_VENDA_CABECALHO = DAV.ID " +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DPG ON DPG.ID = DTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DPG.TIPO_PAGAMENTO IN (" + filtro + ") AND DAV.CUPOM_CANCELADO = 'N' " +
                        " GROUP BY DAV.ID , 'DAV' , DAV.ID , USR.USUARIO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE , DAV.DATA_VENDA , DPG.DESCRICAO ,DTP.VALOR, DPG.TIPO_PAGAMENTO " +
                        " union " +
                        "  " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO, NFCE.ID AS NROCUPOM,  USR.USUARIO,  0 AS ID_CLIENTE,'' AS CLIENTE, NFCE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO," +
                        " NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                        " INNER JOIN NFCE_TOTAL_TIPO_PGTO NTP ON NTP.ID_VENDA_CABECALHO = NFCE.ID" +
                        " INNER JOIN NFCE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO" +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                        " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "'AND FPG.TIPO_PAGAMENTO IN (" + filtro + ") AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV'" +
                        " GROUP BY NFCE.ID , 'NFCE' ,NFCE.ID , USR.USUARIO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE , NFCE.DATA_VENDA , FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSG.ID AS ID_VENDA,'SANGRIA' AS TIPO,DAVSG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSG.JUSTIFICATIVA AS CLIENTE,DAVSG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO' AS FORMA_PGTO,-CAST(DAVSG.VALOR AS DECIMAL(18,2)) AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT" +
                        " FROM DAV_SANGRIA DAVSG " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSG.ID_USUARIO" +
                        " WHERE DAVSG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,DAVSP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSP.JUSTIFICATIVA AS CLIENTE,DAVSP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,DAVSP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM DAV_SUPRIMENTO DAVSP" +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSP.ID_USUARIO" +
                        " WHERE DAVSP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESG.ID AS ID_VENDA,'SANGRIA' AS TIPO,NFCESG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESG.JUSTIFICATIVA AS CLIENTE,NFCESG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO, -CAST(NFCESG.VALOR AS DECIMAL(18,2))AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SANGRIA NFCESG " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESG.ID_USUARIO " +
                        " WHERE NFCESG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,NFCESP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESP.JUSTIFICATIVA AS CLIENTE,NFCESP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,NFCESP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SUPRIMENTO NFCESP " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESP.ID_USUARIO " +
                        " WHERE NFCESP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "' ";
                    break;
                case 1: //DAV
                    sql = " SELECT 'ENTRADA' AS MOVIMENTO, DAV.ID AS ID_VENDA, 'DAV' AS TIPO, DAV.ID AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE, '' AS CLIENTE, DAV.DATA_VENDA AS DATACUPOM, DPG.DESCRICAO AS FORMA_PGTO, " +
                        " DTP.VALOR AS TOTAL_PGTO, DPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM DAV_ITENS DVI " +
                        " INNER JOIN DAV DAV ON DAV.ID = DVI.ID_DAV " +
                        " INNER JOIN DAV_TOTAL_TIPO_PGTO DTP ON DTP.ID_VENDA_CABECALHO = DAV.ID " +
                        " INNER JOIN DAV_FORMAS_PAGAMENTO DPG ON DPG.ID = DTP.ID_TIPO_PAGAMENTO " +
                        " INNER JOIN PRODUTOS PROD ON PROD.ID_PRODUTO = DVI.ID_PRODUTO " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = DAV.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAV.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE DAV.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND DPG.TIPO_PAGAMENTO IN (" + filtro + ") AND DAV.CUPOM_CANCELADO = 'N' " +
                        " GROUP BY DAV.ID , 'DAV' , DAV.ID , USR.USUARIO, DAV.ID_CLIENTE, DAV.NOME_CLIENTE , DAV.DATA_VENDA , DPG.DESCRICAO ,DTP.VALOR, DPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSG.ID AS ID_VENDA,'SANGRIA' AS TIPO,DAVSG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSG.JUSTIFICATIVA AS CLIENTE,DAVSG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO' AS FORMA_PGTO,-CAST(DAVSG.VALOR AS DECIMAL(18,2)) AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT" +
                        " FROM DAV_SANGRIA DAVSG " +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSG.ID_USUARIO" +
                        " WHERE DAVSG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "'" +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, DAVSP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,DAVSP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,DAVSP.JUSTIFICATIVA AS CLIENTE,DAVSP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,DAVSP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM DAV_SUPRIMENTO DAVSP" +
                        " INNER JOIN USUARIO USR ON USR.ID = DAVSP.ID_USUARIO" +
                        " WHERE DAVSP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "'";
                    break;
                case 2: //NFCE
                    sql = " SELECT 'ENTRADA' AS MOVIMENTO, NFCE.ID AS ID_VENDA, 'NFCE' AS TIPO, NFCE.ID AS NROCUPOM,  USR.USUARIO,  0 AS ID_CLIENTE,'' AS CLIENTE, NFCE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO," +
                        " NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFCE_ITENS NFCEI ON NFCEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFCE NFCE ON NFCE.ID = NFCEI.ID_NFCE" +
                        " INNER JOIN NFCE_TOTAL_TIPO_PGTO NTP ON NTP.ID_VENDA_CABECALHO = NFCE.ID" +
                        " INNER JOIN NFCE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO" +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFCE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCE.ID_USUARIO" +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO" +
                        " WHERE NFCE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND FPG.TIPO_PAGAMENTO IN (" + filtro + ") AND NFCEI.CANCELADO = 'N' and not NFCE.IMPORTACAO_ORIGEM = 'DAV'" +
                        " GROUP BY NFCE.ID , 'NFCE' ,NFCE.ID , USR.USUARIO, NFCE.ID_CLIENTE, NFCE.NOME_CLIENTE , NFCE.DATA_VENDA , FPG.DESCRICAO ,NTP.VALOR,  FPG.TIPO_PAGAMENTO " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESG.ID AS ID_VENDA,'SANGRIA' AS TIPO,NFCESG.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESG.JUSTIFICATIVA AS CLIENTE,NFCESG.DATA_SANGRIA AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO, -CAST(NFCESG.VALOR AS DECIMAL(18,2))AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SANGRIA NFCESG " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESG.ID_USUARIO " +
                        " WHERE NFCESG.DATA_SANGRIA BETWEEN '" + dataIni + "' AND '" + dataFim + "' " +
                        " union " +
                        " SELECT 'ENTRADA' AS MOVIMENTO, NFCESP.ID AS ID_VENDA,'SUPRIMENTO' AS TIPO,NFCESP.ID AS NROCUPOM,USR.USUARIO,0 AS ID_CLIENTE,NFCESP.JUSTIFICATIVA AS CLIENTE,NFCESP.DATA_SUPRIMENTO AS DATACUPOM," +
                        " 'DINHEIRO'AS FORMA_PGTO,NFCESP.VALOR AS TOTAL_PGTO, 'DN' AS SIGLA_FORMA_PGT FROM NFCE_SUPRIMENTO NFCESP " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFCESP.ID_USUARIO " +
                        " WHERE NFCESP.DATA_SUPRIMENTO BETWEEN '" + dataIni + "' AND '" + dataFim + "' ";
                    break;
                case 3: //NFE
                    sql = "SELECT 'ENTRADA' AS MOVIMENTO, NFE.ID AS ID_VENDA, 'NFE' AS TIPO, NFE.NFE_NUMERO AS NROCUPOM, USR.USUARIO, 0 AS ID_CLIENTE,'' AS CLIENTE," +
                        " NFE.DATA_VENDA AS DATACUPOM, FPG.DESCRICAO AS FORMA_PGTO, NTP.VALOR AS TOTAL_PGTO, FPG.TIPO_PAGAMENTO AS SIGLA_FORMA_PGT FROM PRODUTOS PROD " +
                        " INNER JOIN NFE_ITENS NFEI ON NFEI.ID_PRODUTO = PROD.ID_PRODUTO " +
                        " INNER JOIN NFE NFE ON NFE.ID = NFEI.ID_NFE " +
                        " INNER JOIN NFE_TOTAL_TIPO_PGTO NTP ON NTP.ID_NFE = NFE.ID " +
                        " INNER JOIN NFE_FORMAS_PAGAMENTO FPG ON FPG.ID = NTP.ID_TIPO_PAGAMENTO " +
                        " LEFT JOIN CLIENTES CLI ON CLI.ID_CLIENTE = NFE.ID_CLIENTE " +
                        " LEFT JOIN VENDEDOR VDR ON VDR.ID = NFE.ID_VENDEDOR " +
                        " INNER JOIN USUARIO USR ON USR.ID = NFE.ID_USUARIO " +
                        " LEFT JOIN PRODUTOS_GRUPO PG ON PG.ID = PROD.GRUPO " +
                        " WHERE NFE.CANCELADO = 'N' AND NFEI.ID_DOC_FISCAL_REF = 0 AND NFE.DATA_VENDA BETWEEN '" + dataIni + "' AND '" + dataFim + "' AND FPG.TIPO_PAGAMENTO IN (" + filtro + ")" +
                        " GROUP BY NFE.ID , 'NFE' ,NFE.NFE_NUMERO , USR.USUARIO, NFE.ID_CLIENTE, CLI.RAZ_SOCIAL ,  NFE.DATA_VENDA ,FPG.DESCRICAO ,NTP.VALOR, FPG.TIPO_PAGAMENTO ";
                    break;
                default:
                    break;
            }

            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "SELECT  FANTASIA, RAZ_SOCIAL, ENDER,ENDER_NUMERO,COMPLEMENTO, BAIRRO,CEP,TELEFONE,UF,MUNICIPIO, CNPJ, INSC_EST AS IE FROM EMITENTE";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    sucesso = true;
                    da.Fill(vendas.EMITENTE);

                    con.CommandText = sql;
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(vendas.VENDAS_CAIXA);
                    sucesso = true;
                    return vendas;

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

        public DataSetVendas selectFormasPgto(int tipoMovimento)
        {
            DataSetVendas vendas = new DataSetVendas();
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;
            string sql = "";

            switch (tipoMovimento)
            {
                case 0: //todos
                    sql = "select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from DAV_FORMAS_PAGAMENTO where visivel = 'S'" +
                        "union" +
                        " select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from NFE_FORMAS_PAGAMENTO where visivel = 'S'" +
                        " union" +
                        " select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from NFCE_FORMAS_PAGAMENTO where visivel = 'S'";
                    break;
                case 1: //dav
                    sql = "select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from DAV_FORMAS_PAGAMENTO where visivel = 'S'";
                    break;
                case 2: //nfce
                    sql = "select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from NFCE_FORMAS_PAGAMENTO where visivel = 'S'";
                    break;
                case 3://nfe
                    sql = "select TIPO_PAGAMENTO AS SIGLA, DESCRICAO from NFE_FORMAS_PAGAMENTO where visivel = 'S'";
                    break;
                default:
                    break;
            }

            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = sql;
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(vendas.FormasPgto);
                    sucesso = true;
                    return vendas;
                    
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
