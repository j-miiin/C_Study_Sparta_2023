using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace personal_assignment
{
    public static class ExtensionString
    {
        // string 확장 함수
        // 텍스트 색상을 변경하여 출력해줌
        // (콘솔에 출력할 텍스트, 색상, WriteLine or Write)
        public static void PrintWithColor(this string text, ConsoleColor color, bool isEnter)
        {
            Console.ForegroundColor = color;
            if (isEnter) Console.WriteLine(text); else Console.Write(text);
            Console.ResetColor();
        }
    }

    public static class Extension
    {
        const int LENGTH10 = 10;
        const int LENGTH30 = 30;

        public static void AlignmentPrint(string[] text, int type)
        {
            int idx = 0;
            while (idx < text.Length)
            {
                string curStr = text[idx];
                switch (idx)
                {
                    case 0:
                        Console.Write($" {curStr, -LENGTH10}");
                        break;
                    case 1:
                        Console.Write("   ");
                        int length = curStr.Length + 8;
                        if (type == 0) Console.Write("방어력 "); else Console.Write("공격력 ");
                        ("+").PrintWithColor(ConsoleColor.Yellow, false);
                        curStr.PrintWithColor(ConsoleColor.Magenta, false);
                        while (12 - length >= 0)
                        {
                            Console.Write(" ");
                            length++;
                        }
                        break;
                    case 2:
                        Console.Write($"     {curStr, -LENGTH30}");
                        break;
                    case 3:
                        bool isSoldOut = (curStr == "구매 완료");
                        ("   " + curStr).PrintWithColor(isSoldOut ? ConsoleColor.Yellow : ConsoleColor.Magenta, false);
                        if (!isSoldOut) Console.Write(" G");
                        break;
                }
                if (idx != text.Length - 1) ("|").PrintWithColor(ConsoleColor.Yellow, false);
                idx++;
            }
        }
    }
}
