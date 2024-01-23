using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LASConnector
{
    static class Program
    {
        static void MyHandler(Exception e)
        {
            //MessageBox.Show("프로그램에 오류가 발생했습니다.\n관리자에게 문의 하시기 바랍니다.\n\n(" + e.Message + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show(e.Message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        static void UiExceptionEventHandler(object sender, ThreadExceptionEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang: NonUiExceptionHandler {0}", args.Exception.Message));
            MyHandler(args.Exception);
        }

        static void NonUiExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("kskang: NonUiExceptionHandler {0}", ((Exception)args.ExceptionObject)).ToString());
            MyHandler((Exception)args.ExceptionObject);
        }


        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Process[] procs = Process.GetProcessesByName("LAS Connector");
            if (procs.Length > 1)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("kskang: procs = {0}, {1}", procs[0].ProcessName, procs[0].Id));

                MessageBox.Show("프로그램이 이미 실행되고 있습니다.\n다시 한번 확인해주시기 바랍니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 정상 동작 될 내용을 작성하면 됩니다.
            else
            {
                // For UI thread exceptions
                Application.ThreadException += new ThreadExceptionEventHandler(UiExceptionEventHandler);

                // Force all Windows Forms errors to go through our handler.
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

                // For non-UI thread exceptions
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(NonUiExceptionHandler);

                // Run
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}
