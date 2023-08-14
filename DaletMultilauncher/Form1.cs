using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace DaletMultilauncher
{
    public partial class DaletMultilauncher : Form
    {
        public const UInt32 Infinite = 0xffffffff;
        public const Int32 Startf_UseStdHandles = 0x00000100;
        public const Int32 StdOutputHandle = -11;
        public const Int32 StdErrorHandle = -12;

        public String fromDaletLanToRttv = @"net use \\xx.xx.xx.xx\test\test\Temp\scripts_domain /user:rttv.ru\login password" +
               Environment.NewLine +
               @"Copy-Item '\\xx.xx.xx.xx\test\test\Temp\scripts_domain\fullReturnChangeDomain.ps1' -Destination 'C:\Temp'" +
               Environment.NewLine + "set-executionpolicy unrestricted" + Environment.NewLine + @"C:\Temp\fullReturnChangeDomain.ps1";
        public String fromRttvToDaletLan = @"net use \\xx.xx.xx.xx\test\test\Temp\scripts_domain /user:rttv.ru\login password" +
               Environment.NewLine +
               @"Copy-Item '\\xx.xx.xx.xx\test\test\Temp\scripts_domain\fullChangeDomain.ps1' -Destination 'C:\Temp'" +
               Environment.NewLine + "set-executionpolicy unrestricted" + Environment.NewLine + @"C:\Temp\fullChangeDomain.ps1";



        public DaletMultilauncher()
        {
            InitializeComponent();
            ActiveControl = label1;
        }

        public void execution(String dalet)
        {
             
            if (dalet.Equals("Dalet"))
            {
                try
                {
                    
                    changeDomain(fromDaletLanToRttv);
                    
                }
                catch (Exception er)
                {
                    Console.WriteLine("Exception: " + er.Message);
                    
                }
                finally
                {
                    Console.WriteLine("Error");
                }
            }    
                
            if (dalet.Equals("Reserve Dalet")) 
            {
                try
                {
                    changeDomain(fromRttvToDaletLan);
                    
                }
                catch (Exception er)
                {
                    Console.WriteLine("Exception: " + er.Message);
                    
                }
                finally
                {
                    Console.WriteLine("Error");
                }
            }
        }

        public void changeDomain(String changeDomain)
        {
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo("powershell.exe");
            p.StartInfo.Arguments = changeDomain;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();

            

        }


        private void btnMDaletClick(object sender, EventArgs e)
        {
            execution("Dalet");
            Close();
            
        }

        private void btnRDaletClick(object sender, EventArgs e)
        {
            execution("Reserve Dalet");
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}



/*Process[] processDalet = Process.GetProcessesByName("DaletGalaxy");

if (processDalet.Length > 0)
{
    foreach (Process p in processDalet)
    {
        p.Kill();
    }
}

Process.Start("\"C:\\\\Program Files\\\\Dalet\\\\DaletPlus\\\\bin\\\\DaletGalaxy.exe\"");*/
