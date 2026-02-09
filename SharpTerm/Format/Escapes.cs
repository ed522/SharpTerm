namespace SharpTerm.Format;

public static class Escapes
{

    // from ECMA 48 https://ecma-international.org/wp-content/uploads/ECMA-48_4th_edition_december_1986.pdf
    // and a linux man page for nonstandard codes https://man7.org/linux/man-pages/man4/console_codes.4.html
    
    // C0 codes
    public const string C0_NUL = "\0";
    public const string C0_ESC = "\u001b";
    public const string C0_BELL = "\a";
    public const string C0_CARRIAGE_RETURN = "\r";
    public const string C0_LINE_FEED = "\n";
    public const string C0_FORM_FEED = "\f";
    public const string C0_BACKSPACE = "\b";
    public const string C0_TAB = "\t";
    public const string C0_VERTICAL_TAB = "\v";

    // fundamental codes
    public const string CSI = C0_ESC + "[";
    public const string OSC = C0_ESC + "]";

    public const string CSI_STATUS_REPORT = "0n";

    // SGR (graphics)
    // basic appearance/rich text
    public const string SGR_TERM = "m";
    public const string SGR_RESET = "0";
    public const string SGR_BOLD = "1";
    public const string SGR_FAINT = "2";
    public const string SGR_ITALIC = "3";
    public const string SGR_UNDERLINE = "4";
    public const string SGR_BLINK_SLOW = "5";
    public const string SGR_BLINK_FAST = "6";
    public const string SGR_NEGATIVE = "7";
    public const string SGR_CONCEAL = "8";
    public const string SGR_STRIKE = "9";
    public const string SGR_FRAKTUR = "20";
    public const string SGR_DOUBLE_UNDERLINE = "21";
    public const string SGR_BOXED = "51";
    public const string SGR_CIRCLED = "52";
    public const string SGR_OVERLINED = "53";
    public const string SGR_NOT_BOXED_CIRCLED = "54";
    public const string SGR_NOT_OVERLINED = "55";
    // ideogram modes intentionally omitted
    
    // resets
    public const string SGR_NO_BOLD_FAINT = "22";
    public const string SGR_NO_ITALIC_FRAKTUR = "23";
    public const string SGR_NO_UNDERLINE = "24";
    public const string SGR_NO_BLINK = "25";
    // 26 reserved
    public const string SGR_NO_NEGATIVE = "27";
    public const string SGR_NO_CONCEAL = "28";
    public const string SGR_NO_STRIKE = "29";

    // colours
    public const string SGR_FG_BLACK = "30";
    public const string SGR_FG_RED = "31";
    public const string SGR_FG_GREEN = "32";
    public const string SGR_FG_YELLOW = "33";
    public const string SGR_FG_BLUE = "34";
    public const string SGR_FG_MAGENTA = "35";
    public const string SGR_FG_CYAN = "36";
    public const string SGR_FG_WHITE = "37";
    // 38 reserved
    public const string SGR_FG_DEFAULT = "39";

    public const string SGR_FG_BRIGHT_BLACK = "90";
    public const string SGR_FG_BRIGHT_RED = "91";
    public const string SGR_FG_BRIGHT_GREEN = "92";
    public const string SGR_FG_BRIGHT_YELLOW = "93";
    public const string SGR_FG_BRIGHT_BLUE = "94";
    public const string SGR_FG_BRIGHT_MAGENTA = "95";
    public const string SGR_FG_BRIGHT_CYAN = "96";
    public const string SGR_FG_BRIGHT_WHITE = "97";

    // extended colour
    // 256 = SGR + 256 introducer + color # 0-255 + ;m
    public const string SGR_FG_HICOLOR_256 = "38;5";
    // true = SGR + true color introducer + R + G + B + ;m
    public const string SGR_FG_HICOLOR_TRUE = "38;2";

    public const string SGR_BG_BLACK = "40";
    public const string SGR_BG_RED = "41";
    public const string SGR_BG_GREEN = "42";
    public const string SGR_BG_YELLOW = "43";
    public const string SGR_BG_BLUE = "44";
    public const string SGR_BG_MAGENTA = "45";
    public const string SGR_BG_CYAN = "46";
    public const string SGR_BG_WHITE = "47";
    // 48 reserved
    public const string SGR_BG_DEFAULT = "49";

    public const string SGR_BG_BRIGHT_BLACK = "90";
    public const string SGR_BG_BRIGHT_RED = "91";
    public const string SGR_BG_BRIGHT_GREEN = "92";
    public const string SGR_BG_BRIGHT_YELLOW = "93";
    public const string SGR_BG_BRIGHT_BLUE = "94";
    public const string SGR_BG_BRIGHT_MAGENTA = "95";
    public const string SGR_BG_BRIGHT_CYAN = "96";
    public const string SGR_BG_BRIGHT_WHITE = "97";
    
    public const string SGR_BG_HICOLOR_256 = "48;5";
    public const string SGR_BG_HICOLOR_TRUE = "48;2";
    
    // alt fonts (probably not used a lot)
    public const string SGR_FONT_DEFAULT = "10";
    public const string SGR_FONT_1 = "11";
    public const string SGR_FONT_2 = "12";
    public const string SGR_FONT_3 = "13";
    public const string SGR_FONT_4 = "14";
    public const string SGR_FONT_5 = "15";
    public const string SGR_FONT_6 = "16";
    public const string SGR_FONT_7 = "17";
    public const string SGR_FONT_8 = "18";
    public const string SGR_FONT_9 = "19";

    // cursor manipulation
    public const string CSI_CURSOR_MOVE_ABSOLUTE = "H";
    public const string CSI_CURSOR_MOVE_UP = "A";
    public const string CSI_CURSOR_MOVE_DOWN = "B";
    public const string CSI_CURSOR_MOVE_RIGHT = "C";
    public const string CSI_CURSOR_MOVE_LEFT = "D";
    public const string CSI_CURSOR_HOME = "H";
    public const string CSI_CURSOR_SAVE_POSITION = "7";
    public const string CSI_CURSOR_RESTORE_POSITION = "8";
    public const string CSI_CURSOR_GET_POSITION = "6n";

    // scroll
    public const string CSI_SCROLL_UP = "S";
    public const string CSI_SCROLL_DOWN = "T";
    public const string CSI_SCROLL_LEFT = " @";
    public const string CSI_SCROLL_RIGHT = " U";

    // private codes: VT100 double-height line
    public const string VT_DOUBLE_HEIGHT_TOP = "#3";
    public const string VT_DOUBLE_HEIGHT_BOTTOM = "#4";
    public const string VT_SINGLE_HEIGHT = "#5";

}