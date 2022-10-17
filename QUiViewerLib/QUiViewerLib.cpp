#include "QUiViewerLib.h"

#include <QApplication>
#include <QtUiTools/QtUiTools> 

int renderQtUiFile(const char* path)
{
#if defined(Q_OS_WIN)
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
#endif
    int argc = 0;
    QApplication app(argc, nullptr);
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

    return app.exec();
}
