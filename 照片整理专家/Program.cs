using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 照片整理专家
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Action run = () =>
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmFramework());
            };
            WindowsIdentity wi = WindowsIdentity.GetCurrent();
            bool runAsAdmin = wi != null && new WindowsPrincipal(wi).IsInRole(WindowsBuiltInRole.Administrator);
            if (!runAsAdmin)
            {
                try
                {
                    //不可能以管理员方式直接启动一个 ClickOnce 部署的应用程序，所以尝试以管理员方式启动一个新的进程
                    Process.Start(new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase) { UseShellExecute = true, Verb = "runas" });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("以管理员方式启动失败，将尝试以普通方式启动。{0}{1}", Environment.NewLine, ex), "以管理员方式启动失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    run();//以管理员方式启动失败，则尝试普通方式启动
                }
                Application.Exit();
            }
            else
            {
                run();
            }

        }
    }
}
