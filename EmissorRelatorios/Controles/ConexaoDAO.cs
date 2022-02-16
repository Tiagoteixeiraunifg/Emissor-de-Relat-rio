using System;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;
using EmissorRelatorios.Modelos;
using System.Data;

namespace EmissorRelatorios.Controles
{
    public class ConexaoDAO
    {
        
        private static string strConexao = ClsPrincipal.strFBconexaoServer;
        private static FbConnection fbCnn;
        private static ClsUtil clsUtil;


        public ConexaoDAO()
        {

            fbCnn = new FbConnection(strConexao);

        }

        public ConexaoDAO(string str)
        {

            fbCnn = new FbConnection(str);
            

        }

        public FbConnection conectar()
        {
            if (fbCnn.State == ConnectionState.Closed)
            {
                try
                {
                    fbCnn.Open();
                }
                catch (Exception)
                {
                    clsUtil.MsgBox("Erro ao conectar com a base de Dados, confira a configuração!", MessageBoxIcon.Error);
                }

            }

            return fbCnn;
        }

        public FbConnection desconect()
        {
            if (fbCnn.State == ConnectionState.Open)
            {
                fbCnn.Close();
            }
            return fbCnn;
        }
    }
}
