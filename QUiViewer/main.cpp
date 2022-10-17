#include <QApplication>
#include <QtUiTools/QtUiTools> 

int main(int argc, char *argv[])
{
#if defined(Q_OS_WIN)
    QCoreApplication::setAttribute(Qt::AA_EnableHighDpiScaling);
#endif
    QApplication app(argc, argv);
    QUiLoader loader;
    QFile ui_file;
	
    if (argc != 2)
    {
        return -1;
    }
    ui_file.setFileName(argv[1]);
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
