using System.Text;

namespace c_study_week4_4_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Hello");
            sb.Append(" ");
            sb.Append("World");         // Hello World

            sb.Insert(5, ", ");         // Hello,  World

            sb.Replace("World", "C#");  // Hello,  C#

            sb.Remove(5, 2);            // Hello C#

            string result = sb.ToString();
            Console.WriteLine(result);
        }
    }
}