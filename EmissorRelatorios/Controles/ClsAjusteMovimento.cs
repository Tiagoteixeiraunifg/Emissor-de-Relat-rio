using EmissorRelatorios.DadosTemp;
using EmissorRelatorios.Modelos;
using EmissorRelatorios.Views;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmissorRelatorios.Controles
{
    class ClsAjusteMovimento
    {
        private string retorno;
        private bool sucesso;
        private DataSetVendas estoque = new DataSetVendas();
        private int contador = 1;
        private string saldo = "";
        public DataSetVendas selectEstoque()
        {
            
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da;
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select id_produto, estoque from produtos";
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(estoque.list_estq);
                    return estoque;
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

        private string buscaEstoque(int id_produto, string movimento)
        {
            
            string saida = "";
            for(int i = 0; i < estoque.list_estq.Count; i++)
            {
                if(estoque.list_estq[i].id_produto == id_produto)
                {
                    saida = estoque.list_estq[i].estoque;
                    estoque.list_estq[i].estoque = (decimal.Parse(saida.Replace(',','.')) + decimal.Parse(movimento)).ToString();
                    saldo = estoque.list_estq[i].estoque;
                    break;
                }
            }
            return saida;
        }

        public string dataFormatoUS(string dataEntrada)
        {
            //28/05/2021 00:00:00
            //10-10-2010
            String dia = dataEntrada.Substring(0, 2);
            String mes = dataEntrada.Substring(3, 5);
            String ano = dataEntrada.Substring(6, 11);
            String dataSaida = ano + "/" + mes + "/" + dia;
            return dataSaida;
        }

        private void geraTxtUpdate(DataSetVendas dsvendas) {
            if (!File.Exists(frmPrincipal.path + "update.sql"))
            {
                FileStream file;
                file =  File.Create(frmPrincipal.path + "update.sql");
                file.Close();
               
            }

            StreamWriter str;
            str = File.CreateText(frmPrincipal.path + "update.sql");
            for (int i = 0; i < estoque.historico.Count; i++)
            {
                
                str.WriteLine("update PRODUTOS_MOVIMENTACAO  set DT_MOVIMENTO = '"+ estoque.historico[i].DT_MOVIMENTO + "', HR_MOVIMENTO = '"+estoque.historico[i].HR_MOVIMENTO+"', ID_PRODUTO = "+ estoque.historico[i] .ID_PRODUTO+ ", ID_USUARIO ="+ estoque.historico[i] .ID_USUARIO+ " , ID_ORIGEM = "+ estoque.historico[i].ID_ORIGEM + ", TP_ORIGEM =  '"+estoque.historico[i].TP_ORIGEM+"', HISTORICO = '"+ estoque.historico[i].HISTORICO + "', ACAO = '"+ estoque.historico[i].ACAO + "', MOVIMENTO = "+ estoque.historico[i].MOVIMENTO + ", ESTOQUE = "+ estoque.historico[i].ESTOQUE + ", SALDO ="+ estoque.historico[i].SALDO + " where ID_ORIGEM = "+ estoque.historico[i].ID_ORIGEM + " and ID_PRODUTO = "+estoque.historico[i].ID_PRODUTO+"; ");
                

            }
            str.Close();

        }

        private void geraTxtInsert(DataSetVendas dsvendas)
        {
            if (!File.Exists(frmPrincipal.path + "insert.sql"))
            {
                FileStream file;
                file = File.Create(frmPrincipal.path + "insert.sql");
                file.Close();

            }

            StreamWriter str;
            str = File.CreateText(frmPrincipal.path + "insert.sql");
            for (int i = 0; i < estoque.historico.Count; i++)
            {

                //str.WriteLine("update PRODUTOS_MOVIMENTACAO  set DT_MOVIMENTO = '" + estoque.historico[i].DT_MOVIMENTO + "', HR_MOVIMENTO = '" + estoque.historico[i].HR_MOVIMENTO + "', ID_PRODUTO = " + estoque.historico[i].ID_PRODUTO + ", ID_USUARIO =" + estoque.historico[i].ID_USUARIO + " , ID_ORIGEM = " + estoque.historico[i].ID_ORIGEM + ", TP_ORIGEM =  '" + estoque.historico[i].TP_ORIGEM + "', HISTORICO = '" + estoque.historico[i].HISTORICO + "', ACAO = '" + estoque.historico[i].ACAO + "', MOVIMENTO = " + estoque.historico[i].MOVIMENTO + ", ESTOQUE = " + estoque.historico[i].ESTOQUE + ", SALDO =" + estoque.historico[i].SALDO + " where ID_ORIGEM = " + estoque.historico[i].ID_ORIGEM + " and ID_PRODUTO = " + estoque.historico[i].ID_PRODUTO + "; ");
                str.WriteLine("INSERT INTO PRODUTOS_MOVIMENTACAO(DT_MOVIMENTO,  HR_MOVIMENTO,  ID_PRODUTO,  ID_USUARIO,  ID_ORIGEM,  TP_ORIGEM,  HISTORICO,  ACAO,  MOVIMENTO,  ESTOQUE,  SALDO)" +
                    " VALUES(   '" + estoque.historico[i].DT_MOVIMENTO + "'  /*DT_MOVIMENTO*/,  '" + estoque.historico[i].HR_MOVIMENTO + "'  /*HR_MOVIMENTO*/,   " + estoque.historico[i].ID_PRODUTO + "  /*ID_PRODUTO*/, " + estoque.historico[i].ID_USUARIO + "  /*ID_USUARIO*/,  " + estoque.historico[i].ID_ORIGEM + "  /*ID_ORIGEM*/,  '" + estoque.historico[i].TP_ORIGEM + "'  /*TP_ORIGEM*/, '" + estoque.historico[i].HISTORICO + "'  /*HISTORICO*/,  'Saida DAV'  /*ACAO*/,  " + estoque.historico[i].MOVIMENTO + " /*MOVIMENTO*/, " + estoque.historico[i].ESTOQUE + "  /*ESTOQUE*/, " + estoque.historico[i].SALDO + "  /*SALDO*/);");    

            }
            str.Close();

        }
        private void geraTxtDelete(DataSetVendas dsvendas)
        {
            if (!File.Exists(frmPrincipal.path + "delete.sql"))
            {
                FileStream file;
                file = File.Create(frmPrincipal.path + "delete.sql");
                file.Close();

            }

            StreamWriter str;
            str = File.CreateText(frmPrincipal.path + "delete.sql");
            for (int i = 0; i < estoque.historico.Count; i++)
            {

                str.WriteLine("DELETE FROM PRODUTOS_MOVIMENTACAO WHERE ID_ORIGEM = " + estoque.historico[i].ID_ORIGEM + " ; "); 


            }
            str.Close();

        }


        public DataSetVendas selectHist()
        {
            selectEstoque();
            FbCommand command = new FbCommand();
            ConexaoDAO con = new ConexaoDAO();
            FbDataAdapter da;
            try
            {
                // executando comandos preliminares no banco de dados
                command.CommandText = "select dv.DATA_VENDA as DT_MOVIMENTO, dv.HORA_VENDA as HR_MOVIMENTO, dvi.ID_PRODUTO AS ID_PRODUTO, dv.ID_USUARIO, dv.id as ID_ORIGEM, 'Venda DAV' AS TP_ORIGEM, " +
                    " ('Venda DAV ID:' || cast(DV.ID as Varchar(50)) || '  Item:' || cast(dvi.ITEM as Varchar(50)) || '  Data Saída:' || cast(dv.DATA_VENDA as Varchar(50)) || '   Cliente: ' || cast(case when CL.RAZ_SOCIAL is null then '' else CL.RAZ_SOCIAL end as varchar(500))  || '') AS HISTORICO," +
                    " 'Saída(Venda)' AS ACAO, -CAST(DVI.QUANTIDADE AS DECIMAL(18, 4)) AS MOVIMENTO,  P.ESTOQUE as ESTOQUE, SUM(P.ESTOQUE - DVI.QUANTIDADE) AS SALDO " +
                    " from dav dv " +
                    " inner join DAV_ITENS dvi on dvi.ID_DAV = dv.ID " +
                    " LEFT JOIN CLIENTES CL ON CL.ID_CLIENTE = DV.ID_CLIENTE " +
                    " INNER JOIN PRODUTOS P ON P.ID_PRODUTO = dvi.ID_PRODUTO " +
                    " where dv.id not in (select id_origem from PRODUTOS_MOVIMENTACAO) and dv.DATA_VENDA between '2021/05/28' and '2021/06/01' and dv.CUPOM_CANCELADO = 'N' and dvi.CANCELADO = 'N' " +
                    " GROUP BY dv.DATA_VENDA ,dv.HORA_VENDA ,dvi.ID_PRODUTO ,dv.ID_USUARIO,dv.id, 'Venda DAV' , " +
                    " ('Venda DAV ID:' || cast(DV.ID as Varchar(50)) || '  Item:' || cast(dvi.ITEM as Varchar(50)) || '  Data Saída:' || cast(dv.DATA_VENDA as Varchar(50)) || '   Cliente: ' || cast(case when CL.RAZ_SOCIAL is null then '' else CL.RAZ_SOCIAL end as varchar(500)) || '') ," +
                    " 'Saída(Venda)' ,-CAST(DVI.QUANTIDADE AS DECIMAL(18, 4)), P.ESTOQUE";
                //limpa os parametros existentes na instancia
                command.Parameters.Clear();
                command.CommandType = CommandType.Text;
                command.Connection = con.conectar();
                command.ExecuteNonQuery();
                //instancia o leitor
                FbDataReader leitor;
                //executa a leitura da script executado
                leitor = command.ExecuteReader();
                leitor.Read();

                //descarregando a leitura do cliente nas variaveis

                if (leitor.HasRows == false)
                {
                    retorno = ("registros não encontrados!");

                }
                else
                {
                    while(leitor.Read())

                    {
                        DataRow row = estoque.Tables["HISTORICO"].NewRow();
                        row["DT_MOVIMENTO"] = leitor.GetDateTime(0).ToString("yyyy/MM/dd");
                        row["HR_MOVIMENTO"] = leitor.GetString(1);
                        row["ID_PRODUTO"] = leitor.GetInt32(2);
                        row["ID_USUARIO"] = leitor.GetInt32(3);
                        row["ID_ORIGEM"] = leitor.GetInt32(4);
                        row["TP_ORIGEM"] = leitor.GetString(5);
                        row["HISTORICO"] = leitor.GetString(6);
                        row["ACAO"] = leitor.GetString(7);
                        row["MOVIMENTO"] = leitor.GetString(8);
                        row["ESTOQUE"] = buscaEstoque(leitor.GetInt32(2), leitor.GetString(8));
                        row["SALDO"] = saldo;
                        estoque.Tables["HISTORICO"].Rows.Add(row);
                        contador ++;
                        

                    }
                    retorno = "Cliente encontrado!";
                    geraTxtUpdate(estoque);
                    geraTxtInsert(estoque);
                    ClsUtil clsUtil = new ClsUtil();
                    clsUtil.MsgBox("Terminou aqui insert e update!", System.Windows.Forms.MessageBoxIcon.Information);
                    return estoque;
                    
                }

            }
            catch (FbException e)
            {
                retorno = "Erro ao obter dados: " + e;
                sucesso = false;
                
            }
            finally
            {
                con.desconect();
            }

            return estoque;

        }

        

        public DataSetVendas selectDavMovDel()
        {
            selectEstoque();
            if(estoque.historico.Count > 0)
            {
                estoque.historico.Clear();
            }
            FbCommand command = new FbCommand();
            ConexaoDAO con = new ConexaoDAO();
            FbDataAdapter da;
            try
            {
                string sql =    "select dv.id as ID_ORIGEM" +
                                " from dav dv" +
                                " inner join DAV_ITENS dvi on dvi.ID_DAV = dv.ID" +
                                " LEFT JOIN CLIENTES CL ON CL.ID_CLIENTE = DV.ID_CLIENTE" +
                                " INNER JOIN PRODUTOS P ON P.ID_PRODUTO = dvi.ID_PRODUTO" +
                                " where dv.id not in (select id_origem from PRODUTOS_MOVIMENTACAO) and dv.DATA_VENDA between '2021/05/28' and '2021/06/01' and dv.CUPOM_CANCELADO = 'N' and dvi.CANCELADO = 'N' /*AND  P.ID_PRODUTO = 9*/" +
                                " GROUP BY dv.id";
                // executando comandos preliminares no banco de dados
                command.CommandText = sql;
                //limpa os parametros existentes na instancia
                command.Parameters.Clear();
                command.CommandType = CommandType.Text;
                command.Connection = con.conectar();
                command.ExecuteNonQuery();
                //instancia o leitor
                FbDataReader leitor;
                //executa a leitura da script executado
                leitor = command.ExecuteReader();
                leitor.Read();

                //descarregando a leitura do cliente nas variaveis

                if (leitor.HasRows == false)
                {
                    retorno = ("registros não encontrados!");

                }
                else
                {
                    while (leitor.Read())

                    {
                        DataRow row = estoque.Tables["HISTORICO"].NewRow();
                        
                        row["ID_ORIGEM"] = leitor.GetInt32(0);
                        
                        estoque.Tables["HISTORICO"].Rows.Add(row);
                        contador++;


                    }
                    retorno = "encontrado!";
                    geraTxtDelete(estoque);
                    ClsUtil clsUtil = new ClsUtil();
                    clsUtil.MsgBox("Terminou aqui o Delete!", System.Windows.Forms.MessageBoxIcon.Information);
                    return estoque;

                }

            }
            catch (FbException e)
            {
                retorno = "Erro ao obter dados: " + e;
                sucesso = false;

            }
            finally
            {
                con.desconect();
            }

            return estoque;

        }
    }
}
