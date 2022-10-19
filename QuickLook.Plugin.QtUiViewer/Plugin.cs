using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using QuickLook.Common.Plugin;

namespace QuickLook.Plugin.QtUiViewer
{
    public class Plugin : IViewer
    {
        public int Priority => 0;

        [DllImport(@"QUiViewerLib.dll")]
        public static extern void initQtApplication();
        [DllImport(@"QUiViewerLib.dll")]
        public static extern int renderQtUiFile(string path);

        public void Init()
        {
            initQtApplication();
        }

        public bool CanHandle(string path)
        {
            return !Directory.Exists(path) && path.ToLower().EndsWith(".ui");
        }

        public void Prepare(string path, ContextObject context)
        {
            context.PreferredSize = new Size { Width = 600, Height = 400 };
        }

        public void View(string path, ContextObject context)
        {
            //var viewer = new Label { Content = "I am a Label. I do nothing at all." };
            renderQtUiFile(path);
            //context.ViewerContent = viewer;
            //context.Title = $"{Path.GetFileName(path)}";

            context.IsBusy = false;
        }

        public void Cleanup()
        {
        }
    }
}
