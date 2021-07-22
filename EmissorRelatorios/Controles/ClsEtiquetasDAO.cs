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

    public class ClsEtiquetasDAO
    {
        public string retorno { get; set; }
        public bool sucesso { get; set; }

        

        private static DataTable dsV = new DataTable();
        private static DataSet dsView = new DataSet();

        public DataTable dsViewFull()
        {
            return dsV;
        }
        public DataTable getDsView(string notaDigitada) 
        {
            //aqui foi criado novo objeto do data table
            dsV = new DataTable();
            //aqui ajusto o data table com as colunas que serão usadas
            DataColumn id = new DataColumn();
            id.ColumnName = "_id";
            id.DataType = System.Type.GetType("System.Int32");
            id.AutoIncrement = true;
            id.AutoIncrementSeed = 1;
            id.AutoIncrementStep = 1;
            id.Unique = true;
            
            dsV.Columns.Add(id);
            dsV.Columns.Add("ID_PRODUTO", typeof(int));
            dsV.Columns.Add("GTIN", typeof(string));
            dsV.Columns.Add("PRODUTO", typeof(string));
            dsV.Columns.Add("VALOR_VENDA", typeof(decimal));
            dsV.Columns.Add("VALOR_ATACADO", typeof(decimal));
            dsV.Columns.Add("QTD", typeof(int));
            
            //aqui inicio a conexão
            ConexaoDAO cnn = new ConexaoDAO();
            FbDataAdapter da = null;
            //limpo o DataSet e DataTable
            dsView.Clear();
            dsV.Clear();
            
            try
            {
                using (var con = cnn.conectar().CreateCommand())
                {
                    con.CommandText = "select P.ID_PRODUTO, P.GTIN, P.PRODUTO, P.VALOR_VENDA, P.VALOR_ATACADO, cast(NTCD.QUANTIDADE as Integer) AS QTD from PRODUTOS P " +
                " INNER JOIN NOTA_COMPRA_DETALHE NTCD ON NTCD.ID_PRODUTO = P.ID_PRODUTO " +
                " INNER JOIN NOTA_COMPRA NTC ON NTC.ID = NTCD.ID_NFE " +
                " WHERE NTC.NOTA = "+notaDigitada+ " and NTC.NFE_STATUS = 'Concluido'" +
                " order by PRODUTO";
                    
                    da = new FbDataAdapter(con.CommandText, cnn.conectar());
                    da.Fill(dsView);
                    
                    //aqui repasso todo conteudo do DataSet para o DataTable
                    for (int i = 0; i < dsView.Tables[0].Rows.Count; i++) {
                       
                        DataRow rw = dsV.NewRow();
                        //rw["_id"] = i +1;
                        rw["ID_PRODUTO"] = int.Parse(dsView.Tables[0].Rows[i]["ID_PRODUTO"].ToString());
                        rw["GTIN"] = dsView.Tables[0].Rows[i]["GTIN"].ToString();
                        rw["PRODUTO"] = dsView.Tables[0].Rows[i]["PRODUTO"].ToString();
                        rw["VALOR_VENDA"] = decimal.Parse(dsView.Tables[0].Rows[i]["VALOR_VENDA"].ToString());
                        rw["VALOR_ATACADO"] = decimal.Parse(dsView.Tables[0].Rows[i]["VALOR_ATACADO"].ToString());
                        rw["QTD"] = int.Parse(dsView.Tables[0].Rows[i]["QTD"].ToString());
                        dsV.Rows.Add(rw);
                    }
                    

                    //aqui retorno o DataTable fortemente tipado
                    return dsV;
                }

            }
            catch (Exception e)
            {
                retorno = "Erro ao obter os dados." + e.Message;
            }
            finally
            {
                cnn.desconect();
            }
            return null;
          
        }
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
        public DataSetEtiquetas getProdutosNotaCompra(string notaDigitada)
        {

            this.sucesso = false;
            string notaRet = "";

            //aqui é criado o objeto com o DataSet fortemente tipado e os objetos de conexão

            DataSetEtiquetas ds = new DataSetEtiquetas();
            FbCommand command = new FbCommand();
            ConexaoDAO con = new ConexaoDAO();
            FbDataAdapter da;
            FbDataReader leitor;
            string sql = "select nota from nota_compra where nota = @nota and NFE_STATUS = 'Concluido'";
            string sql2 = "select P.ID_PRODUTO, P.GTIN, P.PRODUTO, P.VALOR_VENDA, P.VALOR_ATACADO, cast(NTCD.QUANTIDADE as Integer) AS QTD  from PRODUTOS P " +
                " INNER JOIN NOTA_COMPRA_DETALHE NTCD ON NTCD.ID_PRODUTO = P.ID_PRODUTO " +
                " INNER JOIN NOTA_COMPRA NTC ON NTC.ID = NTCD.ID_NFE " +
                " WHERE NTC.NOTA = @nota and NTC.NFE_STATUS = 'Concluido'" +
                " order by PRODUTO";
            try
            {
               
                // executando comandos preliminares no banco de dados
                command.CommandText = sql;
                //limpa os parametros existentes na instancia
                command.Parameters.Clear();
                command.CommandType = CommandType.Text;
                //tratamento no parametro para impedir que só entre numeros no filtro
                try
                {
                    command.Parameters.Add("@nota", FbDbType.Integer).Value = int.Parse(notaDigitada);
                }
                catch (Exception)
                {
                    retorno = ("Nota digitada: " + notaDigitada + " não encontrada ou não corresponde a um numero de nota!");
                    sucesso = false;
                    return ds;
                    con.desconect();
                }
                
                command.Connection = con.conectar();
                command.ExecuteNonQuery();
                //executa a leitura da script executado
                leitor = command.ExecuteReader();

                //descarregando a leitura do cliente nas variaveis
         
                if (!leitor.HasRows)
                {
                    retorno = ("Nota não encontrada!");
                    sucesso = false;
                }
                else
                {   //se o leitor não encontrar nada aqui ele retorna que não encontrou se encontrar ele segue
                    while (leitor.Read())
                    {
                        
                        notaRet = leitor.GetString(0);
                        if (notaRet.Equals(notaDigitada)) {
                            retorno = "Nota n "+ notaDigitada + " encontrada!";
                            sucesso = true;
                        }
                    }
                    if (sucesso)
                    {
                        retorno = "Nota n " + notaDigitada + " encontrada!";
                    }
                    else
                    {
                        retorno = ("Nota n " + notaDigitada + " não encontrada!");
                        sucesso = false;
                    }
                    con.desconect();
                }
                // se a nota existir ele vai alimentar o DataSet para a impressão
                if (notaRet.Equals(notaDigitada)) {

                    
                    ds.Clear();
                    try
                    {
                        FbCommand cmd2 = new FbCommand();
                        FbDataReader leitor2;
                        cmd2.CommandText = sql2;
                        //limpa os parametros existentes na instancia
                        cmd2.Parameters.Clear();
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.Add("@nota", notaDigitada);
                        cmd2.Connection = con.conectar();
                        cmd2.ExecuteNonQuery();
                        //executa a leitura da script executado
                        leitor2 = cmd2.ExecuteReader();
                       
                        if (!leitor2.HasRows)
                        {
                            retorno = ("registros não encontrados!");
                            sucesso = false;
                        }
                        else
                        {

                            
                            while (leitor2.Read())
                            {
                                //pegando o valor que está guardado no banco com a quantidade do item
                                int valor = leitor2.GetInt32(5);
                                if ( valor > 1)   // para valores maiores que 1 ele multiplica as linhas pela quantidade
                                {
                                    for (int i = 0; i < valor; i++) 
                                    {
                                        DataRow row = ds.Tables["0"].NewRow();
                                        row["ID_PRODUTO"] = leitor2.GetInt32(0);
                                        row["GTIN"] = leitor2.GetString(1);
                                        row["PRODUTO"] = leitor2.GetString(2);
                                        row["VALOR_VENDA"] = leitor2.GetDecimal(3);
                                        row["VALOR_ATACADO"] = leitor2.GetDecimal(4);
                                        ds.Tables[0].Rows.Add(row);
                                    }
                                }
                                else if (valor == 1) 
                                {
                                    DataRow row2 = ds.Tables["0"].NewRow();
                                    row2["ID_PRODUTO"] = leitor2.GetInt32(0);
                                    row2["GTIN"] = leitor2.GetString(1);
                                    row2["PRODUTO"] = leitor2.GetString(2);
                                    row2["VALOR_VENDA"] = leitor2.GetDecimal(3);
                                    row2["VALOR_ATACADO"] = leitor2.GetDecimal(4);
                                    ds.Tables[0].Rows.Add(row2);
                                }
                                
                            }
                            retorno = "encontrado!";
                            sucesso = true;
                            getDsView(notaDigitada);
                            return ds;
                            
                        }

                    }
                    catch (Exception e)
                    {
                        retorno = "Erro ao obter os dados." + e.Message;
                        sucesso = false;
                    }
                    finally
                    {
                        con.desconect();
                    }


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

            return ds;

        }
    }
}

