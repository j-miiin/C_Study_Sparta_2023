namespace week1_assignment_readline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("Enter your name and age: ");
            //string[] answer = Console.ReadLine().Split(' ');
            //string name = answer[0];
            //int age = int.Parse(answer[1]);
            //Console.WriteLine($"name: {name}, age: {age}");

            Console.Write("이름을 입력하세요: ");
            string name = Console.ReadLine();
            Console.Write("나이를 입력하세요: ");
            string age = Console.ReadLine();
            Console.WriteLine($"안녕하세요, {name}! 당신은 {age} 세 이군요.");
        }
    }
}