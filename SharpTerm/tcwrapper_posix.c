#if defined(__unix__) || defined(__unix) || defined(unix) || (defined(__APPLE__) && defined(__MACH__))

#include <termios.h>
#include <unistd.h>
#include <stdlib.h>
/**
 * Allocate memory for a termios struct and get it with tcgetattr.
 * The caller is responsible for freeing the memory.
 */
struct termios *tcget(int fd) {
    struct termios *termios_p = (struct termios *)malloc(sizeof(struct termios));
    if (tcgetattr(fd, termios_p) != 0) {
        free(termios_p);
        return NULL;
    }
    return termios_p;
}

#else
#error "Should not be compiled on non-posix systems"
#endif