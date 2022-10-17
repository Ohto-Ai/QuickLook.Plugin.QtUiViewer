Remove-Item QuickLook.Plugin.QtUiViewer.qlplugin -ErrorAction SilentlyContinue

$files = Get-ChildItem -Path QuickLook.Plugin.QtUiViewer\bin\Release\ -Exclude *.pdb,*.xml
Compress-Archive $files QuickLook.Plugin.QtUiViewer.zip
Move-Item QuickLook.Plugin.QtUiViewer.zip QuickLook.Plugin.QtUiViewer.qlplugin