using System;
using System.Collections.Generic;
using System.Text;

namespace HVTT.UI.Window.Forms
{
    internal class HVTTEnCode
    {
        public static String Translate(String s_Translate)
        {
            StringBuilder sb = new StringBuilder();
            Char[] c_Array = s_Translate.ToCharArray();
            int x = 39;
            foreach (Char c in c_Array)
            {
                if (c == '`')
                    sb.Append('a');
                else if (c == '\\')
                    sb.Append('b');
                else if (c == '|')
                    sb.Append('c');
                else if (c == '+')
                    sb.Append('d');
                else if (c == '=')
                    sb.Append('e');
                else if (c == '!')
                    sb.Append('f');

                else if (c == '#')
                    sb.Append('g');
                else if (c == '$')
                    sb.Append('h');
                else if (c == '%')
                    sb.Append('i');
                else if (c == '&')
                    sb.Append('j');
                else if (c == 'Ŵ')
                    sb.Append('Ŵ');
                else if (c == 'ஐ')
                    sb.Append('ஐ');

                else if (c == '^')
                    sb.Append('k');
                else if (c == '~')
                    sb.Append('l');
                else if (c == '(')
                    sb.Append('p');
                else if (c == '}')
                    sb.Append('q');
                else if (c == '[')
                    sb.Append('o');
                else if (c == ']')
                    sb.Append('y');
                else if (c == '.')
                    sb.Append('x');
                else if (c == '?')
                    sb.Append('s');
                else if (c == ',')
                    sb.Append('r');
                else if (c == '/')
                    sb.Append('z');
                else if (c == '<')
                    sb.Append('u');
                else if (c == '>')
                    sb.Append('v');
                else if (c == ';')
                    sb.Append('w');
                else if (c == '{')
                    sb.Append('t');

                else if (c == ':')
                    sb.Append('n');
                else if (c == '*')
                    sb.Append('m');
                else if (c == '_')
                    sb.Append(' ');
                else if (c == 'ﻷ')
                    sb.Append('.');
                else if (c == 'ﻃ')
                    sb.Append(',');
                else if (c == 'ﻼ')
                    sb.Append('\\');
                else if (c == 'ﻉ')
                    sb.Append(':');
                else if (c == 'Þ')
                    sb.Append('?');
                else if (c == 'Ø')
                    sb.Append('<');
                else if (c == '»')
                    sb.Append('/');
                else if (c == 'ﻋ')
                    sb.Append('`');
                else if (c == 'ß')
                    sb.Append(Convert.ToChar(x));
                else if (c == 'ﻎ')
                    sb.Append('@');
                else if (c == 'æ')
                    sb.Append('>');
                else if (c == 'ﻊ')
                    sb.Append(';');
                else if (c == 'ﻐ')
                    sb.Append('$');
                else if (c == 'ﻟ')
                    sb.Append(')');
                else if (c == 'ﻗ')
                    sb.Append('*');
                else if (c == '▓')
                    sb.Append('"');
                else if (c == 'ﻴ')
                    sb.Append('|');
                else if (c == 'ﻑ')
                    sb.Append('%');
                else if (c == 'ﻏ')
                    sb.Append('#');
                else if (c == 'ﻌ')
                    sb.Append('~');
                else if (c == 'ﻱ')
                    sb.Append('=');

                else if (c == 'ﻓ')
                    sb.Append('^');
                else if (c == 'ﻣ')
                    sb.Append('_');
                else if (c == 'ﻕ')
                    sb.Append('&');
                else if (c == 'ﻡ')
                    sb.Append('-');
                else if (c == 'ﻥ')
                    sb.Append('+');
                else if (c == 'ﻍ')
                    sb.Append('!');
                else if (c == 'ﻙ')
                    sb.Append('(');
                else if (c == '◦')
                    sb.Append('á');
                else if (c == '☺')
                    sb.Append('à');
                else if (c == '☼')
                    sb.Append('ạ');

                else if (c == '♂')
                    sb.Append('ả');
                else if (c == '♀')
                    sb.Append('ã');
                else if (c == '♠')
                    sb.Append('ă');
                else if (c == '♣')
                    sb.Append('ắ');
                else if (c == '♥')
                    sb.Append('ằ');
                else if (c == '♦')
                    sb.Append('ẵ');
                else if (c == '♪')
                    sb.Append('ẳ');
                else if (c == '♫')
                    sb.Append('ặ');
                else if (c == '')
                    sb.Append('â');
                else if (c == '')
                    sb.Append('ấ');
                else if (c == '')
                    sb.Append('ầ');
                else if (c == '▲')
                    sb.Append('ậ');
                else if (c == '►')
                    sb.Append('ẩ');
                else if (c == '▼')
                    sb.Append('ẫ');
                else if (c == '◄')
                    sb.Append('B');
                else if (c == '◊')
                    sb.Append('C');
                else if (c == '©')
                    sb.Append('G');
                else if (c == '¦')
                    sb.Append('A');
                else if (c == '●')
                    sb.Append('D');
                else if (c == '◘')
                    sb.Append('đ');
                else if (c == '')
                    sb.Append('E');
                else if (c == 'ﭶ')
                    sb.Append('é');
                else if (c == 'ﮆ')
                    sb.Append('è');
                else if (c == 'ﮖ')
                    sb.Append('ẻ');
                else if (c == 'ﮗ')
                    sb.Append('ẽ');
                else if (c == 'ﮘ')
                    sb.Append('ẹ');
                else if (c == 'ﮙ')
                    sb.Append('ê');
                else if (c == 'ﮚ')
                    sb.Append('ề');
                else if (c == 'ﮜ')
                    sb.Append('ệ');
                else if (c == 'ﮛ')
                    sb.Append('ế');
                else if (c == 'ﮝ')
                    sb.Append('ể');
                else if (c == 'ﮞ')
                    sb.Append('ễ');
                else if (c == 'ﮠ')
                    sb.Append('ĩ');
                else if (c == 'ﮢ')
                    sb.Append('ị');
                else if (c == 'ﮤ')
                    sb.Append('í');
                else if (c == 'ﮥ')
                    sb.Append('ì');
                else if (c == 'ﯗ')
                    sb.Append('ỉ');
                else if (c == 'ﯜ')
                    sb.Append('F');
                else if (c == 'ﯝ')
                    sb.Append('O');
                else if (c == 'ﯠ')
                    sb.Append('ò');
                else if (c == 'ﯢ')
                    sb.Append('ó');
                else if (c == 'ﯤ')
                    sb.Append('ọ');
                else if (c == 'ﯥ')
                    sb.Append('ỏ');
                else if (c == 'ﯦ')
                    sb.Append('õ');
                else if (c == 'ﱞ')
                    sb.Append('ơ');
                else if (c == 'ﷲ')
                    sb.Append('ờ');
                else if (c == 'ﺀ')
                    sb.Append('ớ');
                else if (c == 'ﺁ')
                    sb.Append('ở');
                else if (c == 'ﺂ')
                    sb.Append('ỡ');
                else if (c == 'ﺕ')
                    sb.Append('ợ');
                else if (c == 'ﺗ')
                    sb.Append('ô');
                else if (c == 'ﺟ')
                    sb.Append('ồ');
                else if (c == 'ﺢ')
                    sb.Append('ố');
                else if (c == 'ﺣ')
                    sb.Append('ộ');

                else if (c == 'ﺫ')
                    sb.Append('ỗ');
                else if (c == 'ﺭ')
                    sb.Append('ổ');

                else if (c == 'ﺱ')
                    sb.Append('I');
                else if (c == 'ﺵ')
                    sb.Append('ì');
                else if (c == 'ﺷ')
                    sb.Append('í');
                else if (c == 'ﺳ')
                    sb.Append('ị');
                else if (c == 'ﺹ')
                    sb.Append('K');
                else if (c == 'ﻁ')
                    sb.Append('J');
                else if (c == 'ﺻ')
                    sb.Append('L');
                else if (c == 'ﺿ')
                    sb.Append('S');
                else if (c == 'ﻅ')
                    sb.Append('U');
                else if (c == '÷')
                    sb.Append('ù');
                else if (c == 'Î')
                    sb.Append('ú');
                else if (c == 'Ï')
                    sb.Append('ủ');
                else if (c == 'ñ')
                    sb.Append('ũ');
                else if (c == 'ü')
                    sb.Append('ụ');
                else if (c == 'Æ')
                    sb.Append('ư');
                else if (c == 'Ç')
                    sb.Append('ừ');
                else if (c == '¤')
                    sb.Append('ứ');
                else if (c == '¥')
                    sb.Append('ử');
                else if (c == 'µ')
                    sb.Append('ữ');

                else if (c == '£')
                    sb.Append('ự');
                else if (c == '¶')
                    sb.Append('P');
                else if (c == 'ç')
                    sb.Append('Q');
                else if (c == 'ð')
                    sb.Append('R');
                else if (c == '¼')
                    sb.Append('X');
                else if (c == '½')
                    sb.Append('Z');
                else if (c == '¾')
                    sb.Append('V');
                else if (c == '¿')
                    sb.Append('W');
                else if (c == '¹')
                    sb.Append('T');
                else if (c == '™')
                    sb.Append('Y');
                else if (c == '…')
                    sb.Append('ý');
                else if (c == '€')
                    sb.Append('ỳ');
                else if (c == '‡')
                    sb.Append('H');
                else if (c == '³')
                    sb.Append('ỵ');
                else if (c == '²')
                    sb.Append('ỷ');

                else if (c == 'û')
                    sb.Append('ỹ');
                else if (c == 'Ğ')
                    sb.Append('N');
                else if (c == '§')
                    sb.Append('M');
                else if (c == '⌂')
                    sb.Append('À');
                else if (c == '≈')
                    sb.Append('Á');
                else if (c == '∞')
                    sb.Append('Ã');
                else if (c == '∩')
                    sb.Append('Ả');
                else if (c == 'ς')
                    sb.Append('Ạ');
                else if (c == '‰')
                    sb.Append('Â');
                else if (c == 'Š')
                    sb.Append('Ấ');
                else if (c == '‹')
                    sb.Append('Ầ');
                else if (c == 'Œ')
                    sb.Append('Ẩ');

                else if (c == 'Ž')
                    sb.Append('Ẫ');
                else if (c == '°')
                    sb.Append('Ậ');
                else if (c == '†')
                    sb.Append('Ă');
                else if (c == '®')
                    sb.Append('Ằ');
                else if (c == '•')
                    sb.Append('Ắ');
                else if (c == '—')
                    sb.Append('Ẳ');
                else if (c == '†')
                    sb.Append('Ẵ');
                else if (c == 'Ұ')
                    sb.Append('Ặ');
                else if (c == '∂')
                    sb.Append('Ò');
                else if (c == '→')
                    sb.Append('Ó');
                else if (c == '←')
                    sb.Append('Õ');
                else if (c == '↓')
                    sb.Append('Ỏ');
                else if (c == '℅')
                    sb.Append('Ọ');
                else if (c == 'œ')
                    sb.Append('Ô');
                else if (c == 'ª')
                    sb.Append('Ồ');
                else if (c == 'º')
                    sb.Append('Ố');
                else if (c == '¢')
                    sb.Append('Ộ');
                else if (c == '„')
                    sb.Append('Ổ');
                else if (c == 'ǒ')
                    sb.Append('Ỗ');
                else if (c == 'Ǔ')
                    sb.Append('Ơ');
                else if (c == 'ǔ')
                    sb.Append('Ờ');
                else if (c == 'Ǖ')
                    sb.Append('Ớ');
                else if (c == 'ǖ')
                    sb.Append('Ỡ');

                else if (c == 'Ǘ')
                    sb.Append('Ở');
                else if (c == 'Ώ')
                    sb.Append('Ợ');
                else if (c == 'Ξ')
                    sb.Append('Ư');
                else if (c == 'Π')
                    sb.Append('Ừ');
                else if (c == 'Σ')
                    sb.Append('Ứ');
                else if (c == 'Θ')
                    sb.Append('Ữ');
                else if (c == 'θ')
                    sb.Append('Ử');
                else if (c == 'έ')
                    sb.Append('Ự');
                else if (c == 'Ψ')
                    sb.Append('Ê');
                else if (c == 'Δ')
                    sb.Append('Ề');
                else if (c == 'δ')
                    sb.Append('Ế');
                else if (c == 'Ύ')
                    sb.Append('Ễ');
                else if (c == 'Ό')
                    sb.Append('Ể');

                else if (c == 'ή')
                    sb.Append('Ệ');
                else if (c == 'Ђ')
                    sb.Append('Ý');
                else if (c == 'Ѓ')
                    sb.Append('Ỳ');
                else if (c == 'Ж')
                    sb.Append('Ỹ');
                else if (c == 'Д')
                    sb.Append('Ỷ');
                else if (c == 'Й')
                    sb.Append('Ỵ');
                else if (c == 'Ш')
                    sb.Append('È');
                else if (c == 'Щ')
                    sb.Append('É');
                else if (c == 'Ы')
                    sb.Append('Ẽ');


                else if (c == 'Ю')
                    sb.Append('Ẻ');
                else if (c == 'ф')
                    sb.Append('Ẹ');
                else if (c == 'Ә')
                    sb.Append('Ù');
                else if (c == 'ט')
                    sb.Append('Ú');
                else if (c == 'ק')
                    sb.Append('Ủ');
                else if (c == 'פ')
                    sb.Append('Ũ');
                else if (c == 'я')
                    sb.Append('Ụ');
                else if (c == 'ğ')
                    sb.Append('Í');
                else if (c == 'Ì')
                    sb.Append('Ĩ');
                else if (c == 'ĭ')
                    sb.Append('Ỉ');
                else if (c == 'ĳ')
                    sb.Append('Ő');
                else if (c == 'Ĳ')
                    sb.Append('Ị');
                else if (c == '↨')
                    sb.Append('Đ');
                else if (c == '۩')
                    sb.Append('0');
                else if (c == '۝')
                    sb.Append('1');
                else if (c == '█')
                    sb.Append('2');
                else if (c == '╬')
                    sb.Append('3');
                else if (c == '۞')
                    sb.Append('4');
                else if (c == '░')
                    sb.Append('5');
                else if (c == '╥')
                    sb.Append('6');
                else if (c == '╣')
                    sb.Append('7');
                else if (c == '╔')
                    sb.Append('8');
                else if (c == '')
                    sb.Append('9');
                else if (c == '₧')
                    sb.Append('[');
                else if (c == '₫')
                    sb.Append(']');
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}
