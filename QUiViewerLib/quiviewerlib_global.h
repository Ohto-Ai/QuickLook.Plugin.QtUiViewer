#pragma once

#include <QtCore/qglobal.h>

#ifndef BUILD_STATIC
# if defined(QUIVIEWERLIB_LIB)
#  define QUIVIEWERLIB_EXPORT Q_DECL_EXPORT
# else
#  define QUIVIEWERLIB_EXPORT Q_DECL_IMPORT
# endif
#else
# define QUIVIEWERLIB_EXPORT
#endif
