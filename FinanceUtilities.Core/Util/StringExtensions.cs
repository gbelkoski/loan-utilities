using System.Text;

namespace FinanceUtilities.Core.Util
{
    public static class CustomStringConverter
    {
        public static string ConvertToLatin(this string name)
        {
            int nameLength = name.Length;

            StringBuilder productName = new StringBuilder();

            for (int i = 0; i < nameLength; i++)
            {
                switch (name[i])
                {
                    case 'А':
                        productName.Append('A');
                        break;
                    case 'Б':
                        productName.Append('B');
                        break;
                    case 'В':
                        productName.Append('V');
                        break;
                    case 'Г':
                        productName.Append('G');
                        break;
                    case 'Д':
                        productName.Append('D');
                        break;
                    case 'Ѓ':
                        productName.Append("GJ");
                        break;
                    case 'Е':
                        productName.Append('E');
                        break;
                    case 'Ж':
                        productName.Append("ZH");
                        break;
                    case 'З':
                        productName.Append('Z');
                        break;
                    case 'Ѕ':
                        productName.Append("DZ");
                        break;
                    case 'И':
                        productName.Append('I');
                        break;
                    case 'Ј':
                        productName.Append('J');
                        break;
                    case 'К':
                        productName.Append('K');
                        break;
                    case 'Л':
                        productName.Append('L');
                        break;
                    case 'Љ':
                        productName.Append("LJ");
                        break;
                    case 'М':
                        productName.Append('M');
                        break;
                    case 'Н':
                        productName.Append('N');
                        break;
                    case 'Њ':
                        productName.Append("NJ");
                        break;
                    case 'О':
                        productName.Append('O');
                        break;
                    case 'П':
                        productName.Append('P');
                        break;
                    case 'Р':
                        productName.Append('R');
                        break;
                    case 'С':
                        productName.Append('S');
                        break;
                    case 'Т':
                        productName.Append('T');
                        break;
                    case 'Ќ':
                        productName.Append("KJ");
                        break;
                    case 'У':
                        productName.Append('U');
                        break;
                    case 'ф':
                        productName.Append('F');
                        break;
                    case 'Х':
                        productName.Append('H');
                        break;
                    case 'Ц':
                        productName.Append('C');
                        break;
                    case 'Ч':
                        productName.Append("CH");
                        break;
                    case 'Џ':
                        productName.Append("DZ");
                        break;
                    case 'Ш':
                        productName.Append("SH");
                        break;
                    case 'а':
                        productName.Append('a');
                        break;
                    case 'б':
                        productName.Append('b');
                        break;
                    case 'в':
                        productName.Append('v');
                        break;
                    case 'г':
                        productName.Append('g');
                        break;
                    case 'д':
                        productName.Append('d');
                        break;
                    case 'ѓ':
                        productName.Append("gj");
                        break;
                    case 'е':
                        productName.Append('e');
                        break;
                    case 'ж':
                        productName.Append("zh");
                        break;
                    case 'з':
                        productName.Append('z');
                        break;
                    case 'ѕ':
                        productName.Append("dz");
                        break;
                    case 'и':
                        productName.Append('i');
                        break;
                    case 'ј':
                        productName.Append('j');
                        break;
                    case 'к':
                        productName.Append('k');
                        break;
                    case 'л':
                        productName.Append('l');
                        break;
                    case 'љ':
                        productName.Append("lj");
                        break;
                    case 'м':
                        productName.Append('m');
                        break;
                    case 'н':
                        productName.Append('n');
                        break;
                    case 'њ':
                        productName.Append("nj");
                        break;
                    case 'о':
                        productName.Append('o');
                        break;
                    case 'п':
                        productName.Append('p');
                        break;
                    case 'р':
                        productName.Append('r');
                        break;
                    case 'с':
                        productName.Append('s');
                        break;
                    case 'т':
                        productName.Append('t');
                        break;
                    case 'ќ':
                        productName.Append("kj");
                        break;
                    case 'у':
                        productName.Append('u');
                        break;
                    case 'Ф':
                        productName.Append('f');
                        break;
                    case 'х':
                        productName.Append('h');
                        break;
                    case 'ц':
                        productName.Append('c');
                        break;
                    case 'ч':
                        productName.Append("ch");
                        break;
                    case 'џ':
                        productName.Append("dz");
                        break;
                    case 'ш':
                        productName.Append("sh");
                        break;

                    default:
                        productName.Append(name[i]);
                        break;
                }
            }

            return productName.ToString().ToLower();
        }

