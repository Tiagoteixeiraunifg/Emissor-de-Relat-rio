using System;
using EmissorRelatorios.Views;
using EmissorRelatorios.Controles;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql;
using FirebirdSql.Data.FirebirdClient;
using System.Windows.Forms;
using EmissorRelatorios.Modelos;

namespace EmissorRelatorios.Controles
{
    public class ConexaoDAO
    {
        
        private static string strConexao = frmPrincipal.strFBconexaoServer;
        private static FbConnection fbCnn;
        private static ClsUtil clsUtil;

        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public string GetIniValue(string section, string key, string nomeArquivo)
        {
            int chars = 256;
            StringBuilder buffer = new StringBuilder(chars);
            string sDefault = "";
            if (GetPrivateProfileString(section, key, sDefault, buffer, chars, nomeArquivo) != 0)
            {
                return buffer.ToString();
            }
            else
            {
                // Verifica o último erro Win32.
                int err = Marshal.GetLastWin32Error();
                return null;
            }
        }

        public Boolean Active(Boolean bActive, string conn = "")
        {
            if (bActive)
            {
                if (conn == "")
                {
                    fbCnn = new FbConnection(frmPrincipal.strFBconexaoServer);
                }
                else
                {
                    fbCnn = new FbConnection(conn);
                }
                fbCnn.Open();
                fbCnn.Close();
                return true;
            }
            else
            {
                fbCnn.Close();
                return false;
            }
        }




        public ConexaoDAO()
        {

            FbConnection fbCnn = new FbConnection(frmPrincipal.strFBconexaoServer);

        }

        public FbConnection conectar()
        {
            if (fbCnn.State == System.Data.ConnectionState.Closed)
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
            if (fbCnn.State == System.Data.ConnectionState.Open)
            {
                fbCnn.Close();
            }
            return fbCnn;
        }
    }
}
