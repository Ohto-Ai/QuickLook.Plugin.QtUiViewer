using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using QuickLook.Common.Plugin;

namespace QuickLook.Plugin.QtUiViewer
{
    public class Plugin : IViewer
    {
        public int Priority => 0;
        
        [DllImport(@".\QUiViewerLib.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]//qtdialog.dll
        public static extern int renderQtUiFile(string path);//声明qtdialog.dll里面的一个接口

        public void Init()
        {
        }

        public bool CanHandle(string path)
        {
            return !Directory.Exists(path) && path.ToLower().EndsWith(".zzz");
        }

        public void Prepare(string path, ContextObject context)
        {
            context.PreferredSize = new Size { Width = 600, Height = 400 };
        }

        public void View(string path, ContextObject context)
        {
            var viewer = new Label { Content = "I am a Label. I do nothing at all." };
            renderQtUiFile(path);
            context.ViewerContent = viewer;
            context.Title = $"{Path.GetFileName(path)}";

            context.IsBusy = false;
        }

        public void Cleanup()
        {
        }
    }
}
