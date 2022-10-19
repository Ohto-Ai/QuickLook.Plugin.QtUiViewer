
//#pragma comment(lib, "D:\\repos\\QUiViewer\\x64\\Release\\QUiViewerLib.lib")
extern "C" __declspec(dllimport) void initQtApplication();
extern "C" __declspec(dllimport) int renderQtUiFile(const char* path);

int main()
{
	initQtApplication();
	return renderQtUiFile(R"(D:\repos\course-in-school\course\multi-media-course\NotepadX\NotepadXWindow.ui)");
}