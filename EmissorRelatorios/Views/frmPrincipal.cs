using EmissorRelatorios.Controles;
using EmissorRelatorios.Modelos;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace EmissorRelatorios.Views
{
    public partial class frmPrincipal : Form
    {
        private ClsPrincipal principal;

        ClsUtil clsUtil = new ClsUtil();
        public static string strFBconexaoServer { get; set; }
        private static string IP_SERVIDOR { get; set; }
        private static string PORTA { get; set; }
        private static string RETAGUARDA { get; set; }

        //CASO NECESSITE QUE ELE PEGUE O ARQUIVO NO DIRETORIO QUE O PROGRAMA ESTIVER ARMAZENADO
        //System.AppDomain.CurrentDomain.BaseDirectory.ToString()
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        //@"C:\TSD\HOST\";
        private bool redeOnOff = false;
        public bool requisitosOK { get; set; } = false;

        private string valorReg;

        public frmPrincipal()
        {
            InitializeComponent();
            principal = new ClsPrincipal(this);
            principal.inicializar();
        }
        public bool getRequisitosOK()
        {
            return requisitosOK;
        }
        public void verificaVersaoCrystal()
        {
            bool exists = false;
            string[] listChaves;
            RegistryKey rK = Registry.LocalMachine.OpenSubKey("SOFTWARE");
            listChaves = rK.GetSubKeyNames();
            foreach (string item in listChaves)
            {
                if (item.Equals("SAP BusinessObjects")) { exists = true; }
            }
            if (Environment.Is64BitOperatingSystem)
            {
                if (exists) { valorReg = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Crystal Reports", "CRRuntime64Version", "N"); }
            }
            else
            {

                if (exists) { valorReg = (string)Registry.GetValue("HKEY_LOCAL_MACHINE\\Software\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Crystal Reports", "CRRuntime32Version", "N"); }
            }


            //if (exists) { valorReg = (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Installer", "BusinessObjects", "N"); }
            //RegistryKey rK = Registry.LocalMachine.OpenSubKey("SOFTWARE\\SAP BusinessObjects\\Crystal Reports for .NET Framework 4.0\\Crystal Reports");
            //valorReg = (string) rK.GetValue("CR4VSVersion");

            if (exists && valorReg != "13.0.27")
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    int resposta = clsUtil.MsgBox_Full("Atenção", "Seu sistema não tem os requisitos, deseja instalar agora?");
                    if (resposta == 1)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Requisitos\CRRuntime_64bit_13_0_27.msi");
                        }
                        catch (Exception e)
                        {
                            clsUtil.MsgBox(e.Message, MessageBoxIcon.Error);
                            throw;
                        }

                    }
                    else if (resposta == 0)
                    {

                        clsUtil.MsgBox("O sistema será fechado até devidas atualizações nos pré-requisitos", MessageBoxIcon.Information);
                        requisitosOK = false;
                    }
                }
                else
                {
                    int resposta = clsUtil.MsgBox_Full("Atenção", "Seu sistema não tem os requisitos, deseja instalar agora?");
                    if (resposta == 1)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Requisitos\CRRuntime_32bit_13_0_27.msi");
                        }
                        catch (Exception e)
                        {
                            clsUtil.MsgBox(e.Message, MessageBoxIcon.Error);
                            throw;
                        }

                    }
                    else if (resposta == 0)
                    {
                        clsUtil.MsgBox("O sistema será fechado até devidas atualizações nos pré-requisitos", MessageBoxIcon.Information);
                        requisitosOK = false;
                    }
                }
            }
            else if (!exists)
            {
                if (Environment.Is64BitOperatingSystem)
                {
                    int resposta = clsUtil.MsgBox_Full("Atenção", "Seu sistema não tem os requisitos, deseja instalar agora?");
                    if (resposta == 1)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Requisitos\CRRuntime_64bit_13_0_27.msi");
                        }
                        catch (Exception e)
                        {
                            clsUtil.MsgBox(e.Message, MessageBoxIcon.Error);
                            throw;
                        }

                    }
                    else if (resposta == 0)
                    {

                        clsUtil.MsgBox("O sistema será fechado até devidas atualizações nos pré-requisitos", MessageBoxIcon.Information);
                        requisitosOK = false;
                    }
                }
                else
                {
                    int resposta = clsUtil.MsgBox_Full("Atenção", "Seu sistema não tem os requisitos, deseja instalar agora?");
                    if (resposta == 1)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.BaseDirectory.ToString() + @"Requisitos\CRRuntime_32bit_13_0_27.msi");
                        }
                        catch (Exception e)
                        {
                            clsUtil.MsgBox(e.Message, MessageBoxIcon.Error);
                            throw;
                        }

                    }
                    else if (resposta == 0)
                    {
                        clsUtil.MsgBox("O sistema será fechado até devidas atualizações nos pré-requisitos", MessageBoxIcon.Information);
                        requisitosOK = false;
                    }
                }

            }
            else if (exists && valorReg.Equals("13.0.27"))
            {
                requisitosOK = true;
            }
        }


        private void rdbSaidaVenda_MouseClick(object sender, MouseEventArgs e)
        {
            frmSaida frmS = new frmSaida();
            frmS.ShowDialog();

        }

        private void Principal_Load(object sender, EventArgs e)
        {
          
           
        }

        private void btnSaidaVenda_MouseClick(object sender, MouseEventArgs e)
        {
            frmSaida frmS = new frmSaida();
            frmS.ShowDialog();
        }

        private void btnEntradaCompra_Click(object sender, EventArgs e)
        {
            frmEntrada frmE = new frmEntrada();
            frmE.ShowDialog();
        }

        private void btnEtiquetas_MouseClick(object sender, MouseEventArgs e)
        {
            frmEtiquetas frmEtq = new frmEtiquetas();
            frmEtq.ShowDialog();
        }
    }
}
