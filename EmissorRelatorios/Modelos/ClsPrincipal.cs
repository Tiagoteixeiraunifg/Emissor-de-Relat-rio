
using FirebirdSql.Data.FirebirdClient;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EmissorRelatorios.Modelos
{
    public class ClsPrincipal
    {
        private Form tela;
        ClsUtil clsUtil = new ClsUtil();
        public static string strFBconexaoServer { get; set; }
        private static string IP_SERVIDOR { get; set; }
        private static string PORTA { get; set; }
        private static string RETAGUARDA { get; set; }
        
        private static FbConnection fbCnn;


        //CASO NECESSITE QUE ELE PEGUE O ARQUIVO NO DIRETORIO QUE O PROGRAMA ESTIVER ARMAZENADO
        //System.AppDomain.CurrentDomain.BaseDirectory.ToString()
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //@"C:\TSD\HOST\";
        private bool redeOnOff = false;
        public bool requisitosOK { get; set; } = false;

        private string valorReg;

        public  ClsPrincipal(Object view) {
            this.tela = (Form) view;
        }

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

        private bool Active(bool bActive, string conn = "")
        {
            if (bActive)
            {
                if (conn == "")
                {
                    fbCnn = new FbConnection(strFBconexaoServer);
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

        public void inicializar() {
            bool ret = false;
            if (File.Exists(path + "Conexao.ini"))
            {

                IP_SERVIDOR = GetIniValue("CONEXAO", "IP_SERVIDOR", path + "Conexao.ini");
                PORTA = GetIniValue("CONEXAO", "PORTA", path + "Conexao.ini");
                RETAGUARDA = GetIniValue("CONEXAO", "RETAGUARDA", path + "Conexao.ini");
                strFBconexaoServer = @"User=SYSDBA;Password=masterkey;DataSource=" + IP_SERVIDOR + ";Database=" + RETAGUARDA + ";Port=" + PORTA + ";Dialect=3;Charset=NONE;Role=;Connection lifetime=0;Connection timeout=7;Pooling=True;Packet Size=8192;Server Type=0";
                ret = true;
                   
            }
            else
            {
                MessageBox.Show("Arquivo de configuração (" + path + "Conexao.ini) do Host não encontrado.\nVerifique se o Host está configurado e funcionando nesse computador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ret = false;
            }
            //Verifica se as bases de dados estão OK.

            if (!Active(true, strFBconexaoServer))
            {
                MessageBox.Show("Erro ao conectar com a base de dados do Host.\nVerifique se o Host está configurado e funcionando nesse computador.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ret = false;
            }

        }

    }
}
