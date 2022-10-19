#include "QUiViewerLib.h"
#include <QApplication>
#include <QtUiTools/QtUiTools> 

void initQtApplication()
{
#if defined(Q_OS_WIN)
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
#endif
    int argc = 0;
    new QApplication(argc, nullptr);
}
int renderQtUiFile(const char* path)
{
    QUiLoader loader;
    QFile ui_file;

    ui_file.setFileName(path);
    ui_file.open(QFile::ReadOnly);
    QDir::setCurrent(QFileInfo(ui_file).absolutePath());
    if (ui_file.isOpen())
    {
		QWidget* w = loader.load(&ui_file);
        ui_file.close();
        w->show();
    }
    else
    {
        return -1;
    }

    return qApp->exec();
}
