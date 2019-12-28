using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wsbToolSettings
{
    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }

        public IntPtr Handle
        {
            get { return _hwnd; }
        }

        private IntPtr _hwnd;
    }

    static class Program
    {
        public static IntPtr MainWindow;
        public static int ProcessID;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] CmdLine)
        {
            if(CmdLine.Length == 2)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
                Form1 form = new Form1();
                IntPtr window = (IntPtr)int.Parse(CmdLine[0]);
                MainWindow = window;
                ProcessID = int.Parse(CmdLine[1]);
                WindowWrapper ww = new WindowWrapper(window);
                form.ShowDialog(ww);
            }
        }
    }
}
