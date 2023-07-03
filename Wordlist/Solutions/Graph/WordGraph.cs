using System;
using System.Runtime.CompilerServices;

namespace Wordlist.Solutions.Graph;

public class WordGraph
{
    private WordGraph? _number0;
    private WordGraph? _number1;
    private WordGraph? _number2;
    private WordGraph? _number3;
    private WordGraph? _number4;
    private WordGraph? _number5;
    private WordGraph? _number6;
    private WordGraph? _number7;
    private WordGraph? _number8;
    private WordGraph? _number9;
    private WordGraph? _a;
    private WordGraph? _b;
    private WordGraph? _c;
    private WordGraph? _d;
    private WordGraph? _e;
    private WordGraph? _f;
    private WordGraph? _g;
    private WordGraph? _h;
    private WordGraph? _i;
    private WordGraph? _j;
    private WordGraph? _k;
    private WordGraph? _l;
    private WordGraph? _m;
    private WordGraph? _n;
    private WordGraph? _o;
    private WordGraph? _p;
    private WordGraph? _q;
    private WordGraph? _r;
    private WordGraph? _s;
    private WordGraph? _t;
    private WordGraph? _u;
    private WordGraph? _v;
    private WordGraph? _w;
    private WordGraph? _x;
    private WordGraph? _y;
    private WordGraph? _z;
    private WordGraph? _apostrophe;
    private WordGraph? _minus;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WordGraph? GetNode(char character)
    {
        switch (character)
        {
            case '0':
                return _number0;
            case '1':
                return _number1;
            case '2':
                return _number2;
            case '3':
                return _number3;
            case '4':
                return _number4;
            case '5':
                return _number5;
            case '6':
                return _number6;
            case '7':
                return _number7;
            case '8':
                return _number8;
            case '9':
                return _number9;
            case 'a':
            case 'A':
                return _a;
            case 'b':
            case 'B':
                return _b;
            case 'c':
            case 'C':
                return _c;
            case 'd':
            case 'D':
                return _d;
            case 'e':
            case 'E':
                return _e;
            case 'f':
            case 'F':
                return _f;
            case 'g':
            case 'G':
                return _g;
            case 'h':
            case 'H':
                return _h;
            case 'i':
            case 'I':
                return _i;
            case 'j':
            case 'J':
                return _j;
            case 'k':
            case 'K':
                return _k;
            case 'l':
            case 'L':
                return _l;
            case 'm':
            case 'M':
                return _m;
            case 'n':
            case 'N':
                return _n;
            case 'o':
            case 'O':
                return _o;
            case 'p':
            case 'P':
                return _p;
            case 'q':
            case 'Q':
                return _q;
            case 'r':
            case 'R':
                return _r;
            case 's':
            case 'S':
                return _s;
            case 't':
            case 'T':
                return _t;
            case 'u':
            case 'U':
                return _u;
            case 'v':
            case 'V':
                return _v;
            case 'w':
            case 'W':
                return _w;
            case 'x':
            case 'X':
                return _x;
            case 'y':
            case 'Y':
                return _y;
            case 'z':
            case 'Z':
                return _z;
            case '\'':
                return _apostrophe;
            case '-':
                return _minus;
            default:
                throw new ArgumentOutOfRangeException(nameof(character), character, "Unknown character");
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public WordGraph GetOrCreateNode(char character)
    {
        switch (character)
        {
            case '0':
                return _number0 ??= new WordGraph();
            case '1':
                return _number1 ??= new WordGraph();
            case '2':
                return _number2 ??= new WordGraph();
            case '3':
                return _number3 ??= new WordGraph();
            case '4':
                return _number4 ??= new WordGraph();
            case '5':
                return _number5 ??= new WordGraph();
            case '6':
                return _number6 ??= new WordGraph();
            case '7':
                return _number7 ??= new WordGraph();
            case '8':
                return _number8 ??= new WordGraph();
            case '9':
                return _number9 ??= new WordGraph();
            case 'a':
            case 'A':
                return _a ??= new WordGraph();
            case 'b':
            case 'B':
                return _b ??= new WordGraph();
            case 'c':
            case 'C':
                return _c ??= new WordGraph();
            case 'd':
            case 'D':
                return _d ??= new WordGraph();
            case 'e':
            case 'E':
                return _e ??= new WordGraph();
            case 'f':
            case 'F':
                return _f ??= new WordGraph();
            case 'g':
            case 'G':
                return _g ??= new WordGraph();
            case 'h':
            case 'H':
                return _h ??= new WordGraph();
            case 'i':
            case 'I':
                return _i ??= new WordGraph();
            case 'j':
            case 'J':
                return _j ??= new WordGraph();
            case 'k':
            case 'K':
                return _k ??= new WordGraph();
            case 'l':
            case 'L':
                return _l ??= new WordGraph();
            case 'm':
            case 'M':
                return _m ??= new WordGraph();
            case 'n':
            case 'N':
                return _n ??= new WordGraph();
            case 'o':
            case 'O':
                return _o ??= new WordGraph();
            case 'p':
            case 'P':
                return _p ??= new WordGraph();
            case 'q':
            case 'Q':
                return _q ??= new WordGraph();
            case 'r':
            case 'R':
                return _r ??= new WordGraph();
            case 's':
            case 'S':
                return _s ??= new WordGraph();
            case 't':
            case 'T':
                return _t ??= new WordGraph();
            case 'u':
            case 'U':
                return _u ??= new WordGraph();
            case 'v':
            case 'V':
                return _v ??= new WordGraph();
            case 'w':
            case 'W':
                return _w ??= new WordGraph();
            case 'x':
            case 'X':
                return _x ??= new WordGraph();
            case 'y':
            case 'Y':
                return _y ??= new WordGraph();
            case 'z':
            case 'Z':
                return _z ??= new WordGraph();
            case '\'':
                return _apostrophe ??= new WordGraph();
            case '-':
                return _minus ??= new WordGraph();
            default:
                throw new ArgumentOutOfRangeException(nameof(character), character, "Unknown character");
        }
    }
}
