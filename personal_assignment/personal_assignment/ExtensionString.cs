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
}