        public static string ConvertToCyrilic(this string name)
        {
            int nameLength = name.Length;

            StringBuilder productName = new StringBuilder();

            for (int i = 0; i < nameLength; i++)
            {
                switch (name[i])
                {
                    case 'A':
                        productName.Append('А');
                        break;
                    case 'B':
                        productName.Append('Б');
                        break;
                    case 'V':
                        productName.Append('В');
                        break;
                    case 'G':
                        productName.Append('Г');
                        break;
                    case 'D':
                        productName.Append('Д');
                        break;
                    case '}':
                        productName.Append('Ѓ');
                        break;
                    case 'E':
                        productName.Append('Е');
                        break;
                    case '|':
                        productName.Append('Ж');
                        break;
                    case 'Z':
                        productName.Append('З');
                        break;
                    case 'Y':
                        productName.Append('Ѕ');
                        break;
                    case 'I':
                        productName.Append('И');
                        break;
                    case 'J':
                        productName.Append('Ј');
                        break;
                    case 'K':
                        productName.Append('К');
                        break;
                    case 'L':
                        productName.Append('Л');
                        break;
                    case 'Q':
                        productName.Append('Љ');
                        break;
                    case 'M':
                        productName.Append('М');
                        break;
                    case 'N':
                        productName.Append('Н');
                        break;
                    case 'W':
                        productName.Append('Њ');
                        break;
                    case 'O':
                        productName.Append('О');
                        break;
                    case 'P':
                        productName.Append('П');
                        break;
                    case 'R':
                        productName.Append('Р');
                        break;
                    case 'S':
                        productName.Append('С');
                        break;
                    case 'T':
                        productName.Append('Т');
                        break;
                    case '"':
                        productName.Append('Ќ');
                        break;
                    case 'U':
                        productName.Append('У');
                        break;
                    case 'F':
                        productName.Append('ф');
                        break;
                    case 'H':
                        productName.Append('Х');
                        break;
                    case 'C':
                        productName.Append('Ц');
                        break;
                    case ':':
                        productName.Append('Ч');
                        break;
                    case 'X':
                        productName.Append('Џ');
                        break;
                    case '{':
                        productName.Append('Ш');
                        break;
                    case 'a':
                        productName.Append('а');
                        break;
                    case 'b':
                        productName.Append('б');
                        break;
                    case 'v':
                        productName.Append('в');
                        break;
                    case 'g':
                        productName.Append('г');
                        break;
                    case 'd':
                        productName.Append('д');
                        break;
                    case ']':
                        productName.Append('ѓ');
                        break;
                    case 'e':
                        productName.Append('е');
                        break;
                    case '\\':
                        productName.Append('ж');
                        break;
                    case 'z':
                        productName.Append('з');
                        break;
                    case 'y':
                        productName.Append('ѕ');
                        break;
                    case 'i':
                        productName.Append('и');
                        break;
                    case 'j':
                        productName.Append('ј');
                        break;
                    case 'k':
                        productName.Append('к');
                        break;
                    case 'l':
                        productName.Append('л');
                        break;
                    case 'q':
                        productName.Append('љ');
                        break;
                    case 'm':
                        productName.Append('м');
                        break;
                    case 'n':
                        productName.Append('н');
                        break;
                    case 'w':
                        productName.Append('њ');
                        break;
                    case 'o':
                        productName.Append('о');
                        break;
                    case 'p':
                        productName.Append('п');
                        break;
                    case 'r':
                        productName.Append('р');
                        break;
                    case 's':
                        productName.Append('с');
                        break;
                    case 't':
                        productName.Append('т');
                        break;
                    case '\'':
                        productName.Append('ќ');
                        break;
                    case 'u':
                        productName.Append('у');
                        break;
                    case 'f':
                        productName.Append('Ф');
                        break;
                    case 'h':
                        productName.Append('х');
                        break;
                    case 'c':
                        productName.Append('ц');
                        break;
                    case ';':
                        productName.Append('ч');
                        break;
                    case 'x':
                        productName.Append('џ');
                        break;
                    case '[':
                        productName.Append('ш');
                        break;

                    default:
                        productName.Append(name[i]);
                        break;
                }
            }

            return productName.ToString().ToLower();
        }
    }
}
