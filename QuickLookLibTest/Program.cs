using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickLookLibTest
{
    internal static class Program
    {
        [DllImport(@"QUiViewerLib.dll")]
        public static extern void initQtApplication();
        [DllImport(@"QUiViewerLib.dll")]
        public static extern int renderQtUiFile(string path);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            initQtApplication();
            renderQtUiFile(@"D:\repos\course-in-school\course\multi-media-course\NotepadX\NotepadXWindow.ui");
        }
    }
}
